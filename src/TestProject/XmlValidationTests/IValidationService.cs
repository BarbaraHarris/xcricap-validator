using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests
{
    [TestClass]
    public abstract class IValidationService<T> : TestBase<XCRI.Validation.IValidationService, T>
        where T : XCRI.Validation.IValidationService
    {
        [TestMethod]
        [DeploymentItem(@"TestProject\Resources\IValidationService\Invalid\Structure\XmlNesting.xml")]
        public void InvalidXmlNesting()
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
                if (exception == null)
                    throw new ArgumentNullException("exception");
                if (exception.GetType() == typeof(System.Xml.XmlException))
                {
                    System.Xml.XmlException e = exception as System.Xml.XmlException;
                    if (e.LineNumber != 7)
                        Assert.Fail("This test should fail on line 7");
                    if (e.LinePosition != 5)
                        Assert.Fail("This test should fail at line position 5");
                    if (e.Message != "The 'provider' start tag on line 5 position 4 does not match the end tag of 'catalog'. Line 7, position 5.")
                        Assert.Fail("This test should fail because of incorrect tag nesting");
                }
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo("XmlNesting.xml").FullName));
            Assert.AreEqual<int>(1, results.Count, "1 exception expected");

        }
        [TestMethod]
        [DeploymentItem(@"TestProject\Resources\IValidationService\Valid\BasicCatalog.xml")]
        public void ValidBasicCatalog()
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
                Assert.Fail("The Valid-BasicCatalog.xml file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo("BasicCatalog.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }
        [TestMethod]
        [DeploymentItem(@"TestProject\Resources\IValidationService\Valid\OfficialTestFromSchemas.xml")]
        public void ValidOfficialTestFromSchemas()
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
                Assert.Fail("The Valid-OfficialTestFromSchemas.xml file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo("OfficialTestFromSchemas.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }
        [TestMethod]
        [DeploymentItem(@"TestProject\Resources\IValidationService\Invalid\OfficialTestFromSchemasWithoutNamespaces.xml")]
        public void InvalidOfficialTestFromSchemasWithoutNamespaces()
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
                Assert.Fail("The Invalid-OfficialTestFromSchemasWithoutNamespaces.xml file should not throw any exceptions");
                return XCRI.Validation.MessageInterpretation.InterpretationStatus.Interpreted;
            };

            var t = base.Instantiate();
            t.XmlExceptionInterpreters.Add(interpreter);
            var results = t.Validate<Uri>(new Uri(new System.IO.FileInfo("OfficialTestFromSchemasWithoutNamespaces.xml").FullName));
            Assert.AreEqual<int>(0, results.Count, "No exceptions expected");

        }
        private class DebugIntepreter : XCRI.Validation.MessageInterpretation.IInterpreter
        {

            public string InterpretationMessage { get; set; }
            public Func<System.Globalization.CultureInfo, Exception, XCRI.Validation.MessageInterpretation.InterpretationStatus> InterpretationFunction = null;

            #region IInterpreter Members

            public int Order { get; set; }

            public IList<XCRI.Validation.MatchEvaluators.IMatchEvaluator> MatchEvaluators
            {
                get { throw new InvalidOperationException("Match Evaluators are ignored for the debug interpreter - assume everything matches"); ; }
            }

            public IList<XCRI.Validation.MessageInterpretation.IInterpretation> Interpretations
            {
                get { throw new InvalidOperationException("Populate the InterpretationFunction property instead"); }
            }

            public XCRI.Validation.MessageInterpretation.InterpretationStatus Interpret
                (
                System.Globalization.CultureInfo cultureInfo, 
                Exception e,
                out string interpretation)
            {
                if (null == e)
                    throw new ArgumentNullException("e");
                var status = this.InterpretationFunction(cultureInfo, e);
                interpretation = this.InterpretationMessage;
                return status;
            }

            public XCRI.Validation.MessageInterpretation.InterpretationStatus Interpret(Exception e, out string interpretation)
            {
                return this.Interpret
                    (
                    System.Globalization.CultureInfo.CurrentUICulture,
                    e,
                    out interpretation
                    );
            }

            #endregion

        }
    }
}
