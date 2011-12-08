using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests
{
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService, T>
        where T : XCRI.Validation.IValidationService
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
            var r = new XCRI.Validation.NinjectResolver();
            XCRI.Validation.IoC.Initialize<XCRI.Validation.NinjectResolver>(r, o =>
            {
                o.Bind<XCRI.Validation.XmlRetrieval.ISource<Uri>>().To<XCRI.Validation.XmlRetrieval.UriSource>();
                o.Bind<XCRI.Validation.IValidationResult>().To<XCRI.Validation.ValidationResult>();
                o.Bind<XCRI.Validation.XmlRetrieval.IXmlCachingResolver>().To<XCRI.Validation.XmlRetrieval.XmlCachingResolver>();
            });

            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (gi, exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Namespaces\Description.xml").FullName));
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
            var r = new XCRI.Validation.NinjectResolver();
            XCRI.Validation.IoC.Initialize<XCRI.Validation.NinjectResolver>(r, o =>
            {
                o.Bind<XCRI.Validation.XmlRetrieval.ISource<Uri>>().To<XCRI.Validation.XmlRetrieval.UriSource>();
                o.Bind<XCRI.Validation.IValidationResult>().To<XCRI.Validation.ValidationResult>();
                o.Bind<XCRI.Validation.XmlRetrieval.IXmlCachingResolver>().To<XCRI.Validation.XmlRetrieval.XmlCachingResolver>();
            });

            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (gi, exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Namespaces\Title.xml").FullName));
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
            var r = new XCRI.Validation.NinjectResolver();
            XCRI.Validation.IoC.Initialize<XCRI.Validation.NinjectResolver>(r, o =>
            {
                o.Bind<XCRI.Validation.XmlRetrieval.ISource<Uri>>().To<XCRI.Validation.XmlRetrieval.UriSource>();
                o.Bind<XCRI.Validation.IValidationResult>().To<XCRI.Validation.ValidationResult>();
                o.Bind<XCRI.Validation.XmlRetrieval.IXmlCachingResolver>().To<XCRI.Validation.XmlRetrieval.XmlCachingResolver>();
            });

            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (gi, exception) =>
            {
                Assert.Fail("The XML file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Namespaces\Identifier.xml").FullName));
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

            var r = new XCRI.Validation.NinjectResolver();
            XCRI.Validation.IoC.Initialize<XCRI.Validation.NinjectResolver>(r, o =>
            {
                o.Bind<XCRI.Validation.XmlRetrieval.ISource<Uri>>().To<XCRI.Validation.XmlRetrieval.UriSource>();
                o.Bind<XCRI.Validation.IValidationResult>().To<XCRI.Validation.ValidationResult>();
                o.Bind<XCRI.Validation.XmlRetrieval.IXmlCachingResolver>().To<XCRI.Validation.XmlRetrieval.XmlCachingResolver>();
            });

            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (gi, exception) =>
            {
                Assert.Fail("The BasicCatalog.xml file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Structure\BasicCatalog.xml").FullName));
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
            var r = new XCRI.Validation.NinjectResolver();
            XCRI.Validation.IoC.Initialize<XCRI.Validation.NinjectResolver>(r, o =>
            {
                o.Bind<XCRI.Validation.XmlRetrieval.ISource<Uri>>().To<XCRI.Validation.XmlRetrieval.UriSource>();
                o.Bind<XCRI.Validation.IValidationResult>().To<XCRI.Validation.ValidationResult>();
                o.Bind<XCRI.Validation.XmlRetrieval.IXmlCachingResolver>().To<XCRI.Validation.XmlRetrieval.XmlCachingResolver>();
            });

            var interpreter = new DebugIntepreter();
            interpreter.InterpretationFunction = (gi, exception) =>
            {
                Assert.Fail("The OfficialTestFromSchemas.xml file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo(@"IValidationService\Valid\Structure\OfficialTestFromSchemas.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }

        #endregion

    }
}
