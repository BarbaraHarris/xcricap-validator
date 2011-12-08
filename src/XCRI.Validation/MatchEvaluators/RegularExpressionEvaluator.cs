using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace XCRI.Validation.MatchEvaluators
{
    public class RegularExpressionEvaluator : MatchEvaluatorBase<Regex, RegularExpressionMatchType>
    {
        public RegularExpressionEvaluator(Regex expression, RegularExpressionMatchType matchType)
            : base(expression, matchType)
        {
        }
        public RegularExpressionEvaluator(Regex expression)
            : this(expression, RegularExpressionMatchType.Matches)
        {
        }
        public override bool IsMatch(string input)
        {
            bool inputMatches = this.ToMatch.IsMatch(input);
            if (
                inputMatches 
                && 
                RegularExpressionMatchType.Matches == this.MatchType
                )
                return true;
            if (
                false == inputMatches
                &&
                RegularExpressionMatchType.DoesNotMatch == this.MatchType
                )
                return true;
            return false;

        }

    }
    public enum RegularExpressionMatchType
    {
        Unknown = 0,
        Matches = 1,
        DoesNotMatch = 2
    }
}
