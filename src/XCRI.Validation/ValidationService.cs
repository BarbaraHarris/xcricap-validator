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
    public partial class ValidationService : IValidationService
    {
        public IList<IInterpreter> XmlExceptionInterpreters { get; protected set; }
        public IList<IContentValidator> XmlContentValidators { get; protected set; }
        public IList<INamespaceReference> NamespaceReferences { get; protected set; }
        public System.Globalization.CultureInfo TargetCulture { get; protected set; }
        public ValidationService()
            : this(null, null, null)
        {
        }
        public ValidationService
            (
            IEnumerable<IInterpreter> interpreters,
            IEnumerable<IContentValidator> contentValidators,
            IEnumerable<INamespaceReference> namespaceReferences
            )
            : this
            (
            System.Globalization.CultureInfo.CurrentUICulture, 
            interpreters, 
            contentValidators,
            namespaceReferences
            )
        {
        }
        public ValidationService
            (
            System.Globalization.CultureInfo targetCulture,
            IEnumerable<IInterpreter> interpreters,
            IEnumerable<IContentValidator> contentValidators,
            IEnumerable<INamespaceReference> namespaceReferences
            )
        {
            this.TargetCulture = targetCulture;
            if (null != interpreters)
                this.XmlExceptionInterpreters = new List<IInterpreter>(interpreters.OrderBy(i => i.Order));
            else
                this.XmlExceptionInterpreters = new List<IInterpreter>();
            if (null != contentValidators)
                this.XmlContentValidators = new List<IContentValidator>(contentValidators.OrderBy(cv => cv.Order));
            else
                this.XmlContentValidators = new List<IContentValidator>();
            if (null != namespaceReferences)
                this.NamespaceReferences = new List<INamespaceReference>(namespaceReferences);
            else
                this.NamespaceReferences = new List<INamespaceReference>();
        }
        public IList<IValidationResult> Validate<T>(T input)
        {
            XmlRetrieval.ISource<T> source = IoC.Resolve<XmlRetrieval.ISource<T>>();
            if (null == source)
                throw new IoCDependencyInjectionNotFoundException<T>();
            List<IValidationResult> results = new List<IValidationResult>();
            source.ValidationEventHandler = (e) =>
            {
                if (null == e)
                    throw new ArgumentNullException("e");
                if (null == e.Exception)
                    throw new ArgumentException("The validation event args must contain an exception");
                IValidationResult r = this.XmlExceptionInterpreters.Interpret(e.Exception);
                if (null != r)
                    results.Add(r);
                else
                    results.Add(new ValidationResult()
                    {
                        Exception = e.Exception,
                        Interpretation = e.Message,
                        Status = ValidationStatus.Exception
                    });
            };
            using (XmlReader xmlReader = source.GetXmlReader(input))
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
                doc.Schemas = xmlReader.Settings.Schemas;
                {
                    using (IoC.ResolveAll<Logging.ITimedLog>().Step("Loading and parsing XML file"))
                    {
                        DateTime start = DateTime.Now;
                        try
                        {
                            doc.Load(xmlReader);
                        }
                        catch (Exception e)
                        {
                            IValidationResult r = this.XmlExceptionInterpreters.Interpret(e);
                            if (null != r)
                                results.Add(r);
                        }
                    }
                }
                {
                    using (IoC.ResolveAll<Logging.ITimedLog>().Step("Executing content validators"))
                    {
                        if (null != this.XmlContentValidators)
                        {
                            foreach (var cv in this.XmlContentValidators)
                            {
                                string message = String.Empty;
                                var status = cv.Validate(doc, out message);
                                if (status == ValidationStatus.Valid)
                                    continue;
                                IValidationResult r = cv.Interpreters.Interpret
                                    (
                                    new ContentValidation.ContentValidationException(message)
                                    );
                                if (null != r)
                                    results.Add(r);
                            }
                        }
                    }
                }
            }
            return results;
        }
    }
}
