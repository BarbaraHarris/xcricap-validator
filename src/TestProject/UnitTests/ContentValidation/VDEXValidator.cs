using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Validation.XmlRetrieval;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class VDEXValidator : IValidator<XCRI.Validation.ContentValidation.VDEXValidator>
    {
        public override XCRI.Validation.ContentValidation.VDEXValidator CreateValidator()
        {
            throw new NotImplementedException();
            return new XCRI.Validation.ContentValidation.VDEXValidator(new UriSource(null, null));
        }
    }
}
