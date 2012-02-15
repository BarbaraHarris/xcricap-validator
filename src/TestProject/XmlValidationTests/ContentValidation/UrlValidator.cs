﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests.ContentValidation
{
    [TestClass]
    public partial class UrlValidator : IValidator<XCRI.Validation.ContentValidation.UrlValidator>
    {
        public override XCRI.Validation.ContentValidation.UrlValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.UrlValidator();
        }
    }
}
