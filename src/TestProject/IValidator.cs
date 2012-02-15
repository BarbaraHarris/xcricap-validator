using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public abstract class IValidator<T> : TestBase<XCRI.Validation.ContentValidation.IValidator, T>
        where T : XCRI.Validation.ContentValidation.IValidator
    {
        public bool SupportsAttributeXPathSelectors { get; set; }
        public bool SupportsElementXPathSelectors { get; set; }
        public IValidator()
            : base()
        {
            this.SupportsAttributeXPathSelectors = true;
            this.SupportsElementXPathSelectors = true;
        }

        public abstract T CreateValidator();

        [TestMethod]
        public virtual void SelectAttribute()
        {
            T validator = this.CreateValidator();
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
        public virtual void SelectElement()
        {
            T validator = this.CreateValidator();
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
