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

    }
}
