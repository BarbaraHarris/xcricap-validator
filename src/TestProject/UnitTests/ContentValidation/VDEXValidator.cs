using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Validation.XmlRetrieval;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class VDEXValidator : IValidator<XCRI.Validation.ContentValidation.VDEXValidator>
    {
        protected System.Xml.XmlNamespaceManager GetNamespaceManager()
        {
            var xmlnsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            xmlnsmgr.AddNamespace("mlo", "http://purl.org/net/mlo");
            xmlnsmgr.AddNamespace("xcri12", "http://xcri.org/profiles/1.2/catalog");
            xmlnsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            xmlnsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlnsmgr.AddNamespace("credit", "http://purl.org/net/cm");
            xmlnsmgr.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");
            xmlnsmgr.AddNamespace("courseDataProgramme", "http://xcri.co.uk");
            return xmlnsmgr;
        }
        public VDEXValidator()
            : base()
        {
            this.SupportsAttributeXPathSelectors = false;
        }
        public override XCRI.Validation.ContentValidation.VDEXValidator CreateValidator()
        {
            throw new NotImplementedException();
        }
        private object _lock = new object();
        protected Dictionary<Uri, XCRI.Validation.ContentValidation.VDEXValidator> CachedValidators = new Dictionary<Uri, XCRI.Validation.ContentValidation.VDEXValidator>();
        public XCRI.Validation.ContentValidation.VDEXValidator CreateValidator(Uri vdexLocation)
        {
            if (false == this.CachedValidators.ContainsKey(vdexLocation))
            {
                lock (this._lock)
                {
                    if(false == this.CachedValidators.ContainsKey(vdexLocation))
                        this.CachedValidators.Add(vdexLocation, new XCRI.Validation.ContentValidation.VDEXValidator
                        (
                        new UriFromResourceSource()
                        )
                        {
                            VDEXLocation = vdexLocation
                        });
                }
            }
            return this.CachedValidators[vdexLocation];
        }

        public bool IsValidIdentifier
            (
            Uri vdexLocation,
            string identifier
            )
        {
            var validator = this.CreateValidator(vdexLocation);
            return validator.IsValidIdentifier(identifier);
        }
        public bool IsValidElementValue
            (
            Uri vdexLocation,
            string value
            )
        {
            var validator = this.CreateValidator(vdexLocation);
            return validator.IsValidElementValue(value);
        }

        [TestMethod]
        public override void SelectAttribute()
        {
            return;
        }

        [TestMethod]
        public override void SelectElement()
        {
            return;
        }
        public class UriFromResourceSource : SourceBase<Uri>
        {
            public UriFromResourceSource()
                : base(null, null)
            {
            }
            public override System.Xml.XmlReader GetXmlReader(Uri input)
            {
                string hashName = "VDEX_" + Hashing.HashUri(input);
                return System.Xml.XmlReader.Create(new System.IO.StringReader(Resources.ContentValidation.VDEXFiles.ResourceManager.GetString(hashName)));
            }
		
        }

    }
}
