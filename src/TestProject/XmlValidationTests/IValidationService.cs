using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject.XmlValidationTests
{
    [TestClass]
    public abstract partial class IValidationService<T> : TestBase<XCRI.Validation.IValidationService, T>
        where T : XCRI.Validation.IValidationService
    {
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
