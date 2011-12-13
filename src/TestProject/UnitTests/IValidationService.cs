using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests
{
    [TestClass]
    public abstract class IValidationService<T> : TestBase<XCRI.Validation.IValidationService<Uri>, T>
        where T : XCRI.Validation.IValidationService<Uri>
    {

    }
}
