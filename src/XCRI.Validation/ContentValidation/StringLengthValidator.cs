using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace XCRI.Validation.ContentValidation
{
    public class StringLengthValidator : Validator
    {
        public int? MinimumCharacters { get; set; }
        public int? MaximumCharacters { get; set; }
        public StringLengthValidator
            (
            Logging.ILog log
            )
            : base(log)
        {
        }
        public StringLengthValidator
            (
            )
            : this(null)
        {
        }
        public override bool PassesValidation(string input, out string details)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            details = null;
            if (
                this.MinimumCharacters.HasValue
                &&
                input.Length < this.MinimumCharacters.Value
                )
            {
                details = String.Format
                    (
                    "The minimum length of this element is {0} but this element is {1} characters long",
                    this.MinimumCharacters.Value,
                    input.Length
                    );
                return false;
            }
            if (
                this.MaximumCharacters.HasValue
                &&
                input.Length > this.MaximumCharacters.Value
                )
            {
                details = String.Format
                    (
                    "The maximum length of this element is {0} but this element is {1} characters long",
                    this.MaximumCharacters.Value,
                    input.Length
                    );
                return false;
            }
            return true;
        }
    }
}
