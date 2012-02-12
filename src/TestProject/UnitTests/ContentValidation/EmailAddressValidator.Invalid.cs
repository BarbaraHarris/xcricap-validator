using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class EmailAddressValidator
    {
        [TestMethod]
        public void NoAt()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "helloworld"
                ));
        }
        [TestMethod]
        public void UrlInsteadOfAddress()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "http://www.blah.com"
                ));
        }
        [TestMethod]
        public void UrlInsteadOfAddressWithAtSign()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "http://hello:world@www.blah.com"
                ));
        }
    }
}
