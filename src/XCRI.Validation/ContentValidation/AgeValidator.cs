﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace XCRI.Validation.ContentValidation
{
    public class AgeValidator : RegularExpressionValidator
    {
        /// <summary>
        /// The AgeValidator validates that the value provided is valid according to the
        /// XCRI-CAP 1.2 &lt;age&gt; element, detailed at 
        /// http://www.xcri.org/wiki/index.php/XCRI_CAP_1.2#the_.3Cage.3E_element.
        /// Valid values are "any", "not known", "x-y" or "x+", where x and y are non-negative integers
        /// and x is less than or equal to the value of y.
        /// </summary>
        /// <seealso cref="IValidator"/>
        public AgeValidator()
            : base()
        {
            this.Pattern = @"^(?:any|not known|(?<Lower>\d{1,})(?:\+|(?:\-(?<Upper>\d{1,}))))$";
        }
        public override bool PassesValidation(string input, out string details)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            if (String.IsNullOrWhiteSpace(this.Pattern))
                throw new InvalidOperationException("The Pattern property must be set");
            details = null;
            Regex expression = new Regex(this.Pattern, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            string[] groupNames = expression.GetGroupNames();
            if (false == groupNames.Contains("Lower"))
                throw new InvalidOperationException("The regular expression did not include a 'Lower' group");
            if (false == groupNames.Contains("Upper"))
                throw new InvalidOperationException("The regular expression did not include an 'Upper' group");
            Match match = expression.Match(input);
            if(false == match.Success)
            {
                details = String.Format
                    (
                    "The value '{0}' did not match the regular expression pattern '{1}'",
                    input,
                    this.Pattern
                    );
                return false;
            }
            int lowerInteger = Int32.MaxValue;
            Group lower = match.Groups["Lower"];
            if (lower.Success)
            {
                if (false == Int32.TryParse(lower.Value, out lowerInteger))
                {
                    details = String.Format
                        (
                        "The value '{0}' could not be converted to an integer",
                        lower.Value
                        );
                    return false;
                }
                if (lowerInteger < 0)
                {
                    details = String.Format
                        (
                        "The value '{0}' was negative",
                        lower.Value
                        );
                    return false;
                }
            }
            int upperInteger = Int32.MinValue;
            Group upper = match.Groups["Upper"];
            if (upper.Success)
            {
                if (false == Int32.TryParse(upper.Value, out upperInteger))
                {
                    details = String.Format
                        (
                        "The value '{0}' could not be converted to an integer",
                        upper.Value
                        );
                    return false;
                }
                if (upperInteger < 0)
                {
                    details = String.Format
                        (
                        "The value '{0}' was negative",
                        upper.Value
                        );
                    return false;
                }
                if (lowerInteger > upperInteger)
                {
                    details = String.Format
                        (
                        "The lower value ('{0}') was larger than the upper value ('{1}')",
                        lower.Value,
                        upper.Value
                        );
                    return false;
                }
            }
            return true;
        }
    }
}
