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
        public void Invalid_Location_WithoutPostcode()
        {
            var elementValidator = this.GetElementValidator_Locations();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:postcode)",
                ExceptionMessage = "An XCRI provider's location must contain one postcode element.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Locations.WithoutPostcode).Root)
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
        public void Invalid_Location_WithoutAddress()
        {
            var elementValidator = this.GetElementValidator_Locations();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:address)",
                ExceptionMessage = "An XCRI provider's location must contain at least one address element.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Locations.WithoutAddress).Root)
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
        public void Invalid_Location_WithoutPhone()
        {
            var elementValidator = this.GetElementValidator_Locations();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:phone)",
                ExceptionMessage = "An XCRI provider's location must contain one phone element.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Locations.WithoutPhone).Root)
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
        public void Invalid_Location_WithoutEmail()
        {
            var elementValidator = this.GetElementValidator_Locations();
            elementValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:email)",
                ExceptionMessage = "An XCRI provider's location should contain one email element.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                Maximum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = elementValidator.NamespaceManager
            });
            var vr = elementValidator
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Locations.WithoutEmail).Root)
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
