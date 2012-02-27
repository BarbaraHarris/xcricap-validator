using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.XmlValidationTests
{
    [TestClass]
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService<String>, T>
        where T : XCRI.Validation.IValidationService<String>
    {
        protected XCRI.Validation.XmlRetrieval.XmlCachingResolver XmlResolver
            = new XCRI.Validation.XmlRetrieval.XmlCachingResolver(null, null, null);
        protected System.Xml.XmlNamespaceManager GetNamespaceManager()
        {
            var xmlnsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            xmlnsmgr.AddNamespace("mlo", "http://purl.org/net/mlo");
            xmlnsmgr.AddNamespace("xcri12", "http://xcri.org/profiles/1.2/catalog");
            xmlnsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            xmlnsmgr.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlnsmgr.AddNamespace("credit", "http://purl.org/net/cm");
            xmlnsmgr.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");
            return xmlnsmgr;
        }
        protected void ValidateResults
            (
            XCRI.Validation.ValidationResult result,
            XCRI.Validation.ContentValidation.ValidationStatus expectedStatus,
            int expectedInstances,
            int expectedFailedCount,
            int expectedSuccessfulCount
            )
        {
            Assert.IsNotNull(result);
            Assert.AreEqual<XCRI.Validation.ContentValidation.ValidationStatus>
                (
                expectedStatus,
                result.Status
                );
            Assert.AreEqual<int>
                (
                expectedInstances,
                result.Count
                );
            Assert.AreEqual<int>
                (
                expectedFailedCount,
                result.FailedCount
                );
            Assert.AreEqual<int>
                (
                expectedSuccessfulCount,
                result.SuccessCount
                );
        }
        private class DebugIntepreter : XCRI.Validation.XmlExceptionInterpretation.Interpreter
        {

            public string InterpretationMessage { get; set; }
            public Func<Exception, XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus> InterpretationFunction = null;

            #region IInterpreter Members

            public override XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus Interpret
                (
                Exception e,
                out XElement furtherInformation,
                ref string message
                )
            {
                if (null == e)
                    throw new ArgumentNullException("e");
                var status = this.InterpretationFunction(e);
                furtherInformation = null;
                return status;
            }

            #endregion

        }
    }
}
