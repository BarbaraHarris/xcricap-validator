using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;

namespace XCRI.Validation.ContentValidation
{
    public class NumberPerLanguageValidator : NumberValidator
    {
        public string ChildElementSelector { get; set; }
        public override IEnumerable<ValidationResult> Validate(System.Xml.Linq.XElement input)
        {
            if (null == input)
                throw new ArgumentNullException("input");
            IEnumerable<ValidationResult> r = null;
            this.Validate
                (
                (input.XPathEvaluate(this.XPathSelector, this.NamespaceManager) as System.Collections.IEnumerable).Cast<XObject>(),
                out r
                );
            return r;
        }
        public override bool PassesValidation(System.Xml.Linq.XObject node, out string details)
        {
            if (null == node)
                throw new ArgumentNullException("node");
            if(false == (node is XElement))
                throw new NotImplementedException("The node type" + node.GetType() + " was not expected");
            details = null;
            node = node as XElement;
            var languageCounts = this.GetLanguageCounts
                (
                ((node as XElement).XPathEvaluate(this.ChildElementSelector, this.NamespaceManager) as System.Collections.IEnumerable).Cast<XObject>()
                );
            var languageCountsBelowMinimum = languageCounts.Where((k) =>
            {
                if (this.Minimum.HasValue)
                    return k.Value < this.Minimum.Value;
                return false;
            });
            var languageCountsAboveMaximum = languageCounts.Where((k) =>
            {
                if (this.Maximum.HasValue)
                    return k.Value > this.Maximum.Value;
                return false;
            });
            // None below min or above max?
            if (
                0 == languageCountsBelowMinimum.Count()
                &&
                0 == languageCountsAboveMaximum.Count()
                )
                return true;
            details = String.Format
                (
                "The '{0}' element contained some invalid children:{1}",
                (node as XElement).Name,
                System.Environment.NewLine
                );
            foreach (var kvp in languageCountsBelowMinimum)
            {
                details += String.Format
                    (
                    "There were {0} elements with the language {1}, which was below the minimum expected of {2}.{3}",
                    kvp.Value,
                    kvp.Key,
                    this.Minimum.Value,
                    System.Environment.NewLine
                    );
            }
            foreach (var kvp in languageCountsAboveMaximum)
            {
                details += String.Format
                    (
                    "There were {0} elements with the language {1}, which was above the maximum expected of {2}.{3}",
                    kvp.Value,
                    kvp.Key,
                    this.Maximum.Value,
                    System.Environment.NewLine
                    );
            }
            return false;
        }
        public virtual IDictionary<string, int> GetLanguageCounts
            (
            IEnumerable<XObject> childElements
            )
        {
            if (null == childElements)
                throw new ArgumentNullException("childElements");
            Dictionary<string, int> languageCounts = new Dictionary<string, int>();
            foreach (var xobject in childElements)
            {
                if (false == (xobject is XElement))
                    throw new InvalidOperationException("The ChildElementSelector did not return XElements");
                var languageAttribute = (xobject as XElement).Attribute(XName.Get("lang", "http://www.w3.org/XML/1998/namespace"));
                string language = "en";
                if(
                    null!= languageAttribute
                    &&
                    false == String.IsNullOrEmpty(languageAttribute.Value)
                    )
                    language = languageAttribute.Value;
                if (languageCounts.ContainsKey(language.ToLower()))
                    languageCounts[language.ToLower()] = languageCounts[language.ToLower()] + 1;
                else
                    languageCounts.Add(language.ToLower(), 1);
            }
            return languageCounts;
        }
        public override bool PassesValidation(string input, out string details)
        {
            details = null;
            return true;
        }
    }
}
