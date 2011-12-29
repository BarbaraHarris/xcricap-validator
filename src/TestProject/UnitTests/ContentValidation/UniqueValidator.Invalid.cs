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
        public void Invalid_SingleNotUnique()
        {
            var xDocument = new XDocument(new XElement("Root",
                    new XElement("test", "abc"),
                    new XElement("test", "abc"),
                    new XElement("test", "def")
                ));
            Assert.IsFalse(this.PassesValidation
                (
                xDocument.Root,
                "//test",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Document
                ), "The supplied document contains two elements which are not unique");
        }
        /// <summary>
        /// All XElements passed into this type of validator need to be associated with an XDocument
        /// </summary>
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Invalid_AllUnique_NoXDocument()
        {
            this.PassesValidation
                (
                new XElement("Root",
                    new XElement("test", "abc"),
                    new XElement("test", "def")
                ),
                "//test",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Document
                );
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Invalid_SingleNotUnique_NoXDocument()
        {
            this.PassesValidation
                (
                new XElement("Root",
                    new XElement("test", "abc"),
                    new XElement("test", "abc"),
                    new XElement("test", "def")
                ),
                "//test",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Document
                );
        }
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public void Invalid_NullXElement()
        {
            this.PassesValidation
                (
                null,
                "//test",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Document
                );
        }
        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void Invalid_SingleNotUnique_NoXDocument_UniqueTypeContext()
        {
            this.PassesValidation
                (
                new XElement("Root",
                    new XElement("test", "abc"),
                    new XElement("test", "abc"),
                    new XElement("test", "def")
                ),
                "//test",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context
                );
        }
        [TestMethod]
        public void Invalid_UniqueAcrossDocument()
        {
            var xDocument = new XDocument(new XElement("Root"));
            xDocument.Root.Add(new XElement("course", new XElement("identifier", "hello")));
            xDocument.Root.Add(new XElement("provider", new XElement("identifier", "hello")));
            Assert.IsFalse(this.PassesValidation
                (
                xDocument.Root.Elements("course").ElementAt(0).Elements("identifier").ElementAt(0),
                "//identifier",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Document
                ), "The test document contains two elements that are unique across the context but not unique across the document");
        }
        [TestMethod]
        public void Invalid_UniqueAcrossContext()
        {
            var xDocument = new XDocument(new XElement("Root"));
            xDocument.Root.Add(new XElement("course", new XElement("identifier", "hello")));
            xDocument.Root.Add(new XElement("provider", new XElement("identifier", "world")));
            xDocument.Root.Add(new XElement("provider", new XElement("identifier", "world")));
            Assert.IsFalse(this.PassesValidation
                (
                xDocument.Root.Elements("provider").ElementAt(0).Elements("identifier").ElementAt(0),
                "//identifier",
                XCRI.Validation.ContentValidation.UniqueValidator.UniqueAcrossTypes.Context
                ), "The test document contains two elements that are unique across the context but not unique across the document");
        }
    }
}
