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

        protected XCRI.Validation.ContentValidation.ElementValidator GetElementValidator_Course()
        {
            var elementValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                NamespaceManager = this.GetNamespaceManager(),
                XPathSelector = "//xcri12:course"
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

    }
}
