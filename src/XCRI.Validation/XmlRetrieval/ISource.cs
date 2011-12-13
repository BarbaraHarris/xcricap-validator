using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.XmlRetrieval
{
    public interface ISource
    {
        IList<NamespaceReference> NamespaceReferences { get; }
        Action<System.Xml.Schema.ValidationEventArgs> ValidationEventHandler { get; set; }
        System.Xml.XmlReaderSettings GetXmlReaderSettings();
        System.Xml.XmlReader GetXmlReader(object input);
    }
    public interface ISource<T> : ISource
    {
        System.Xml.XmlReader GetXmlReader(T input);
    }
}
