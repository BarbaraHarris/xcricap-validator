using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XCRI.Validation.ExtensionMethods
{
    public static class XElementExtensionMethods
    {
        public static string OuterXml(this XElement xelement)
        {
            var xReader = xelement.CreateReader();
            xReader.MoveToContent();
            return xReader.ReadOuterXml();
        }
        public static string InnerXml(this XElement xelement)
        {
            var xReader = xelement.CreateReader();
            xReader.MoveToContent();
            return xReader.ReadInnerXml();
        }
    }
}
