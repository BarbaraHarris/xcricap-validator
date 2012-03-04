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
        public void Invalid_Credit_WithoutScheme()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Credits.WithoutScheme).Root)
                .Where(r => r.Message == "Unless a default value has been agreed between the aggregator and producer, each credit element should contain a scheme element. Multiple scheme elements are not allowed.");
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: XCRI.Validation.ContentValidation.ValidationStatus.Warning,
                expectedInstances: 1,
                expectedFailedCount: 1,
                expectedSuccessfulCount: 0
                );
        }

        [TestMethod]
        public void Invalid_Credit_WithoutLevel()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Credits.WithoutLevel).Root)
                .Where(r => r.Message == "A credit element must contain a level element.");
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
        public void Invalid_Credit_WithoutValue()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Credits.WithoutValue).Root)
                .Where(r => r.Message == "A credit element must contain a value element.");
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
