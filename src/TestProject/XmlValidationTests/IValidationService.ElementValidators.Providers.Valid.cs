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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Provider()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:provider[not(ancestor::xcri12:venue)]"
            };
            return elementValidator;
        }

        [TestMethod]
        public void Valid_ProviderWithNoCoursesUnderVenue()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithNoCoursesUnderVenue).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithIdentifierWithoutXsiType()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestIdentifierWithoutXsiTypeExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithIdentifierWithoutXsiType).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithTitle()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestTitleExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithTitle).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithUrl()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestUrlExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithUrl).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithLocation()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestLocationExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithLocation).Root,
                0,
                1
                );
        }

        [TestMethod]
        public void Valid_ProviderWithCourse()
        {
            var elementValidator = this.GetElementValidator_Provider();
            this.TestCourseExistsUnderElement
                (
                elementValidator,
                System.Xml.Linq.XDocument.Parse(Resources.IValidationService.Valid.ElementValidation.Providers.WithCourse).Root,
                0,
                1
                );
        }

    }
}
