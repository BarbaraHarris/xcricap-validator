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

        #region Namespaces

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Valid\Namespaces\Description.xml",
            @"IValidationService\Valid\Namespaces\"
            )]
        public void Valid_Namespaces_Description()
        {
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Namespaces\Description.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");
        }

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Valid\Namespaces\Title.xml",
            @"IValidationService\Valid\Namespaces\"
            )]
        public void Valid_Namespaces_Title()
        {
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Namespaces\Title.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");
        }

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Valid\Namespaces\Identifier.xml",
            @"IValidationService\Valid\Namespaces\"
            )]
        public void Valid_Namespaces_Identifier()
        {
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Namespaces\Identifier.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");
        }

        #endregion

        #region Structure

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Valid\Structure\BasicCatalog.xml",
            @"IValidationService\Valid\Structure\"
            )]
        public void Valid_Structure_BasicCatalog()
        {
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The BasicCatalog.xml file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Structure\BasicCatalog.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }

        [TestMethod]
        [DeploymentItem
            (
            @"TestProject\Resources\IValidationService\Valid\Structure\OfficialTestFromSchemas.xml",
            @"IValidationService\Valid\Structure\"
            )]
        public void Valid_Structure_OfficialTestFromSchemas()
        {
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The OfficialTestFromSchemas.xml file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.UriSource(null, this.XmlResolver);
            var results = t.Validate(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Structure\OfficialTestFromSchemas.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }

        #endregion

    }
}
