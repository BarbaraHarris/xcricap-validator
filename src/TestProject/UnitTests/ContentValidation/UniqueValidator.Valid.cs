using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.UnitTests.ContentValidation
{
    public partial class UniqueValidator : IValidator<XCRI.Validation.ContentValidation.UniqueValidator>
    {
        [TestMethod]
        public void Valid_UniqueAcrossDocument()
        {
            var xDocument =
                new XDocument(new XElement("Root",
                    new XElement("test", "abc"),
                    new XElement("test", "def")
                ));
            Assert.IsTrue(this.PassesValidation
                (
                xDocument.Root.Elements("test").ElementAt(0),
                "//test",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Document
                ), "The test document contains two elements that are unique across the document");
        }
        [TestMethod]
        public void Valid_UniqueAcrossContext_1()
        {
            var xDocument =
                new XDocument(new XElement("Root",
                    new XElement("test", "abc"),
                    new XElement("test", "def")
                ));
            Assert.IsTrue(this.PassesValidation
                (
                xDocument.Root.Elements("test").ElementAt(0),
                "//test",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context
                ), "The test document contains two elements that are unique across the context");
        }
        [TestMethod]
        public void Valid_UniqueAcrossContext_2()
        {
            var xDocument = new XDocument(new XElement("Root"));
            xDocument.Root.Add(new XElement("course", new XElement("identifier", "hello")));
            xDocument.Root.Add(new XElement("provider", new XElement("identifier", "hello")));
            Assert.IsTrue(this.PassesValidation
                (
                xDocument.Root.Elements("course").ElementAt(0).Elements("identifier").ElementAt(0),
                "//identifier",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context
                ), "The test document contains two elements that are unique across the context");
        }
    }
}
