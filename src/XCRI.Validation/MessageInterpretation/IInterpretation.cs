using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.MessageInterpretation
{
    public interface IInterpretation
    {
        System.Globalization.CultureInfo Culture { get; set; }
        string HtmlInterpretation { get; set; }
    }
}
