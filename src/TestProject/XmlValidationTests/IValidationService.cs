using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;

namespace TestProject.XmlValidationTests
{
    [TestClass]
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService<Uri>, T>
        where T : XCRI.Validation.IValidationService<Uri>
    {
        protected XCRI.Validation.XmlRetrieval.XmlCachingResolver XmlResolver
            = new XCRI.Validation.XmlRetrieval.XmlCachingResolver(null, null, null);
        private class DebugIntepreter : XCRI.Validation.XmlExceptionInterpretation.Interpreter
        {

            public string InterpretationMessage { get; set; }
            public Func<Exception, XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus> InterpretationFunction = null;

            #region IInterpreter Members

            public override XCRI.Validation.XmlExceptionInterpretation.InterpretationStatus Interpret
                (
                Exception e,
                out XElement furtherInformation
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
