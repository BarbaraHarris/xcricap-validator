using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.MatchEvaluators;

namespace XCRI.Validation.MessageInterpretation
{
    public class Interpreter : IInterpreter
    {

        public Interpreter()
        {
            this.Order = 0;
            this.MatchEvaluators = new List<IMatchEvaluator>();
            this.Interpretations = new List<IInterpretation>();
        }

        public Interpreter
            (
            IEnumerable<IMatchEvaluator> matchEvaluators,
            IEnumerable<IInterpretation> interpretations
            )
            : this()
        {
            if (null == matchEvaluators)
                throw new ArgumentNullException("matchEvaluators");
            if (null == interpretations)
                throw new ArgumentNullException("interpretations");
            this.MatchEvaluators = new List<IMatchEvaluator>(matchEvaluators);
            this.Interpretations = new List<IInterpretation>(interpretations);
        }

        #region IInterpreter Members

        public int Order { get; set; }
        public IList<IMatchEvaluator> MatchEvaluators { get; protected set; }
        public IList<IInterpretation> Interpretations { get; protected set; }

        public InterpretationStatus Interpret
            (
            System.Globalization.CultureInfo cultureInfo,
            Exception e,
            out string interpretation
            )
        {
            if (null == e)
                throw new ArgumentNullException("e");
            interpretation = null;
            if (null != this.Interpretations)
            {
                if (null != this.MatchEvaluators)
                {
                    foreach (var mi in this.MatchEvaluators)
                    {
                        if (false == mi.IsMatch(e.Message))
                            continue;
                        // Find exact (e.g. en-gb) language match
                        try
                        {
                            interpretation = this.Interpretations.Where(i =>
                                i.Culture.Name.Equals(cultureInfo.Name, StringComparison.InvariantCultureIgnoreCase)
                                ).First().HtmlInterpretation;
                            return InterpretationStatus.Interpreted;
                        }
                        catch { interpretation = null; }
                        // Find inexact (e.g. en) language match
                        try
                        {
                            interpretation = this.Interpretations.Where(i =>
                                i.Culture.TwoLetterISOLanguageName.Equals(cultureInfo.TwoLetterISOLanguageName, StringComparison.InvariantCultureIgnoreCase)
                                ).First().HtmlInterpretation;
                            return InterpretationStatus.Interpreted;
                        }
                        catch { interpretation = null; }
                        // None?
                        return String.IsNullOrEmpty(interpretation)
                            ? InterpretationStatus.NotInterpreted
                            : InterpretationStatus.Interpreted;
                    }
                }
            }
            interpretation = null;
            return InterpretationStatus.NotInterpreted;
        }

        public InterpretationStatus Interpret
            (
            Exception e,
            out string interpretation
            )
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
