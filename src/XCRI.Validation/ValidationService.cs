using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using Ninject;
using System.IO;
using XCRI.Validation.ExtensionMethods;
using XCRI.Validation.MessageInterpretation;
using XCRI.Validation.ContentValidation;
using XCRI.Validation.XmlRetrieval;

namespace XCRI.Validation
{
    public partial class ValidationService<T> : IValidationService<T>
    {
        public IList<IInterpreter> XmlExceptionInterpreters { get; protected set; }
        public IList<IValidator> XmlContentValidators { get; protected set; }
        public IList<NamespaceReference> NamespaceReferences { get; protected set; }
        public System.Globalization.CultureInfo TargetCulture { get; set; }
        public IList<Logging.ILog> Logs { get; protected set; }
        public IList<Logging.ITimedLog> TimedLogs { get; protected set; }
        public XmlRetrieval.ISource<T> Source { get; set; }
        public ValidationService()
            : this(null, null, null, null, null)
        {
        }
        public ValidationService
            (
            IEnumerable<IInterpreter> interpreters,
            IEnumerable<IValidator> contentValidators,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs,
            XmlRetrieval.ISource<T> source
            )
            : this
            (
            System.Globalization.CultureInfo.CurrentUICulture, 
            interpreters, 
            contentValidators,
            logs,
            timedLogs,
            source
            )
        {
        }
        public ValidationService
            (
            System.Globalization.CultureInfo targetCulture,
            IEnumerable<IInterpreter> interpreters,
            IEnumerable<IValidator> contentValidators,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs,
            XmlRetrieval.ISource<T> source
            )
        {
            this.NamespaceReferences = new List<NamespaceReference>();
            this.Source = source;
            this.TargetCulture = targetCulture;
            if (null != interpreters)
                this.XmlExceptionInterpreters = new List<IInterpreter>(interpreters.OrderBy(i => i.Order));
            else
                this.XmlExceptionInterpreters = new List<IInterpreter>();
            if (null != contentValidators)
                this.XmlContentValidators = new List<IValidator>(contentValidators.OrderBy(cv => cv.Order));
            else
                this.XmlContentValidators = new List<IValidator>();
            if (null != logs)
                this.Logs = new List<Logging.ILog>(logs);
            else
                this.Logs = new List<Logging.ILog>();
            if (null != timedLogs)
                this.TimedLogs = new List<Logging.ITimedLog>(timedLogs);
            else
                this.TimedLogs = new List<Logging.ITimedLog>();
        }
        public IList<ValidationResult> Validate(T input)
        {
            if (null == this.Source)
                throw new InvalidOperationException("The Source property must be set before calling Validate");
            ValidationResultCollection results = new ValidationResultCollection();
            this.Source.ValidationEventHandler = (e) =>
            {
                if (null == e)
                    throw new ArgumentNullException("e");
                if (null == e.Exception)
                    throw new ArgumentException("The validation event args must contain an exception");
                ValidationResult r = this.XmlExceptionInterpreters.Interpret("XML Structure", e.Exception);
                if (null != r)
                {
                    ValidationInstance vi = null;
                    if (e.Exception is System.Xml.Schema.XmlSchemaException)
                    {
                        vi = new ValidationInstance()
                        {
                            LinePosition = (e.Exception as System.Xml.Schema.XmlSchemaException).LinePosition,
                            LineNumber = (e.Exception as System.Xml.Schema.XmlSchemaException).LineNumber,
                            Status = ValidationStatus.Exception
                        };
                    }
                    if(null != vi)
                        r.Instances.Add(vi);
                    results.Add(r.Interpretation, r);
                }
                else
                    results.Add(e.Message, new ValidationResult()
                    {
                        Exception = e.Exception,
                        Interpretation = e.Message
                    });
            };
            using (XmlReader xmlReader = this.Source.GetXmlReader(input))
            {
                System.Xml.Linq.XDocument doc = null;
                //doc.Schemas = xmlReader.Settings.Schemas;
                using (this.TimedLogs.Step("Loading and parsing XML file"))
                {
                    DateTime start = DateTime.Now;
                    try
                    {
                        doc = System.Xml.Linq.XDocument.Load(xmlReader, System.Xml.Linq.LoadOptions.SetLineInfo);
                    }
                    catch (System.Xml.XmlException e)
                    {
                        ValidationResult r = this.XmlExceptionInterpreters.Interpret("XML Structure", e);
                        r.Instances.Add(new ValidationInstance()
                        {
                            LineNumber = e.LineNumber,
                            LinePosition = e.LinePosition
                        });
                        if (null != r)
                            results.Add(r.Interpretation, r);
                    }
                }
                if (null != doc)
                {
                    using (this.TimedLogs.Step("Executing content validators"))
                    {
                        if (null != this.XmlContentValidators)
                        {
                            foreach (var cv in this.XmlContentValidators)
                            {
                                var vrc = cv.Validate(doc.Root);
                                if (null != vrc)
                                    foreach (var vr in vrc)
                                        if (null != vr)
                                            results.Add(vr.Interpretation, vr);
                            }
                        }
                    }
                }
            }
            return results.Values.ToList();
        }
        private class ValidationResultCollection : Dictionary<string, ValidationResult>
        {
            public new void Add(string key, ValidationResult result)
            {
                if(null == result)
                    throw new ArgumentNullException("result");
                if(null == key)
                    throw new ArgumentNullException("key");
                if(String.IsNullOrWhiteSpace(key))
                    throw new ArgumentException("key");
                if (false == base.ContainsKey(key))
                {
                    base.Add(key, result);
                    return;
                }
                var vr = base[key];
                foreach (var vi in result.Instances)
                    if(null != vi)
                        vr.Instances.Add(vi);
            }
        }
    }
}
