using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation.XmlRetrieval;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.ContentValidation
{
    public class VDEXValidator : Validator
    {
        public Uri VDEXLocation { get; set; }
        public ISource<Uri> UriSource { get; protected set; }
        public bool IsIdentifierCaseSensitive { get; set; }
        public bool IsCaptionCaseSensitive { get; set; }
        public IEnumerable<string> ValidIdentifiers { get; private set; }
        public IEnumerable<string> ValidCaptions { get; private set; }
        public bool AllowBlankIdentifier { get; set; }
        public bool AllowBlankCaption { get; set; }
        public VDEXValidator
            (
            ISource<Uri> uriSource
            )
            : base()
        {
            if (null == uriSource)
                throw new ArgumentNullException("uriSource");
            this.UriSource = uriSource;
            this.IsIdentifierCaseSensitive = true;
            this.IsCaptionCaseSensitive = true;
            this.AllowBlankCaption = false;
            this.AllowBlankIdentifier = false;
        }
        public void Setup()
        {
            var VDEXTermSelector = "//vdex:term/vdex:termIdentifier";
            var VDEXCaptionSelector = "//vdex:term/vdex:caption/vdex:langstring";
            System.Xml.Linq.XDocument doc;
            using (XmlReader xmlReader = this.UriSource.GetXmlReader(this.VDEXLocation))
            {
                doc = System.Xml.Linq.XDocument.Load(xmlReader);
            }
            XmlNamespaceManager xmlnsmgr = new XmlNamespaceManager(new System.Xml.NameTable());
            xmlnsmgr.AddNamespace("vdex", "http://www.imsglobal.org/xsd/imsvdex_v1p0");
            // Load in valid terms
            var validTerms = new List<string>();
            foreach (var e in doc.XPathSelectElements(VDEXTermSelector, xmlnsmgr))
                validTerms.Add(e.Value);
            this.ValidIdentifiers = validTerms;
            // Load in valid captions
            var validCaptions = new List<string>();
            foreach (var e in doc.XPathSelectElements(VDEXCaptionSelector, xmlnsmgr))
                validCaptions.Add(e.Value);
            this.ValidCaptions = validCaptions;
        }
        public bool IsValidIdentifier(string identifier)
        {
            if (
                null == this.ValidIdentifiers
                )
                this.Setup();
            return this.ValidIdentifiers.Where(s =>
                String.Equals(s, identifier, (this.IsCaptionCaseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase))
                ).Count() > 0;
        }
        public bool IsValidElementValue(string value)
        {
            if (
                null == this.ValidCaptions
                )
                this.Setup();
            return this.ValidCaptions.Where(s => 
                String.Equals(s, value, (this.IsCaptionCaseSensitive ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase))
                ).Count() > 0;
        }
        public override bool PassesValidation(System.Xml.Linq.XObject node, out string details)
        {
            if (
                null == this.ValidCaptions
                ||
                null == this.ValidIdentifiers
                )
                this.Setup();
            if(false == (node is XElement))
                throw new InvalidOperationException("The xobject must be an xelement");
            details = null;
            var element = node as XElement;
            if (null != element.Attribute("identifier"))
            {
                var identifier = element.Attribute("identifier").Value;
                if (false == String.IsNullOrWhiteSpace(identifier))
                {
                    if (false == this.IsValidIdentifier(identifier))
                    {
                        details = String.Format
                            (
                            "The value {0} was not a valid identifier value",
                            identifier
                            );
                        return false;
                    }
                }
                else
                {
                    if (false == this.AllowBlankIdentifier)
                    {
                        details = "Blank identifiers are not allowed";
                        return false;
                    }
                }
            }
            var value = element.Value;
            if (false == String.IsNullOrWhiteSpace(value))
            {
                if (false == this.IsValidElementValue(value))
                {
                    details = String.Format
                        (
                        "The value {0} was not a valid element value",
                        value
                        );
                    return false;
                }
            }
            else
            {
                if (false == this.AllowBlankCaption)
                {
                    details = "Blank values are not allowed";
                    return false;
                }
            }
            return true;
        }
    }
}
