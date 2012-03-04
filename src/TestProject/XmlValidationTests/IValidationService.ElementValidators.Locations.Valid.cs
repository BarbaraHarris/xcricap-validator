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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Locations()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:provider/mlo:location"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_Location_WithPostcode()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Locations.WithPostcode).Root)
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

        [TestMethod]
        public void Valid_Location_WithAddress()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Locations.WithAddress).Root)
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

        [TestMethod]
        public void Valid_Location_WithPhone()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Locations.WithPhone).Root)
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

        [TestMethod]
        public void Valid_Location_WithEmail()
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
                .Validate(System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Locations.WithEmail).Root)
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
