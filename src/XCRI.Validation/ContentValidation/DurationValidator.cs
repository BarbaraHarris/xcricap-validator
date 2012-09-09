using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    public class DurationValidator : Validator
    {
        public static System.Text.RegularExpressions.Regex Format_PnYnMnDTnHnMnS
            = new System.Text.RegularExpressions.Regex
            (
            @"^P(?:(?<Years>[\d\.\,]{1,})Y)?(?:(?<Months>[\d\.\,]{1,})M)?(?:(?<Days>[\d\.\,]{1,})D)?(?:T(?:(?<Hours>[\d\.\,]{1,})H)?(?:(?<Minutes>[\d\.\,]{1,})M)?(?:(?<Seconds>[\d\.\,]{1,})S)?)?$",
            System.Text.RegularExpressions.RegexOptions.Compiled
            );
        public static System.Text.RegularExpressions.Regex Format_PnW
            = new System.Text.RegularExpressions.Regex
            (
            @"^P((?<Weeks>[\d\.\,]{1,})W)$",
            System.Text.RegularExpressions.RegexOptions.Compiled
            );
        public static System.Text.RegularExpressions.Regex Format_PYYYYMMDDThhmmss
            = new System.Text.RegularExpressions.Regex
            (
            @"^P(?<Years>\d{4})-?(?<Months>\d{2})-?(?<Days>\d{2})T(?<Hours>\d{2}):?(?<Minutes>\d{2}):?(?<Seconds>\d{2})$",
            System.Text.RegularExpressions.RegexOptions.Compiled
            );
        public static System.Text.RegularExpressions.Regex Format_PdateTtime
            = new System.Text.RegularExpressions.Regex
            (
            @"^P(?<Date>(?:(?<Years>\d{4})-?(?<Months>\d{2})-?(?<Days>\d{2}))|(?:(?<Years>\d{4})-?(?<Months>\d{2})-?(?<Days>\d{2}))|(?:(?<Years>\d{4})-?W(?<Weeks>\d{2})-?(?<Days>\d{1})?)|(?:(?<Years>\d{4})-?(?<Months>\d{2})))(?:T(?<Time>(?<Hours>\d{2}):?(?<Minutes>\d{2}):?(?<Seconds>\d{2})(?<Offset>Z?|[\+\-](?<OffsetHours>\d{2}):?(?<OffsetMinutes>\d{2})?)))?$",
            System.Text.RegularExpressions.RegexOptions.Compiled
            );
        public DurationValidator
            (
            Logging.ILog log
            )
            : base(log)
        {
        }
        public DurationValidator
            (
            )
            : this(null)
        {
        }
        public static bool TryParse
            (
            string input
            )
        {
            decimal years, months, weeks, days, hours, minutes, seconds;
            return TryParse(input, out years, out months, out weeks, out days, out hours, out minutes, out seconds);
        }
        public static bool TryParse
            (
            string input,
            out decimal years,
            out decimal months,
            out decimal weeks,
            out decimal days,
            out decimal hours,
            out decimal minutes,
            out decimal seconds
            )
        {
            years = 0;
            months = 0;
            weeks = 0;
            days = 0;
            hours = 0;
            minutes = 0;
            seconds = 0;
            if(String.IsNullOrWhiteSpace(input))
                return false;
            if (ParseFromMatch(Format_PnYnMnDTnHnMnS.Match(input), out years, out months, out weeks, out days, out hours, out minutes, out seconds))
                return true;
            if (ParseFromMatch(Format_PnW.Match(input), out years, out months, out weeks, out days, out hours, out minutes, out seconds))
                return true;
            if (ParseFromMatch(Format_PYYYYMMDDThhmmss.Match(input), out years, out months, out weeks, out days, out hours, out minutes, out seconds))
                return true;
            if (ParseFromMatch(Format_PdateTtime.Match(input), out years, out months, out weeks, out days, out hours, out minutes, out seconds))
                return true;
            return false;
        }
        private static bool ParseFromMatch
            (
            System.Text.RegularExpressions.Match match,
            out decimal years,
            out decimal months,
            out decimal weeks,
            out decimal days,
            out decimal hours,
            out decimal minutes,
            out decimal seconds
            )
        {
            years = 0;
            months = 0;
            weeks = 0;
            days = 0;
            hours = 0;
            minutes = 0;
            seconds = 0;
            if (null == match)
                return false;
            if (false == match.Success)
                return false;
            years = ParseDecimalFromGroupValue(match.Groups["Years"]);
            months = ParseDecimalFromGroupValue(match.Groups["Months"]);
            weeks = ParseDecimalFromGroupValue(match.Groups["Weeks"]);
            days = ParseDecimalFromGroupValue(match.Groups["Days"]);
            hours = ParseDecimalFromGroupValue(match.Groups["Hours"]);
            minutes = ParseDecimalFromGroupValue(match.Groups["Minutes"]);
            seconds = ParseDecimalFromGroupValue(match.Groups["Seconds"]);
            return true;
        }
        private static decimal ParseDecimalFromGroupValue
            (
            System.Text.RegularExpressions.Group group
            )
        {
            if (null == group)
                return 0;
            if (false == group.Success)
                return 0;
            return Decimal.Parse((group.Value ?? String.Empty).Replace(",", "."));
        }
        public override bool PassesValidation(string input, out string details)
        {
            details = null;
            if (false == TryParse(input))
            {
                details = String.Format
                    (
                    "{0} is not a valid ISO 8601 duration",
                    input
                    );
                return false;
            }
            return true;
        }
    }
}
