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
        private object _lock = new object();
        protected Dictionary<Uri, XCRI.Validation.ContentValidation.VDEXValidator> CachedVDEXValidators = new Dictionary<Uri, XCRI.Validation.ContentValidation.VDEXValidator>();
        public XCRI.Validation.ContentValidation.VDEXValidator CreateVDEXValidator(Uri vdexLocation)
        {
            if (false == this.CachedVDEXValidators.ContainsKey(vdexLocation))
            {
                lock (this._lock)
                {
                    if (false == this.CachedVDEXValidators.ContainsKey(vdexLocation))
                        this.CachedVDEXValidators.Add(vdexLocation, new XCRI.Validation.ContentValidation.VDEXValidator
                        (
                        new XCRI.Validation.XmlRetrieval.UriSource(null, null)
                        )
                        {
                            VDEXLocation = vdexLocation
                        });
                }
            }
            return this.CachedVDEXValidators[vdexLocation];
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

        public void TestDescriptionExistsUnderElement
            (
            XCRI.Validation.ContentValidation.ElementValidator ev,
            System.Xml.Linq.XElement element,
            int expectedFailures,
            int expectedSuccesses
            )
        {
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:description)",
                ExceptionMessage = "All catalogs should provide a description element",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(element)
                .Where(r => r.Message == v.ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: (0 == expectedFailures)
                    ? XCRI.Validation.ContentValidation.ValidationStatus.Passed
                    : XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: expectedFailures + expectedSuccesses,
                expectedFailedCount: expectedFailures,
                expectedSuccessfulCount: expectedSuccesses
                );
            ev.Validators.Clear();
        }

        public void TestCourseExistsUnderElement
            (
            XCRI.Validation.ContentValidation.ElementValidator ev,
            System.Xml.Linq.XElement element,
            int expectedFailures,
            int expectedSuccesses
            )
        {
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./xcri12:course)",
                ExceptionMessage = "All providers must contain a course",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(element)
                .Where(r => r.Message == v.ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: (0 == expectedFailures)
                    ? XCRI.Validation.ContentValidation.ValidationStatus.Passed
                    : XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: expectedFailures + expectedSuccesses,
                expectedFailedCount: expectedFailures,
                expectedSuccessfulCount: expectedSuccesses
                );
            ev.Validators.Clear();
        }

        public void TestIdentifierWithoutXsiTypeExistsUnderElement
            (
            XCRI.Validation.ContentValidation.ElementValidator ev,
            System.Xml.Linq.XElement element,
            int expectedFailures,
            int expectedSuccesses
            )
        {
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:identifier[not(@xsi:type)])",
                ExceptionMessage = "All providers must contain an identifier without an xsi:type attribute",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(element)
                .Where(r => r.Message == v.ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: (0 == expectedFailures)
                    ? XCRI.Validation.ContentValidation.ValidationStatus.Passed
                    : XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: expectedFailures + expectedSuccesses,
                expectedFailedCount: expectedFailures,
                expectedSuccessfulCount: expectedSuccesses
                );
            ev.Validators.Clear();
        }

        public void TestTitleExistsUnderElement
            (
            XCRI.Validation.ContentValidation.ElementValidator ev,
            System.Xml.Linq.XElement element,
            int expectedFailures,
            int expectedSuccesses
            )
        {
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:title)",
                ExceptionMessage = "All providers must contain a title, which should be the trading name.",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(element)
                .Where(r => r.Message == v.ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: (0 == expectedFailures)
                    ? XCRI.Validation.ContentValidation.ValidationStatus.Passed
                    : XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: expectedFailures + expectedSuccesses,
                expectedFailedCount: expectedFailures,
                expectedSuccessfulCount: expectedSuccesses
                );
            ev.Validators.Clear();
        }

        public void TestSubjectExistsUnderElement
            (
            XCRI.Validation.ContentValidation.ElementValidator ev,
            System.Xml.Linq.XElement element,
            int expectedFailures,
            int expectedSuccesses
            )
        {
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:subject)",
                ExceptionMessage = "All courses should contain a subject",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(element)
                .Where(r => r.Message == v.ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: (0 == expectedFailures)
                    ? XCRI.Validation.ContentValidation.ValidationStatus.Passed
                    : XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: expectedFailures + expectedSuccesses,
                expectedFailedCount: expectedFailures,
                expectedSuccessfulCount: expectedSuccesses
                );
            ev.Validators.Clear();
        }

        public void TestUrlExistsUnderElement
            (
            XCRI.Validation.ContentValidation.ElementValidator ev,
            System.Xml.Linq.XElement element,
            int expectedFailures,
            int expectedSuccesses
            )
        {
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:url)",
                ExceptionMessage = "All providers must contain a url, which should be its homepage or microsite",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(element)
                .Where(r => r.Message == v.ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: (0 == expectedFailures)
                    ? XCRI.Validation.ContentValidation.ValidationStatus.Passed
                    : XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: expectedFailures + expectedSuccesses,
                expectedFailedCount: expectedFailures,
                expectedSuccessfulCount: expectedSuccesses
                );
            ev.Validators.Clear();
        }

        public void TestLocationExistsUnderElement
            (
            XCRI.Validation.ContentValidation.ElementValidator ev,
            System.Xml.Linq.XElement element,
            int expectedFailures,
            int expectedSuccesses
            )
        {
            var v = new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./mlo:location)",
                ExceptionMessage = "All providers must contain a location",
                FailedValidationStatus = XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                Minimum = 1,
                ValidationGroup = "Structure",
                NamespaceManager = ev.NamespaceManager
            };
            ev.Validators.Add(v);
            var vr = ev
                .Validate(element)
                .Where(r => r.Message == v.ExceptionMessage);
            Assert.AreEqual<int>(1, vr.Count());
            ValidateResults
                (
                result: vr.ElementAt(0),
                expectedStatus: (0 == expectedFailures)
                    ? XCRI.Validation.ContentValidation.ValidationStatus.Passed
                    : XCRI.Validation.ContentValidation.ValidationStatus.Exception,
                expectedInstances: expectedFailures + expectedSuccesses,
                expectedFailedCount: expectedFailures,
                expectedSuccessfulCount: expectedSuccesses
                );
            ev.Validators.Clear();
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
