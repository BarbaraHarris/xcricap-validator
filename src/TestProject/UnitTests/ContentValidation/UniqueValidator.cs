using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    [TestClass]
    public partial class UniqueValidator : IValidator<XCRI.Validation.ContentValidation.UniqueValidator>
    {
        protected bool PassesValidation
            (
            XElement input,
            string selector,
            XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes unique
            )
        {
            string details = null;
            return this.PassesValidation(input, selector, unique, out details);
        }
        protected bool PassesValidation
            (
            XElement input, 
            string selector, 
            XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes unique,
            out string details
            )
        {
            var v = new XCRI.Validation.ContentValidation.UniqueValidator
                (
                null,
                null,
                selector,
                String.Empty,
                XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                null,
                null
                );
            v.UniqueAcross = unique;
            return v.PassesValidation(input, out details);
        }
    }
}
