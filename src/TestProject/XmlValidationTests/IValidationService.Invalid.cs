using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests
{
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService<String>, T>
        where T : XCRI.Validation.IValidationService<String>
    {

        #region Formatting

        [TestMethod]
        public void Invalid_Formatting_GeneratedAttribute()
        {
            string toValidate = Resources.IValidationService.Invalid.Formatting.GeneratedAttribute;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                if (false == (exception is System.Xml.Schema.XmlSchemaException))
                    Assert.Fail("Expected System.Xml.Schema.XmlSchemaException");
                System.Xml.Schema.XmlSchemaException e = exception as System.Xml.Schema.XmlSchemaException;
                if (e.LineNumber != 6)
                    Assert.Fail("This test should fail on line 6");
                if (e.LinePosition != 3)
                    Assert.Fail("This test should fail at line position 3");
                Assert.IsTrue
                    (
                    exception.Message == "The 'generated' attribute is invalid - The value '2011-03-21 20:00:23' is invalid according to its datatype 'http://www.w3.org/2001/XMLSchema:dateTime' - The string '2011-03-21 20:00:23' is not a valid DateTime value.",
                    "Exception expected to complain about description missing namespace"
                    );
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        #endregion

        #region Namespaces

        [TestMethod]
        public void Invalid_Namespaces_UndeclaredPrefix()
        {
            string toValidate = Resources.IValidationService.Invalid.Namespaces.UndeclaredPrefix;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                if (false == (exception is System.Xml.XmlException))
                    Assert.Fail("Expected System.Xml.XmlException");
                System.Xml.XmlException e = exception as System.Xml.XmlException;
                if (e.LineNumber != 6)
                    Assert.Fail("This test should fail on line 6");
                if (e.LinePosition != 6)
                    Assert.Fail("This test should fail at line position 6");
                Assert.IsTrue
                    (
                    exception.Message == "'dc' is an undeclared prefix. Line 6, position 6.",
                    "Exception expected to complain about schema information missing for root catalog element"
                    );
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        public void Invalid_Namespaces_NoDocumentNamespace()
        {
            string toValidate = Resources.IValidationService.Invalid.Namespaces.NoDocumentNamespace;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                if (false == (exception is System.Xml.Schema.XmlSchemaException))
                    Assert.Fail("Expected System.Xml.Schema.XmlSchemaException");
                System.Xml.Schema.XmlSchemaException e = exception as System.Xml.Schema.XmlSchemaException;
                if (e.LineNumber != 2)
                    Assert.Fail("This test should fail on line 2");
                if (e.LinePosition != 2)
                    Assert.Fail("This test should fail at line position 2");
                Assert.IsTrue
                    (
                    exception.Message == "Could not find schema information for the element 'catalog'.",
                    "Exception expected to complain about schema information missing for root catalog element"
                    );
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        public void Invalid_Namespaces_Description()
        {
            string toValidate = Resources.IValidationService.Invalid.Namespaces.Description;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                if (false == (exception is System.Xml.Schema.XmlSchemaException))
                    Assert.Fail("Expected System.Xml.Schema.XmlSchemaException");
                System.Xml.Schema.XmlSchemaException e = exception as System.Xml.Schema.XmlSchemaException;
                if (e.LineNumber != 15)
                    Assert.Fail("This test should fail on line 15");
                if (e.LinePosition != 6)
                    Assert.Fail("This test should fail at line position 6");
                Assert.IsTrue
                    (
                    exception.Message.StartsWith("The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'description' in namespace 'http://xcri.org/profiles/1.2/catalog'"),
                    "Exception expected to complain about description missing namespace"
                    );
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        public void Invalid_Namespaces_Title()
        {
            string toValidate = Resources.IValidationService.Invalid.Namespaces.Title;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                if (false == (exception is System.Xml.Schema.XmlSchemaException))
                    Assert.Fail("Expected System.Xml.Schema.XmlSchemaException");
                System.Xml.Schema.XmlSchemaException e = exception as System.Xml.Schema.XmlSchemaException;
                if (e.LineNumber != 15)
                    Assert.Fail("This test should fail on line 15");
                if (e.LinePosition != 6)
                    Assert.Fail("This test should fail at line position 6");
                Assert.IsTrue
                    (
                    exception.Message.StartsWith("The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'title' in namespace 'http://xcri.org/profiles/1.2/catalog'"),
                    "Exception expected to complain about title missing namespace"
                    );
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        public void Invalid_Namespaces_Identifier()
        {
            string toValidate = Resources.IValidationService.Invalid.Namespaces.Identifier;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                if (false == (exception is System.Xml.Schema.XmlSchemaException))
                    Assert.Fail("Expected System.Xml.Schema.XmlSchemaException");
                System.Xml.Schema.XmlSchemaException e = exception as System.Xml.Schema.XmlSchemaException;
                if (e.LineNumber != 15)
                    Assert.Fail("This test should fail on line 15");
                if (e.LinePosition != 6)
                    Assert.Fail("This test should fail at line position 6");
                Assert.IsTrue
                    (
                    e.Message.StartsWith("The element 'provider' in namespace 'http://xcri.org/profiles/1.2/catalog' has invalid child element 'identifier' in namespace 'http://xcri.org/profiles/1.2/catalog'"),
                    "Exception expected to complain about identifier missing namespace"
                    );
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        #endregion

        #region Structure

        [TestMethod]
        public void Invalid_Structure_XmlNesting()
        {
            string toValidate = Resources.IValidationService.Invalid.Structure.XmlNesting;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                if (false == (exception is System.Xml.XmlException))
                    Assert.Fail("Expected System.Xml.XmlException");
                System.Xml.XmlException e = exception as System.Xml.XmlException;
                if (e.LineNumber != 7)
                    Assert.Fail("This test should fail on line 7");
                if (e.LinePosition != 5)
                    Assert.Fail("This test should fail at line position 5");
                Assert.IsTrue
                    (
                    e.Message == "The 'provider' start tag on line 5 position 4 does not match the end tag of 'catalog'. Line 7, position 5.",
                    "The test should faul because of incorrect tag nesting"
                    );
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");

        }

        #endregion

    }
}
