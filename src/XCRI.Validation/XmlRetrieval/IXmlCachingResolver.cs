using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace XCRI.Validation.XmlRetrieval
{
    public interface IXmlCachingResolver
    {
        IList<IXmlCacheLocation> CacheLocations { get; }
        ICredentials Credentials { set; }
    }
}
