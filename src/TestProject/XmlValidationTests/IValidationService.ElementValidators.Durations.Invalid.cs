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
        public void Invalid_Duration_Blank()
        {
            var elementValidator = this.GetElementValidator_Duration();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.DurationValidator()
            {
                XPathSelector = "@interval",
                ExceptionMessage = "The interval attribute must be a valid duration-only time interval as specified by ISO 8601.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Duration.WithIntervalBlank).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
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

        [TestMethod]
        public void Invalid_Duration_Various()
        {
            var elementValidator = this.GetElementValidator_Duration();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.DurationValidator()
            {
                XPathSelector = "@interval",
                ExceptionMessage = "The interval attribute must be a valid duration-only time interval as specified by ISO 8601.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Duration.WithIntervalVarious).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
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
