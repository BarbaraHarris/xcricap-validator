using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.MessageInterpretation
{
    public class Interpretation : IInterpretation
    {

        #region IInterpretation Members

        public System.Globalization.CultureInfo Culture { get; set; }

        public string HtmlInterpretation { get; set; }

        #endregion

    }
}
