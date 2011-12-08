using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.MatchEvaluators
{
    public class StringMatchEvaluator : MatchEvaluatorBase<string, StringMatchType>
    {

        public bool CaseSensitive { get; set; }
        public StringMatchEvaluator(string toMatch, StringMatchType matchType)
            : base(toMatch, matchType)
        {
            this.CaseSensitive = false;
        }

        public override bool IsMatch(string input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            if (null == this.ToMatch)
                return false;
            // Exact match
            if (
                (this.MatchType & StringMatchType.Exact) > 0
                &&
                input.Equals(this.ToMatch, this.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase)
                )
                return true;
            // Prefix
            if (
                (this.MatchType & StringMatchType.Prefix) > 0
                &&
                this.ToMatch.StartsWith(input, this.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase)
                )
                return true;
            // Suffix
            if (
                (this.MatchType & StringMatchType.Suffix) > 0
                &&
                this.ToMatch.EndsWith(input, this.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase)
                )
                return true;
            // Nope
            return false;
        }

    }
    public enum StringMatchType
    {
        Unknown = 0,
        Exact = 1,
        Prefix = 2,
        Suffix = 4,
        Any = Exact | Prefix | Suffix
    }
}
