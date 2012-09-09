using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.ContentValidation
{
    public class EmailAddressValidator : Validator
    {
        public EmailAddressValidator
            (
            Logging.ILog log
            )
            : base(log)
        {
        }
        public EmailAddressValidator
            (
            )
            : this(null)
        {
        }
        public override bool PassesValidation(string input, out string details)
        {
            System.Net.Mail.MailAddress throwaway;
            details = null;
            try
            {
                throwaway = new System.Net.Mail.MailAddress(input, String.Empty);
                return true;
            }
            catch
            {
                details = String.Format("Value was: '{0}'", input);
                return false;
            }
        }
    }
}
