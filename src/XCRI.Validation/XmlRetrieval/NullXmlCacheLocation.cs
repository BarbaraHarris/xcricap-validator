using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.XmlRetrieval
{
    public class NullXmlCacheLocation : IXmlCacheLocation
    {
        #region IXmlCacheLocation Members

        public bool ContainsCache(Uri absoluteUri)
        {
            return false;
        }

        public System.IO.FileStream RetrieveCache(Uri absoluteUri)
        {
            throw new NotImplementedException();
        }

        public void SaveCache(Uri absoluteUri, string contents)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
