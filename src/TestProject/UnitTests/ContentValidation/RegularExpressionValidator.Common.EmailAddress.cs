using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class RegularExpressionValidator
    {
        [TestMethod]
        public void EmailAddresses_Valid_1()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "hello.world@domain.com",
                Resources.ContentValidation.RegularExpressionValidator.Common.EmailAddress
                ));
        }
        [TestMethod]
        public void EmailAddresses_Valid_2()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "helloworld@domain.com",
                Resources.ContentValidation.RegularExpressionValidator.Common.EmailAddress
                ));
        }
        [TestMethod]
        public void EmailAddresses_Valid_3()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "helloworld@domain.co.uk",
                Resources.ContentValidation.RegularExpressionValidator.Common.EmailAddress
                ));
        }
        [TestMethod]
        public void EmailAddresses_Valid_4()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "hello.world@domain.co.uk",
                Resources.ContentValidation.RegularExpressionValidator.Common.EmailAddress
                ));
        }
        [TestMethod]
        public void EmailAddresses_Invalid_NoAt()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "helloworld",
                Resources.ContentValidation.RegularExpressionValidator.Common.EmailAddress
                ));
        }
        [TestMethod]
        public void EmailAddresses_Invalid_UrlInsteadOfAddress()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "http://www.blah.com",
                Resources.ContentValidation.RegularExpressionValidator.Common.EmailAddress
                ));
        }
        [TestMethod]
        public void EmailAddresses_Invalid_UrlInsteadOfAddressWithAtSign()
        {
            Assert.IsFalse(this.PassesValidationString
                (
                "http://hello:world@www.blah.com",
                Resources.ContentValidation.RegularExpressionValidator.Common.EmailAddress
                ));
        }
    }
}
