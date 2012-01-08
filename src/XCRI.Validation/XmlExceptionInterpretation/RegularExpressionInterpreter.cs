using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XCRI.Validation.XmlExceptionInterpretation
{
    public class RegularExpressionInterpreter : Interpreter
    {

        public RegexOptions Options { get; set; }
        public bool Invert { get; set; }
        public string Pattern { get; set; }
        public List<Condition> Conditions { get; protected set; }

        public RegularExpressionInterpreter()
            : base()
        {
            this.Conditions = new List<Condition>();
        }

        public override InterpretationStatus Interpret
            (
            Exception e,
            out XElement furtherInformation
            )
        {
            if (null == e)
                throw new ArgumentNullException("e");
            furtherInformation = null;
            if (null == this.Conditions)
                return InterpretationStatus.NotInterpreted;
            Regex regex = new Regex(this.Pattern, this.Options);
            string value = null;
            switch(this.PropertyName)
            {
                case "Message":
                    value = e.Message;
                    break;
                default:
                    throw new InvalidOperationException("The PropertyName property could not be resolved to a valid property on the Exception object");
            }
            List<XElement> childElements = new List<XElement>();
            foreach (var c in this.Conditions)
            {
                bool passes = c.Passes(regex, value);
                if (Invert)
                    passes = !passes;
                if (passes)
                {
                    if (null != c.FurtherInformation)
                        childElements.AddRange(c.FurtherInformation.XPathSelectElements("./*"));
                }
            }
            if (childElements.Count == 0)
                return InterpretationStatus.NotInterpreted;
            furtherInformation = new XElement("furtherInformation", childElements);
            return InterpretationStatus.Interpreted;
        }
        public abstract class Condition
        {
            public abstract bool Passes(Regex expression, string propertyValue);
            public XElement FurtherInformation { get; set; }
        }
        public class IfMatch : Condition
        {
            public override bool Passes(Regex expression, string propertyValue)
            {
                return expression.IsMatch(propertyValue);
            }
        }
        public class IfGroup : Condition
        {
            public string GroupName { get; set; }
            public string MatchValue { get; set; }
            public bool IgnoreCase { get; set; }
            public IfGroup()
            {
                this.GroupName = null;
                this.MatchValue = null;
                this.IgnoreCase = true;
            }
            public override bool Passes(Regex expression, string propertyValue)
            {
                if (String.IsNullOrEmpty(this.GroupName))
                    throw new InvalidOperationException("The group name must be populated");
                var m = expression.Match(propertyValue);
                if (null == m)
                    return false;
                if (null == m.Groups)
                    return false;
                var g = m.Groups[this.GroupName];
                if (null == g)
                    return false;
                if (false == g.Success)
                    return false;
                return g.Value.Equals
                    (
                    this.MatchValue,
                    this.IgnoreCase ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture
                    );
            }
        }
    }
}
