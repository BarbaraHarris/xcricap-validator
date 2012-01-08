using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests
{
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService<Uri>, T>
        where T : XCRI.Validation.IValidationService<Uri>
    {

        #region Formatting

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Invalid\Formatting\GeneratedAttribute.xml",
            @"IValidationService\Invalid\Formatting\"
            )]
        public void Invalid_Formatting_GeneratedAttribute()
        {
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
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Invalid\Formatting\GeneratedAttribute.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        #endregion

        #region Namespaces

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Invalid\Namespaces\UndeclaredPrefix.xml",
            @"IValidationService\Invalid\Namespaces\"
            )]
        public void Invalid_Namespaces_UndeclaredPrefix()
        {
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
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Invalid\Namespaces\UndeclaredPrefix.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Invalid\Namespaces\NoDocumentNamespace.xml",
            @"IValidationService\Invalid\Namespaces\"
            )]
        public void Invalid_Namespaces_NoDocumentNamespace()
        {
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
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Invalid\Namespaces\NoDocumentNamespace.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Invalid\Namespaces\Description.xml",
            @"IValidationService\Invalid\Namespaces\"
            )]
        public void Invalid_Namespaces_Description()
        {
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
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Invalid\Namespaces\Description.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Invalid\Namespaces\Title.xml",
            @"IValidationService\Invalid\Namespaces\"
            )]
        public void Invalid_Namespaces_Title()
        {
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
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Invalid\Namespaces\Title.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Invalid\Namespaces\Identifier.xml",
            @"IValidationService\Invalid\Namespaces\"
            )]
        public void Invalid_Namespaces_Identifier()
        {
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
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Invalid\Namespaces\Identifier.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");
        }

        #endregion

        #region Structure

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Invalid\Structure\XmlNesting.xml",
            @"IValidationService\Invalid\Structure\"
            )]
        public void Invalid_Structure_XmlNesting()
        {
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
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Invalid\Structure\XmlNesting.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");

        }

        #endregion

    }
}
