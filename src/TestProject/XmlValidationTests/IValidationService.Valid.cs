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

        #region Namespaces

        public void Valid_Namespaces_Description()
        {
            string toValidate = Resources.IValidationService.Valid.Namespaces.Description;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");
        }

        [TestMethod]
        public void Valid_Namespaces_Title()
        {
            string toValidate = Resources.IValidationService.Valid.Namespaces.Title;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");
        }

        [TestMethod]
        public void Valid_Namespaces_Identifier()
        {
            string toValidate = Resources.IValidationService.Valid.Namespaces.Identifier;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");
        }

        #endregion

        #region Structure

        [TestMethod]
        public void Valid_Structure_BasicCatalog()
        {

            string toValidate = Resources.IValidationService.Valid.Structure.BasicCatalog;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The BasicCatalog.xml file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }

        [TestMethod]
        public void Valid_Structure_OfficialTestFromSchemas()
        {
            string toValidate = Resources.IValidationService.Valid.Structure.OfficialTestFromSchemas;
            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (exception) =>
            {
                Assert.Fail("The OfficialTestFromSchemas.xml file should not throw any exceptions");
                return XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            t.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, this.XmlResolver);
            var results = t.Validate(toValidate);
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }

        #endregion

    }
}
