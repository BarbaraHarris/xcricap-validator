using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace XCRI.Validation.XmlRetrieval
{
    public class XmlDiskCacheLocation : IXmlCacheLocation
    {

        /// <summary>
        /// The directory the cache will be loaded from / saved to.
        /// </summary>
        public System.IO.DirectoryInfo Directory { get; set; }

        public XmlDiskCacheLocation(System.IO.DirectoryInfo directory)
        {
            if (null == directory)
                throw new ArgumentNullException("directory");
            if (false == directory.Exists)
                throw new ArgumentException("The directory must already exist", "directory");
            this.Directory = directory;
        }

        protected FileInfo GetCachedFileInfo(Uri absoluteUri)
        {
            string cache = GetMd5Sum(absoluteUri.ToString().ToLower()) + ".cache";
            FileInfo[] cachedFiles = this.Directory.GetFiles(cache);
            if (cachedFiles.Length == 0)
                return null;
            return cachedFiles[0];
        }

        #region IXmlCacheLocation Members

        public bool ContainsCache(Uri absoluteUri)
        {
            string cache = GetMd5Sum(absoluteUri.ToString().ToLower()) + ".cache";
            FileInfo[] cachedFiles = this.Directory.GetFiles(cache);
            return cachedFiles.Length != 0;
        }

        public System.IO.FileStream RetrieveCache(Uri absoluteUri)
        {
            FileInfo fi = this.GetCachedFileInfo(absoluteUri);
            if (
                null == fi
                ||
                false == fi.Exists
                )
            {
#if DEBUG
                System.Diagnostics.Debug.WriteLine("Cache for " + absoluteUri.ToString() + " not found at " + GetMd5Sum(absoluteUri.ToString().ToLower()) + ".cache");
#endif
                return null;
            }
            return new FileStream(fi.FullName, FileMode.Open, FileAccess.Read);
        }

        public void SaveCache(Uri absoluteUri, string contents)
        {
            throw new NotImplementedException();
        }

        #endregion

        static public string GetMd5Sum(string str)
        {
            // First we need to convert the string into bytes, which
            // means using a text encoder.
            Encoder enc = System.Text.Encoding.Unicode.GetEncoder();

            // Create a buffer large enough to hold the string
            byte[] unicodeText = new byte[str.Length * 2];
            enc.GetBytes(str.ToCharArray(), 0, str.Length, unicodeText, 0, true);

            // Now that we have a byte array we can ask the CSP to hash it
            using (MD5 md5 = new MD5CryptoServiceProvider())
            {
                byte[] result = md5.ComputeHash(unicodeText);
                // Build the final string by converting each byte
                // into hex and appending it to a StringBuilder
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < result.Length; i++)
                {
                    sb.Append(result[i].ToString("X2"));
                }
                // And return it
                return sb.ToString();
            }
        }

    }
}
