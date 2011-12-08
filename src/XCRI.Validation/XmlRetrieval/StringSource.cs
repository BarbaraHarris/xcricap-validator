using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.XmlRetrieval
{
    public class StringSource : SourceBase<string>
    {
        public StringSource
            (
            IEnumerable<INamespaceReference> namespaceReferences
            )
            : base(namespaceReferences)
        {
        }
        public override System.Xml.XmlReader GetXmlReader(string input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            if (String.IsNullOrWhiteSpace(input))
                throw new ArgumentException("The parameter cannot be empty or just contain whitespace", "input");
            IoC.ResolveAll<Logging.ILog>().Log
                (
                Logging.LogCategory.UtilisationInformation,
                "Validating string source"
                );
            XmlReaderSettings settings = this.GetXmlReaderSettings();
            StringReader stringReader = new StringReader(input);
            return XmlReader.Create(stringReader, settings);
        }
    }
}
