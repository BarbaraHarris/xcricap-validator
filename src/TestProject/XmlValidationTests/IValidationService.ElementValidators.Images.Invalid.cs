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


        [TestMethod]
        public void Invalid_ImageWithoutAltAttribute()
        {
            var elementValidator = this.GetElementValidator_Image();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "string-length(@alt)",
                ExceptionMessage = "A provider should provide meaningful alternative text for each image",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Accessibility",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Images.ImageWithoutAltAttribute).Root)
                .Where(r => r.Message == "A provider should provide meaningful alternative text for each image");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

    }
}
