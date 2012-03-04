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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Credit()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//mlo:credit"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_Credit_WithScheme()
        {
            var elementValidator = this.GetElementValidator_Credit();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./credit:scheme)",
                ExceptionMessage = "Unless a default value has been agreed between the aggregator and producer, each credit element should contain a scheme element. Multiple scheme elements are not allowed.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Credits.WithScheme).Root)
                .Where(r => r.Message == "Unless a default value has been agreed between the aggregator and producer, each credit element should contain a scheme element. Multiple scheme elements are not allowed.");
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

        [TestMethod]
        public void Valid_Credit_WithLevel()
        {
            var elementValidator = this.GetElementValidator_Credit();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./credit:level)",
                ExceptionMessage = "A credit element must contain a level element.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Credits.WithLevel).Root)
                .Where(r => r.Message == "A credit element must contain a level element.");
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

        [TestMethod]
        public void Valid_Credit_WithValue()
        {
            var elementValidator = this.GetElementValidator_Credit();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./credit:value)",
                ExceptionMessage = "A credit element must contain a value element.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Credits.WithValue).Root)
                .Where(r => r.Message == elementValidator.Validators[0].ExceptionMessage);
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
