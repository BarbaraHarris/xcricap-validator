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
        public UniqueValidator()
            : base()
        {
            this.SupportsAttributeXPathSelectors = false;
        }
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
            var v = this.CreateValidator();
            v.XPathSelector = selector;
            v.UniqueAcross = unique;
            return v.PassesValidation(input, out details);
        }

        public override XCRI.Validation.ContentValidation.UniqueValidator CreateValidator()
        {
            return new XCRI.Validation.ContentValidation.UniqueValidator();
        }
    }
}
