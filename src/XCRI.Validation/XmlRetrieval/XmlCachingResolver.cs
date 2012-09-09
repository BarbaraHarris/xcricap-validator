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
        public Logging.ILog Log { get; protected set; }

        public XmlCachingResolver
            (
            IEnumerable<IXmlCacheLocation> cacheLocations,
            Logging.ILog log
            )
        {
            this.BypassCache = false;
            if (null != cacheLocations)
                this.CacheLocations = new List<IXmlCacheLocation>(cacheLocations);
            else
                this.CacheLocations = new List<IXmlCacheLocation>();
            this.Log = log;
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
                this.Log.LogMessageStatic
                    (
                    "Bypassing cache for " + absoluteUri
                    );
                return base.GetEntity(absoluteUri, role, ofObjectToReturn);
            }
            using (this.Log.StepStatic("Retrieving " + absoluteUri.ToString()))
            {
                this.Log.LogMessageStatic
                    (
                    "Attempting to load " + absoluteUri + " (using credentials: " + (null == this.credentials ? "no" : "yes") + ")"
                    );
                if (
                    absoluteUri.ToString().ToLower().EndsWith(".xsd") 
                    ||
                    (absoluteUri.ToString().ToLower().EndsWith(".xml") && (absoluteUri.Host.ToLower() == "www.xcri.co.uk" || absoluteUri.Host.ToLower() == "xcri.co.uk"))
                    )
                {
                    if (null != this.CacheLocations)
                    {
                        using (this.Log.StepStatic(String.Format
                            (
                            "Checking cache ({0} location{1})",
                            this.CacheLocations.Count,
                            this.CacheLocations.Count == 1 ? String.Empty : "s"
                            )))
                        {
                            foreach (var cl in this.CacheLocations)
                            {
                                var fs = cl.RetrieveCache(absoluteUri);
                                if (null != fs)
                                {
                                    this.Log.LogMessageStatic
                                        (
                                        absoluteUri.ToString() + " loaded from cache"
                                        );
                                    return fs;
                                }
                            }
                            this.Log.LogMessageStatic
                                (
                                "No suitable cache found"
                                );
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
                            using (this.Log.StepStatic("Downloading file"))
                            {
                                WebRequest webReq = WebRequest.Create(absoluteUri);
                                webReq.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.CacheIfAvailable);
                                if (null != credentials)
                                    webReq.Credentials = credentials;
                                WebResponse resp = webReq.GetResponse();
                                this.Log.LogMessageStatic
                                    (
                                    resp.IsFromCache ? absoluteUri + " loaded from HTTP cache" : absoluteUri + " downloaded"
                                    );
                                return resp.GetResponseStream();
                            }
                        }
                        else
                        {
                            this.Log.LogMessageStatic
                                (
                                absoluteUri + " was downloaded as it was not deemed suitable for caching"
                                );
                        }
                    }
                    catch (Exception e)
                    {
                        this.Log.LogMessageStatic
                            (
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
