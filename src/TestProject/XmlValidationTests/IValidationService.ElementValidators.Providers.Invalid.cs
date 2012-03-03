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
        public void Invalid_ProviderWithNoCoursesUnderCatalog()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithNoCoursesUnderCatalog).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithIdentifierWithXsiType()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithIdentifierWithXsiType).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutIdentifier()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutIdentifier).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutTitle()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestTitleExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutTitle).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutUrl()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestUrlExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutUrl).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutLocation()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestLocationExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutLocation).Root,
                1,
                0
                );
        }

        [TestMethod]
        public void Invalid_ProviderWithoutCourse()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Invalid.ElementValidation.Providers.WithoutCourse).Root,
                1,
                0
                );
        }

    }
}
