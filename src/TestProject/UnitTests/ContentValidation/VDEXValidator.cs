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
                        new UriSource(null, null)
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
            var validator = this.CreateValidator();
            validator.VDEXLocation = new Uri("http://www.xcri.co.uk/vocabularies/studyMode1_0.xml", UriKind.Absolute);
            validator.XPathSelector = "//@hello";
            try
            {
                var results = validator.Validate(System.Xml.Linq.XDocument.Parse("<root><hello hello=\"hello world\" /></root>").Root);
                Assert.IsTrue(results.Count() == 1);
                Assert.IsTrue(results.ElementAt(0).Instances.Count() == 1);
                Assert.IsTrue(this.SupportsAttributeXPathSelectors);
            }
            catch
            {
                Assert.IsTrue(false == this.SupportsAttributeXPathSelectors);
            }
        }

        [TestMethod]
        public override void SelectElement()
        {
            return;
            var validator = this.CreateValidator();
            validator.VDEXLocation = new Uri("http://www.xcri.co.uk/vocabularies/studyMode1_0.xml", UriKind.Absolute);
            validator.XPathSelector = "//hello";
            try
            {
                var results = validator.Validate(System.Xml.Linq.XDocument.Parse("<root><hello hello=\"hello world\" /></root>").Root);
                Assert.IsTrue(results.Count() == 1);
                Assert.IsTrue(results.ElementAt(0).Instances.Count() == 1);
                Assert.IsTrue(this.SupportsElementXPathSelectors);
            }
            catch
            {
                Assert.IsTrue(false == this.SupportsElementXPathSelectors);
            }
        }
    }
}
