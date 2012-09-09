using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.XmlRetrieval
{
    public class UriSource : SourceBase<Uri>
    {
        public UriSource
            (
            IEnumerable<Logging.ILog> logs,
            XmlResolver xmlResolver
            )
            : base(logs, xmlResolver)
        {
        }
        public override XmlReader GetXmlReader(Uri input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            this.Logs.Log
                (
                Logging.LogCategory.UtilisationInformation,
                "Validating " + input.ToString()
                );
            XmlReaderSettings settings = this.GetXmlReaderSettings();
            return XmlReader.Create(input.ToString(), settings);
        }
    }
}
