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
            ()
            : base()
        {
            
        }
        public override bool PassesValidation(System.Xml.Linq.XElement input, out string details)
        {
            System.Net.Mail.MailAddress throwaway;
            details = null;
            try
            {
                throwaway = new System.Net.Mail.MailAddress(input.Value, String.Empty);
                return true;
            }
            catch
            {
                details = String.Format("Value was: '{0}'", input.Value);
                return false;
            }
        }
    }
}
