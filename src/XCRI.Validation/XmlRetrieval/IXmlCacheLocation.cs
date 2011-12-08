using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XCRI.Validation.XmlRetrieval
{
    public interface IXmlCacheLocation
    {
        bool ContainsCache(Uri absoluteUri);
        FileStream RetrieveCache(Uri absoluteUri);
        void SaveCache(Uri absoluteUri, string contents);
    }
}
