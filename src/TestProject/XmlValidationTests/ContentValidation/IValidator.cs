using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests.ContentValidation
{
    [TestClass]
    public abstract class IValidator<T> : TestBase<XCRI.Validation.ContentValidation.IValidator, T>
        where T : XCRI.Validation.ContentValidation.IValidator
    {
    }
}
