﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.MatchEvaluators;

namespace XCRI.Validation.MessageInterpretation
{
    public interface IInterpreter
    {
        int Order { get; set;  }
        IList<IMatchEvaluator> MatchEvaluators { get; }
        IList<IInterpretation> Interpretations { get; }
        InterpretationStatus Interpret
            (
            System.Globalization.CultureInfo cultureInfo,
            Exception e,
            out string interpretation
            );
        InterpretationStatus Interpret
            (
            Exception e,
            out string interpretation
            );

    }
}
