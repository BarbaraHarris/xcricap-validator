using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static T ParseEnumFrom<T>(this string value)
            where T : struct
        {
            return value.ParseEnumFrom<T>(true);
        }
        public static T ParseEnumFrom<T>(this string value, bool ignoreCase)
            where T : struct
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
