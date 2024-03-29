﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

namespace XCRI.Validation.ContentValidation
{
    public class RegularExpressionValidator : Validator
    {
        public bool IsCaseSensitive { get; set; }
        public string Pattern { get; set; }
        public RegularExpressionValidator()
            : base()
        {
            this.IsCaseSensitive = true;
        }
        public override bool PassesValidation(string input, out string details)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            if(String.IsNullOrWhiteSpace(this.Pattern))
                throw new InvalidOperationException("The Pattern property must be set");
            details = null;
            Regex expression = this.IsCaseSensitive
                ? new Regex(this.Pattern)
                : new Regex(this.Pattern, RegexOptions.IgnoreCase);
            if (expression.IsMatch(input))
                return true;
            details = String.Format
                (
                "The value '{0}' did not match the regular expression pattern '{1}'",
                input,
                this.Pattern
                );
            return false;
        }
    }
}
