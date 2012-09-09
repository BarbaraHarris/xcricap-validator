using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public enum LogCategory
    {
        TimingInformation = 1,
        CachingInformation = 2,
        XsdLocations = 4,
        UrlLocations = 8,
        Exceptions = 16,
        UtilisationInformation = 32,
        All = TimingInformation | CachingInformation | XsdLocations
            | UrlLocations | Exceptions | UtilisationInformation
    }
}
