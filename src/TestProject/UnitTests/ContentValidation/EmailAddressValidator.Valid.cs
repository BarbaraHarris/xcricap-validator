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
        public void Address1()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "hello.world@domain.com"
                ));
        }
        [TestMethod]
        public void Address2()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "helloworld@domain.com"
                ));
        }
        [TestMethod]
        public void Address3()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "helloworld@domain.co.uk"
                ));
        }
        [TestMethod]
        public void Address4()
        {
            Assert.IsTrue(this.PassesValidationString
                (
                "hello.world@domain.co.uk"
                ));
        }
    }
}
