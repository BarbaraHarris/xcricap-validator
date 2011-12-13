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
            IEnumerable<Logging.ILog> logs,
            XmlResolver xmlResolver
            )
            : base(logs, xmlResolver)
        {
        }
        public override XmlReader GetXmlReader(string input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            if (String.IsNullOrWhiteSpace(input))
                throw new ArgumentException("The parameter cannot be empty or just contain whitespace", "input");
            this.Logs.Log
                (
                Logging.LogCategory.UtilisationInformation,
                "Validating string source"
                );
            XmlReaderSettings settings = this.GetXmlReaderSettings();
            using (StringReader stringReader = new StringReader(input))
            {
                return XmlReader.Create(stringReader, settings);
            }
        }
    }
}
