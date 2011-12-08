using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.MatchEvaluators
{
    /// <summary>
    /// A base class used for items implementing IMatchEvaluator
    /// </summary>
    /// <typeparam name="A">The item to be matched against</typeparam>
    /// <typeparam name="B">An enumerated value used for evaluation options.
    /// In the case of numeric types, this may be LessThan, EqualTo, etc.
    /// In the case of string types, this may be ExactMatch, Prefix, Suffix, etc.</typeparam>
    public abstract class MatchEvaluatorBase<A, B> : IMatchEvaluator
        where B : struct
    {
        
        /// <summary>
        /// The match type to execute
        /// </summary>
        public B MatchType { get; set; }

        /// <summary>
        /// The item to be matched against
        /// </summary>
        public A ToMatch { get; set; }

        public MatchEvaluatorBase(A a, B b)
            : base()
        {
            this.ToMatch = a;
            this.MatchType = b;
        }

        #region IMatchEvaluator Members

        /// <summary>
        /// Attempts to match the input against the value held in ToMatch.
        /// </summary>
        /// <param name="input">The value to match</param>
        /// <returns>Whether this should be considered a match</returns>
        public abstract bool IsMatch(string input);

        #endregion

    }
}
