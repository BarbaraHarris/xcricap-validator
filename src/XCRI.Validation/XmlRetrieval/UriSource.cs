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
            Logging.ILog log,
            XmlResolver xmlResolver
            )
            : base(log, xmlResolver)
        {
        }
        public override XmlReader GetXmlReader(Uri input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            this.Log.LogMessageStatic
                (
                "Validating " + input.ToString()
                );
            XmlReaderSettings settings = this.GetXmlReaderSettings();
            return XmlReader.Create(input.ToString(), settings);
        }
    }
}
