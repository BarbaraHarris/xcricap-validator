using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Validation.XmlExceptionInterpretation;
using System.Xml.Linq;

namespace TestProject.UnitTests.XmlExceptionInterpretation
{
    [TestClass]
    public class InvalidChildElementInterpreter : IInterpreter<XCRI.Validation.XmlExceptionInterpretation.InvalidChildElementInterpreter>
    {
        [TestMethod]
        public void Matches_IdentifierInIncorrectNamespace()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'identifier' in namespace 'http://xcri.org/profiles/1.2/catalog'. List of possible elements expected: 'hasPart' in namespace 'http://purl.org/net/mlo' as well as 'contributor' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'contributor' in namespace 'http://purl.org/dc/terms/' as well as 'date' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'date, created, valid, available, issued, modified, dateAccepted, dateCopyrighted, dateSubmitted' in namespace 'http://purl.org/dc/terms/' as well as 'description' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'description, tableOfContents, abstract' in namespace 'http://purl.org/dc/terms/' as well as 'identifier' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'identifier, bibliographicCitation' in namespace 'http://purl.org/dc/terms/' as well as 'image' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'subject' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'subject' in namespace 'http://purl.org/dc/terms/' as well as 'title' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'title, alt....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                @"The element 'identifier' should be in namespace 'http://purl.org/dc/elements/1.1/', not 'http://xcri.org/profiles/1.2/catalog'.",
                message
                );
        }
        [TestMethod]
        public void Matches_IdentifierIncorrectCasing()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'IDENTifier' in namespace 'http://purl.org/dc/elements/1.1/'. List of possible elements expected: 'hasPart' in namespace 'http://purl.org/net/mlo' as well as 'contributor' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'contributor' in namespace 'http://purl.org/dc/terms/' as well as 'date' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'date, created, valid, available, issued, modified, dateAccepted, dateCopyrighted, dateSubmitted' in namespace 'http://purl.org/dc/terms/' as well as 'description' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'description, tableOfContents, abstract' in namespace 'http://purl.org/dc/terms/' as well as 'identifier' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'identifier, bibliographicCitation' in namespace 'http://purl.org/dc/terms/' as well as 'image' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'subject' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'subject' in namespace 'http://purl.org/dc/terms/' as well as 'title' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'title, alt....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                @"The element 'IDENTifier' should be capitalised as 'identifier'.",
                message
                );
        }
        [TestMethod]
        public void Matches_TitleIncorrectOrderUnderProvider()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'identifier' in namespace 'http://purl.org/dc/elements/1.1/'. List of possible elements expected: 'title' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'title, alternative' in namespace 'http://purl.org/dc/terms/' as well as 'type' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'type' in namespace 'http://purl.org/dc/terms/' as well as 'url' in namespace 'http://purl.org/net/mlo' as well as 'course' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'location' in namespace 'http://purl.org/net/mlo'.");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                @"The 'provider' element contains elements that are in the wrong order.",
                message
                );
        }
        [TestMethod]
        public void Matches_DescriptionIncorrectOrderUnderCourse()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'course' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'description' in namespace 'http://purl.org/dc/elements/1.1/'. List of possible elements expected: 'identifier' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'identifier, bibliographicCitation' in namespace 'http://purl.org/dc/terms/' as well as 'image' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'subject' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'subject' in namespace 'http://purl.org/dc/terms/' as well as 'title' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'title, alternative' in namespace 'http://purl.org/dc/terms/' as well as 'type' in namespace 'http://purl.org/dc/elements/1.1/' as well as 'type' in namespace 'http://purl.org/dc/terms/' as well as 'url' in namespace 'http://purl.org/net/mlo' as well as 'abstract, applicationProcedure' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'assessment' in namespace 'http://purl.org/net/mlo' as well as 'learningOutcome' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'objective, prerequisite' in namespace 'http://purl.org/net/mlo' as well as 'regulations' in names....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                @"The 'course' element contains elements that are in the wrong order.",
                message
                );
        }
        [TestMethod]
        public void Matches_UrlIncorrectOrderUnderPresentation()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'presentation' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'title' in namespace 'http://purl.org/dc/elements/1.1/'. List of possible elements expected: 'abstract, applicationProcedure' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'assessment' in namespace 'http://purl.org/net/mlo' as well as 'learningOutcome' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'objective, prerequisite' in namespace 'http://purl.org/net/mlo' as well as 'regulations' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'start' in namespace 'http://purl.org/net/mlo' as well as 'end, startUntil, endFrom' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'duration' in namespace 'http://purl.org/net/mlo' as well as 'applyFrom, applyUntil, applyTo' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'engagement' in namespace 'http://purl.org/net/mlo' as well as 'studyMode, attendanceMode, attendancePattern' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'languageOfInstruction' in namespace 'http://purl.org/net/mlo' as well as 'languageOfAssessment' in namespace 'http://xcri.org/profiles/1.2/catalog' a....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                @"The 'presentation' element contains elements that are in the wrong order.",
                message
                );
        }
        [TestMethod]
        public void Matches_TitleIncorrectOrderUnderQualification()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'qualification' in namespace 'http://purl.org/net/mlo' has invalid child element 'title' in namespace 'http://purl.org/dc/elements/1.1/'. List of possible elements expected: 'abstract, applicationProcedure' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'assessment' in namespace 'http://purl.org/net/mlo' as well as 'learningOutcome' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'objective, prerequisite' in namespace 'http://purl.org/net/mlo' as well as 'regulations' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'start' in namespace 'http://purl.org/net/mlo' as well as 'end, startUntil, endFrom' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'duration' in namespace 'http://purl.org/net/mlo' as well as 'applyFrom, applyUntil, applyTo' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'engagement' in namespace 'http://purl.org/net/mlo' as well as 'studyMode, attendanceMode, attendancePattern' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'languageOfInstruction' in namespace 'http://purl.org/net/mlo' as well as 'languageOfAssessment' in namespace 'http://xcri.org/profiles/1.2/catalog' a....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                @"The 'qualification' element contains elements that are in the wrong order.",
                message
                );
        }
        [TestMethod]
        public void NotMatches_UnknownElementUnderQualification()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'qualification' in namespace 'http://purl.org/net/mlo' has invalid child element 'unknown' in namespace 'http://purl.org/dc/elements/1.1/'. List of possible elements expected: 'abstract, applicationProcedure' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'assessment' in namespace 'http://purl.org/net/mlo' as well as 'learningOutcome' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'objective, prerequisite' in namespace 'http://purl.org/net/mlo' as well as 'regulations' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'start' in namespace 'http://purl.org/net/mlo' as well as 'end, startUntil, endFrom' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'duration' in namespace 'http://purl.org/net/mlo' as well as 'applyFrom, applyUntil, applyTo' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'engagement' in namespace 'http://purl.org/net/mlo' as well as 'studyMode, attendanceMode, attendancePattern' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'languageOfInstruction' in namespace 'http://purl.org/net/mlo' as well as 'languageOfAssessment' in namespace 'http://xcri.org/profiles/1.2/catalog' a....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.NotInterpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                String.Empty,
                message
                );
        }
        [TestMethod]
        public void Matches_PostcodeIncorrectOrderUnderLocation()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'location' in namespace 'http://purl.org/net/mlo' has invalid child element 'postcode' in namespace 'http://purl.org/net/mlo'. List of possible elements expected: 'abstract, applicationProcedure' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'assessment' in namespace 'http://purl.org/net/mlo' as well as 'learningOutcome' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'objective, prerequisite' in namespace 'http://purl.org/net/mlo' as well as 'regulations' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'start' in namespace 'http://purl.org/net/mlo' as well as 'end, startUntil, endFrom' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'duration' in namespace 'http://purl.org/net/mlo' as well as 'applyFrom, applyUntil, applyTo' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'engagement' in namespace 'http://purl.org/net/mlo' as well as 'studyMode, attendanceMode, attendancePattern' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'languageOfInstruction' in namespace 'http://purl.org/net/mlo' as well as 'languageOfAssessment' in namespace 'http://xcri.org/profiles/1.2/catalog' a....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.Interpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                @"The 'location' element contains elements that are in the wrong order.",
                message
                );
        }
        [TestMethod]
        public void NotMatches_UnknownElementUnderLocation()
        {
            var t = base.Instantiate();
            var exception = new Exception(@"The element 'location' in namespace 'http://purl.org/net/mlo' has invalid child element 'unknown' in namespace 'http://purl.org/net/mlo'. List of possible elements expected: 'abstract, applicationProcedure' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'assessment' in namespace 'http://purl.org/net/mlo' as well as 'learningOutcome' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'objective, prerequisite' in namespace 'http://purl.org/net/mlo' as well as 'regulations' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'start' in namespace 'http://purl.org/net/mlo' as well as 'end, startUntil, endFrom' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'duration' in namespace 'http://purl.org/net/mlo' as well as 'applyFrom, applyUntil, applyTo' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'engagement' in namespace 'http://purl.org/net/mlo' as well as 'studyMode, attendanceMode, attendancePattern' in namespace 'http://xcri.org/profiles/1.2/catalog' as well as 'languageOfInstruction' in namespace 'http://purl.org/net/mlo' as well as 'languageOfAssessment' in namespace 'http://xcri.org/profiles/1.2/catalog' a....");
            string message = String.Empty;
            XElement throwaway = null;
            Assert.AreEqual<InterpretationStatus>
                (
                InterpretationStatus.NotInterpreted,
                t.Interpret(exception, out throwaway, ref message)
                );
            Assert.AreEqual<string>
                (
                String.Empty,
                message
                );
        }
    }
}
