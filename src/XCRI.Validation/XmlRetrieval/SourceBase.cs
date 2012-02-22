using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace XCRI.Validation.XmlRetrieval
{
    public abstract class SourceBase<T> : ISource<T>
    {

        public IList<NamespaceReference> NamespaceReferences { get; protected set; }
        public Action<System.Xml.Schema.ValidationEventArgs> ValidationEventHandler { get; set; }
        public XmlResolver XmlResolver { get; set; }
        public IList<Logging.ILog> Logs { get; protected set; }

        public SourceBase
            (
            IEnumerable<Logging.ILog> logs,
            XmlResolver xmlResolver
            )
        {
            if (null != logs)
                this.Logs = new List<Logging.ILog>(logs);
            else
                this.Logs = new List<Logging.ILog>();
            this.XmlResolver = xmlResolver;
            this.NamespaceReferences = new List<NamespaceReference>();
        }

        #region ISource Members

        public System.Xml.XmlReader GetXmlReader(object input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            if (false == (input is T))
                throw new ArgumentException("The input argument must be of type " + typeof(T).FullName, "input");
            return this.GetXmlReader((T)input);
        }

        public abstract System.Xml.XmlReader GetXmlReader(T input);
        
        public virtual System.Xml.XmlReaderSettings GetXmlReaderSettings
            (
            )
        {
            XmlReaderSettings readerSettings = new XmlReaderSettings();
            readerSettings.ValidationType = ValidationType.Schema;
            readerSettings.ValidationFlags = readerSettings.ValidationFlags
                | XmlSchemaValidationFlags.ReportValidationWarnings
                | XmlSchemaValidationFlags.AllowXmlAttributes
                | XmlSchemaValidationFlags.ProcessIdentityConstraints
                | XmlSchemaValidationFlags.ProcessSchemaLocation;
            readerSettings.DtdProcessing = DtdProcessing.Prohibit;
            readerSettings.XmlResolver = this.XmlResolver;
            readerSettings.ValidationEventHandler += (o, e) =>
            {
                if (null != this.ValidationEventHandler)
                    this.ValidationEventHandler(e);
            };
            if (null != this.NamespaceReferences)
            {
                readerSettings.Schemas.XmlResolver = this.XmlResolver;
                foreach (var nsr in this.NamespaceReferences)
                {
                    if (null == nsr)
                        continue;
                    if (false == nsr.SchemaLocation.IsAbsoluteUri)
                        throw new ArgumentException("Schema locations must be absolute");
                    readerSettings.Schemas.Add
                        (
                        nsr.Namespace,
                        nsr.SchemaLocation.ToString()
                        );
                }
            }
            return readerSettings;
        }

        #endregion

    }
}
