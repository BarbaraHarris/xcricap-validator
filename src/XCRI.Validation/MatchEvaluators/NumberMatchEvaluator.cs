using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.MatchEvaluators
{
    /// <summary>
    /// Implements IMatchEvaluator for a decimal number type
    /// </summary>
    public class NumberMatchEvaluator : MatchEvaluatorBase<decimal, NumberMatchType>
    {

        public NumberMatchEvaluator(decimal toMatch, NumberMatchType matchType)
            : base(toMatch, matchType)
        {
        }

        public override bool IsMatch(string input)
        {
            // Check input
            if (null == input)
                throw new ArgumentNullException("input");
            decimal d = 0;
            if (false == Decimal.TryParse(input, out d))
                throw new ArgumentException
                    (
                    "The input parameter must be convertable to decimal",
                    "input"
                    );
            // Exact matches
            if (
                ((this.MatchType & NumberMatchType.EqualTo) > 0)
                &&
                (d == this.ToMatch)
                )
                return true;
            // Less than
            if (
                ((this.MatchType & NumberMatchType.LessThan) > 0)
                &&
                (d < this.ToMatch)
                )
                return true;
            // Greater than
            if (
                ((this.MatchType & NumberMatchType.GreaterThan) > 0)
                &&
                (d > this.ToMatch)
                )
                return true;
            // Nope - sad panda
            return false;
        }

    }
    public enum NumberMatchType
    {
        Unknown = 0,
        EqualTo = 1,
        LessThan = 2,
        GreaterThan = 4,
        LessThanOrEqualTo = LessThan | EqualTo,
        GreaterThanOrEqualTo = GreaterThan | EqualTo
    }
}
