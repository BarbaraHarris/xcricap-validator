using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.MatchEvaluators
{
    public interface IMatchEvaluator
    {
        bool IsMatch(string input);
    }
}
