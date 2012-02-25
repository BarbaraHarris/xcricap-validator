using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Validation.XmlExceptionInterpretation;

namespace TestProject.XmlValidationTests.XmlExceptionInterpretation
{
    [TestClass]
    public class InvalidChildElementInterpretation
    {
        [TestMethod]
        public void Invalid_IncorrectElementCapitalisation()
        {
            var interpreter = new XCRI.Validation.XmlExceptionInterpretation.InvalidChildElementInterpreter();
            System.Xml.Linq.XElement furtherInformation;
            string updatedMessage = String.Empty;
            string standardMessage = @"The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'Description' in namespace 'http://purl.org/dc/elements/1.1/'. List of possible elements expected: 'hasPart' in namespace 'http://purl.org/net/mlo' as well as 'contributor' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'contributor' in namespace 'http://purl.org/dc/terms/' as well as 'date' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'date, created, valid, available, issued, modified, dateAccepted, dateCopyrighted, dateSubmitted' in namespace 'http://purl.org/dc/terms/' as well as 'description' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'description, tableOfContents, abstract' in namespace 'http://purl.org/dc/terms/' as well as 'identifier' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'identifier, bibliographicCitation' in namespace 'http://purl.org/dc/terms/' as well as 'image' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'subject' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'subject' in namespace 'http://purl.org/dc/terms/' as well as 'title' in namespace 'http://purl.org/dc/elements/1.1/'.";
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                interpreter.Interpret(new Exception(standardMessage), out furtherInformation, ref updatedMessage)
                );
            Assert.AreNotEqual<string>(standardMessage, updatedMessage, "The message returned was not interpreted.");
            Assert.AreEqual<string>("The element 'Description' should be capitalised as 'description'.", updatedMessage, "The message returned was unexpected.");
        }
        [TestMethod]
        public void Invalid_IncorrectElementNamespace()
        {
            var interpreter = new XCRI.Validation.XmlExceptionInterpretation.InvalidChildElementInterpreter();
            System.Xml.Linq.XElement furtherInformation;
            string updatedMessage = String.Empty;
            string standardMessage = @"The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'description' in namespace 'http://xcri.org/profiles/1.2/catalog'. List of possible elements expected: 'hasPart' in namespace 'http://purl.org/net/mlo' as well as 'contributor' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'contributor' in namespace 'http://purl.org/dc/terms/' as well as 'date' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'date, created, valid, available, issued, modified, dateAccepted, dateCopyrighted, dateSubmitted' in namespace 'http://purl.org/dc/terms/' as well as 'description' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'description, tableOfContents, abstract' in namespace 'http://purl.org/dc/terms/' as well as 'identifier' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'identifier, bibliographicCitation' in namespace 'http://purl.org/dc/terms/' as well as 'image' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'subject' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'subject' in namespace 'http://purl.org/dc/terms/' as well as 'title' in namespace 'http://purl.org/dc/elements/1.1/'.";
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                interpreter.Interpret(new Exception(standardMessage), out furtherInformation, ref updatedMessage)
                );
            Assert.AreNotEqual<string>(standardMessage, updatedMessage, "The message returned was not interpreted.");
            Assert.AreEqual<string>("The element 'description' should be in namespace 'http://purl.org/dc/elements/1.1/', not 'http://xcri.org/profiles/1.2/catalog'.", updatedMessage, "The message returned was unexpected.");
        }
    }
}
