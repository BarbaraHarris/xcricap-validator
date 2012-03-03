using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests
{
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService<String>, T>
        where T : XCRI.Validation.IValidationService<String>
    {

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Category()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:catalog"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_Catalog_DescriptionUsed()
        {
            var elementValidator = this.GetElementValidator_Category();
            this.TestDescriptionExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Catalog.DescriptionUsed).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_Catalog_GeneratedAttributeIncluded()
        {
            var elementValidator = this.GetElementValidator_Category();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./@generated)",
                ExceptionMessage = "All catalogs must supply the date and time at which the catalog was generated",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Catalog.GeneratedAttributeUsed).Root)
                .Where(r => r.Message == "All catalogs must supply the date and time at which the catalog was generated");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Passed,
                expectedInstances: 1,
                expectedFailedCount: 0,
                expectedSuccessfulCount: 1
                );
        }

    }
}
