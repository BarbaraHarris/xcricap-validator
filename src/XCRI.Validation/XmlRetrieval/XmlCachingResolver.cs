using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Net;
using System.Security.Cryptography;
using System.Net.Cache;
using System.IO;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.XmlRetrieval
{
    public class XmlCachingResolver : XmlUrlResolver, IXmlCachingResolver
    {
        public bool BypassCache { get; set; }
        private ICredentials credentials = null;
        public IList<IXmlCacheLocation> CacheLocations { get; protected set; }

        public XmlCachingResolver(IEnumerable<IXmlCacheLocation> cacheLocations)
        {
            this.BypassCache = false;
            if (null != cacheLocations)
                this.CacheLocations = new List<IXmlCacheLocation>(cacheLocations);
            else
                this.CacheLocations = new List<IXmlCacheLocation>();
        }

        public override ICredentials Credentials
        {
            set
            {
                credentials = value;
                base.Credentials = value;
            }
        }

        public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
        {
            if (null == absoluteUri)
            {
                throw new ArgumentNullException("absoluteUri");
            }
            if (this.BypassCache)
            {
                IoC.ResolveAll<Logging.ILog>().Log
                    (
                    Logging.LogCategory.XsdLocations,
                    "Bypassing cache for " + absoluteUri
                    );
                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
            using (IoC.ResolveAll<Logging.ITimedLog>().Step("Retrieving " + absoluteUri.ToString()))
            {
                IoC.ResolveAll<Logging.ILog>().Log
                    (
                    Logging.LogCategory.XsdLocations,
                    "Attempting to load " + absoluteUri + " (using credentials: " + (null == this.credentials ? "no" : "yes") + ")"
                    );
                if (absoluteUri.ToString().ToLower().EndsWith(".xsd"))
                {
                    if (null != this.CacheLocations)
                    {
                        using (IoC.ResolveAll<Logging.ITimedLog>().Step("Checking cache"))
                        {
                            foreach (var cl in this.CacheLocations)
                            {
                                var fs = cl.RetrieveCache(absoluteUri);
                                if (null != fs)
                                {
                                    IoC.ResolveAll<Logging.ILog>().Log
                                        (
                                        Logging.LogCategory.XsdLocations | Logging.LogCategory.CachingInformation | Logging.LogCategory.TimingInformation,
                                        absoluteUri.ToString() + " loaded from cache"
                                        );
                                    return fs;
                                }
                            }
                        }
                    }
                    // resolve resources from cache (if possible)
                    try
                    {
                        if (
                            (absoluteUri.Scheme == "http")
                            &&
                            (null == ofObjectToReturn || ofObjectToReturn == typeof(Stream))
                            )
                        {
                            using (IoC.ResolveAll<Logging.ITimedLog>().Step("Downloading file"))
                            {
                                WebRequest webReq = WebRequest.Create(absoluteUri);
                                webReq.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                                if (null != credentials)
                                    webReq.Credentials = credentials;
                                WebResponse resp = webReq.GetResponse();
                                IoC.ResolveAll<Logging.ILog>().Log
                                    (
                                    Logging.LogCategory.XsdLocations | Logging.LogCategory.CachingInformation | Logging.LogCategory.TimingInformation,
                                    resp.IsFromCache ? absoluteUri + " loaded from HTTP cache" : absoluteUri + " downloaded"
                                    );
                                return resp.GetResponseStream();
                            }
                        }
                        else
                        {
                            IoC.ResolveAll<Logging.ILog>().Log
                                (
                                Logging.LogCategory.CachingInformation,
                                absoluteUri + " was downloaded as it was not deemed suitable for caching"
                                );
                        }
                    }
                    catch (Exception e)
                    {
                        IoC.ResolveAll<Logging.ILog>().Log
                            (
                            Logging.LogCategory.XsdLocations | Logging.LogCategory.Exceptions,
                            "Exception encountered when retrieving " + absoluteUri.ToString() + "(" + e.Message + ")"
                            );
                    }
                }
                // Possibly not an XSD so let's not risk it by caching it.
                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
        }
    }
}
