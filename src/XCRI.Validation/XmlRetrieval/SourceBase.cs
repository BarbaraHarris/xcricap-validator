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

        public IList<INamespaceReference> NamespaceReferences { get; protected set; }
        public Action<System.Xml.Schema.ValidationEventArgs> ValidationEventHandler { get; set; }

        public SourceBase
            (
            IEnumerable<INamespaceReference> namespaceReferences
            )
        {
            if (null != namespaceReferences)
                this.NamespaceReferences = new List<INamespaceReference>(namespaceReferences);
            else
                this.NamespaceReferences = new List<INamespaceReference>();
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
            readerSettings.XmlResolver = IoC.Resolve<IXmlCachingResolver>() as XmlResolver;
            readerSettings.ValidationEventHandler += (o, e) =>
            {
                if (null != this.ValidationEventHandler)
                    this.ValidationEventHandler(e);
            };
            if (null != this.NamespaceReferences)
            {
                foreach (var nsr in this.NamespaceReferences)
                {
                    if (null == nsr)
                        continue;
                    var ns = nsr.Namespace;
                    var prefix = nsr.Prefix;
                    if (false == ns.IsAbsoluteUri)
                        throw new ArgumentException("Namespace URIs must be absolute");
                    if (String.IsNullOrEmpty(prefix))
                        continue;
                    readerSettings.Schemas.Add
                        (
                        ns.ToString(),
                        prefix
                        );
                }
            }
            return readerSettings;
        }

        #endregion

    }
}
