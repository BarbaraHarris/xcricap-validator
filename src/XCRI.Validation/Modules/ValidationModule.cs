using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;
using XCRI.Validation.ExtensionMethods;

namespace XCRI.Validation.Modules
{
    public class ValidationModule : IValidationModule
    {
        public List<Logging.ILog> Logs { get; private set; }
        public List<Logging.ITimedLog> TimedLogs { get; private set; }
        public ContentValidation.IValidatorFactory ValidatorFactory { get; set; }
        public ValidationModule
            (
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs,
            ContentValidation.IValidatorFactory validatorFactory
            )
            : base()
        {
            if (null == logs)
                this.Logs = new List<Logging.ILog>();
            else
                this.Logs = new List<Logging.ILog>(logs);
            if (null == timedLogs)
                this.TimedLogs = new List<Logging.ITimedLog>();
            else
                this.TimedLogs = new List<Logging.ITimedLog>(timedLogs);
            this.ValidatorFactory = validatorFactory;
        }

        public IEnumerable<ContentValidation.IValidator> ExtractValidators
            (
            FileInfo fi
            )
        {
            if (null == fi)
                throw new ArgumentNullException("fi");
            if (fi.Exists == false)
                throw new ArgumentException("The file must exist to be called in this manner", "fi");
            // Grab reference to doc
            var xdoc = XDocument.Load(fi.FullName);
            var xmlnsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            // Extract namespace details
            foreach (var node in xdoc.XPathSelectElements("/contentValidators/namespaces/add"))
            {
                xmlnsmgr.AddNamespace
                    (
                    node.Attribute("prefix").Value,
                    node.Attribute("namespace").Value
                    );
            }
            // Extract document validators
            foreach (var node in xdoc.XPathSelectElements("/contentValidators/documentValidation"))
            {
                var d = new ContentValidation.DocumentValidator()
                {
                    NamespaceManager = xmlnsmgr
                };
                if (null != this.Logs)
                    foreach (var l in this.Logs)
                        d.Logs.Add(l);
                if (null != this.TimedLogs)
                    foreach (var l in this.TimedLogs)
                        d.TimedLogs.Add(l);
                foreach (var validatorNode in node.XPathSelectElements("./*"))
                {
                    var v = this.ExtractValidator(validatorNode);
                    v.NamespaceManager = xmlnsmgr;
                    d.Validators.Add(v);
                }
                yield return d;
            }
            // Extract element validators
            foreach (var node in xdoc.XPathSelectElements("/contentValidators/elementValidation"))
            {
                var selector = node.Attribute("selector").Value;
                var e = new ContentValidation.ElementValidator()
                {
                    NamespaceManager = xmlnsmgr,
                    XPathSelector = selector
                };
                if (null != this.Logs)
                    foreach (var l in this.Logs)
                        e.Logs.Add(l);
                if (null != this.TimedLogs)
                    foreach (var l in this.TimedLogs)
                        e.TimedLogs.Add(l);
                foreach (var validatorNode in node.XPathSelectElements("./*"))
                {
                    var v = this.ExtractValidator(validatorNode);
                    v.NamespaceManager = xmlnsmgr;
                    e.Validators.Add(v);
                }
                yield return e;
            }
        }
        public ContentValidation.IValidator ExtractValidator
            (
            XElement validatorNode
            )
        {
            if (null == validatorNode)
                throw new ArgumentNullException("validatorNode");
            if (null == this.ValidatorFactory)
                throw new InvalidOperationException("The ValidatorFactory property must not be null in order to extract validators from an XML file");
            ContentValidation.IValidator validator = null;
            decimal value;
            switch (validatorNode.Name.LocalName.ToLower())
            {
                case "urlvalidator":
                    var urlvalidator = this.ValidatorFactory.GetValidator<ContentValidation.UrlValidator>();
                    if (
                        (null != validatorNode.Attribute("allowRelative"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("allowRelative").Value))
                        )
                        urlvalidator.AllowRelative = (validatorNode.Attribute("allowRelative").Value.ToLower() == "true");
                    validator = urlvalidator;
                    break;
                case "uniquevalidator":
                    var uniquevalidator = this.ValidatorFactory.GetValidator<ContentValidation.UniqueValidator>();
                    if (
                        (null != validatorNode.Attribute("uniqueAcross"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("uniqueAcross").Value))
                        )
                        uniquevalidator.UniqueAcross = validatorNode.Attribute("uniqueAcross").Value
                            .ParseEnumFrom<ContentValidation.UniqueValidator.UniqueAcrossTypes>();
                    validator = uniquevalidator;
                    break;
                case "emptyelementvalidator":
                    var emptyElementValidator = this.ValidatorFactory.GetValidator<ContentValidation.EmptyElementValidator>();
                    if (
                        (null != validatorNode.Attribute("enforcementType"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("enforcementType").Value))
                        )
                        emptyElementValidator.EnforcementType = validatorNode.Attribute("enforcementType").Value
                            .ParseEnumFrom<ContentValidation.EmptyElementValidator.EnforcementTypes>();
                    validator = emptyElementValidator;
                    break;
                case "manualvalidator":
                    var manualvalidator = this.ValidatorFactory.GetValidator<ContentValidation.ManualValidator>();
                    validator = manualvalidator;
                    break;
                case "numbervalidator":
                    var numbervalidator = this.ValidatorFactory.GetValidator<ContentValidation.NumberValidator>();
                    if (
                        (null != validatorNode.Attribute("minimum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("minimum").Value))
                        &&
                        (decimal.TryParse(validatorNode.Attribute("minimum").Value, out value))
                        )
                        numbervalidator.Minimum = value;
                    if (
                        (null != validatorNode.Attribute("maximum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("maximum").Value))
                        &&
                        (decimal.TryParse(validatorNode.Attribute("maximum").Value, out value))
                        )
                        numbervalidator.Maximum = value;
                    validator = numbervalidator;
                    break;
                case "positiveintegervalidator":
                    var positiveIntegerValidator = this.ValidatorFactory.GetValidator<ContentValidation.PositiveIntegerValidator>();
                    if (
                        (null != validatorNode.Attribute("minimum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("minimum").Value))
                        &&
                        (decimal.TryParse(validatorNode.Attribute("minimum").Value, out value))
                        )
                        positiveIntegerValidator.Minimum = value;
                    if (
                        (null != validatorNode.Attribute("maximum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("maximum").Value))
                        &&
                        (decimal.TryParse(validatorNode.Attribute("maximum").Value, out value))
                        )
                        positiveIntegerValidator.Maximum = value;
                    validator = positiveIntegerValidator;
                    break;
                case "numberperlanguagevalidator":
                    var numberPerLanguageValidator = this.ValidatorFactory.GetValidator<ContentValidation.NumberPerLanguageValidator>();
                    if (
                        (null != validatorNode.Attribute("minimum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("minimum").Value))
                        &&
                        (decimal.TryParse(validatorNode.Attribute("minimum").Value, out value))
                        )
                        numberPerLanguageValidator.Minimum = value;
                    if (
                        (null != validatorNode.Attribute("maximum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("maximum").Value))
                        &&
                        (decimal.TryParse(validatorNode.Attribute("maximum").Value, out value))
                        )
                        numberPerLanguageValidator.Maximum = value;
                    if (
                        (null != validatorNode.Attribute("childElementSelector"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("childElementSelector").Value))
                        )
                        numberPerLanguageValidator.ChildElementSelector = validatorNode.Attribute("childElementSelector").Value;
                    validator = numberPerLanguageValidator;
                    break;
                case "stringlengthvalidator":
                    var stringlengthvalidator = this.ValidatorFactory.GetValidator<ContentValidation.StringLengthValidator>();
                    int slvalue;
                    if (
                        (null != validatorNode.Attribute("minimum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("minimum").Value))
                        &&
                        (int.TryParse(validatorNode.Attribute("minimum").Value, out slvalue))
                        )
                        stringlengthvalidator.MinimumCharacters = slvalue;
                    if (
                        (null != validatorNode.Attribute("maximum"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("maximum").Value))
                        &&
                        (int.TryParse(validatorNode.Attribute("maximum").Value, out slvalue))
                        )
                        stringlengthvalidator.MaximumCharacters = slvalue;
                    validator = stringlengthvalidator;
                    break;
                case "regularexpressionvalidator":
                    var regularExpressionValidator = this.ValidatorFactory.GetValidator<ContentValidation.RegularExpressionValidator>();
                    if (
                        (null != validatorNode.Attribute("pattern"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("pattern").Value))
                        )
                        regularExpressionValidator.Pattern = validatorNode.Attribute("pattern").Value;
                    if (
                        (null != validatorNode.Attribute("isCaseSensitive"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("isCaseSensitive").Value))
                        )
                        regularExpressionValidator.IsCaseSensitive = Boolean.Parse(validatorNode.Attribute("isCaseSensitive").Value);
                    validator = regularExpressionValidator;
                    break;
                case "agevalidator":
                    var ageValidator = this.ValidatorFactory.GetValidator<ContentValidation.AgeValidator>();
                    validator = ageValidator;
                    break;
                case "vdexvalidator":
                    var vdexValidator = this.ValidatorFactory.GetValidator<ContentValidation.VDEXValidator>();
                    vdexValidator.VDEXLocation = new Uri(validatorNode.Attribute("vdexLocation").Value, UriKind.RelativeOrAbsolute);
                    if (
                        (null != validatorNode.Attribute("filterByXsiType"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("filterByXsiType").Value))
                        )
                        vdexValidator.FilterByXsiType = Boolean.Parse(validatorNode.Attribute("filterByXsiType").Value);
                    if (
                        (null != validatorNode.Attribute("xsiTypeFilterExpectedNamespace"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("xsiTypeFilterExpectedNamespace").Value))
                        )
                        vdexValidator.XsiTypeFilterExpectedNamespace = validatorNode.Attribute("xsiTypeFilterExpectedNamespace").Value;
                    if (
                        (null != validatorNode.Attribute("xsiTypeFilterExpectedType"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("xsiTypeFilterExpectedType").Value))
                        )
                        vdexValidator.XsiTypeFilterExpectedType = validatorNode.Attribute("xsiTypeFilterExpectedType").Value;
                    validator = vdexValidator;
                    break;
                case "postcodevalidator":
                    var postcodeValidator = this.ValidatorFactory.GetValidator<ContentValidation.PostCodeValidator>();
                    validator = postcodeValidator;
                    break;
                case "uktelephonenumbervalidator":
                    var ukTelephoneNumberValidator = this.ValidatorFactory.GetValidator<ContentValidation.UKTelephoneNumberValidator>();
                    validator = ukTelephoneNumberValidator;
                    break;
                case "emailaddressvalidator":
                    var emailAddressValidator = this.ValidatorFactory.GetValidator<ContentValidation.EmailAddressValidator>();
                    validator = emailAddressValidator;
                    break;
                case "languagevalidator":
                    var languageValidator = this.ValidatorFactory.GetValidator<ContentValidation.LanguageValidator>();
                    validator = languageValidator;
                    break;
                case "durationvalidator":
                    var durationValidator = this.ValidatorFactory.GetValidator<ContentValidation.DurationValidator>();
                    validator = durationValidator;
                    break;
            }
            if (null == validator)
                throw new InvalidDataException(String.Format
                    (
                    "The validator type {0} was not handled",
                    validatorNode.Name
                    ));
            validator.XPathSelector
                = validatorNode.Attribute("selector").Value;
            validator.ExceptionMessage
                = validatorNode.Attribute("message").Value;
            validator.FailedValidationStatus
                = validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>();
            validator.FurtherInformation 
                = validatorNode.XPathSelectElement("./furtherInformation");
            if (
                (null != validatorNode.Attribute("validationGroup"))
                &&
                (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                )
                validator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
            return validator;
        }
    }
}
