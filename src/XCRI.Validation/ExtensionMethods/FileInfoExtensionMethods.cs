using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml.XPath;

namespace XCRI.Validation.ExtensionMethods
{
    public static class FileInfoExtensionMethods
    {
        public static void ExtractValidationServiceInformation
            (
            this FileInfo fi,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs,
            out IEnumerable<ContentValidation.IValidator> validators
            )
        {
            if(null == fi)
                throw new ArgumentNullException("fi");
            if (fi.Exists == false)
                throw new ArgumentException("The file must exist to be called in this manner", "fi");
            // Grab reference to doc
            var xdoc = XDocument.Load(fi.FullName);
            var xmlnsmgr = new System.Xml.XmlNamespaceManager(new System.Xml.NameTable());
            var v = new List<ContentValidation.IValidator>();
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
                var d = new ContentValidation.DocumentValidator(xmlnsmgr, logs, timedLogs);
                foreach (var validatorNode in node.XPathSelectElements("./*"))
                {
                    d.Validators.Add(validatorNode.ExtractValidator(xmlnsmgr, logs, timedLogs));
                }
                v.Add(d);
            }
            // Extract element validators
            foreach (var node in xdoc.XPathSelectElements("/contentValidators/elementValidation"))
            {
                var selector = node.Attribute("selector").Value;
                var d = new ContentValidation.ElementValidator(xmlnsmgr, selector, logs, timedLogs);
                foreach (var validatorNode in node.XPathSelectElements("./*"))
                {
                    d.Validators.Add(validatorNode.ExtractValidator(xmlnsmgr, logs, timedLogs));
                }
                v.Add(d);
            }
            validators = v;
        }
        private static ContentValidation.IValidator ExtractValidator
            (
            this XElement validatorNode, 
            System.Xml.XmlNamespaceManager xmlnsmgr,
            IEnumerable<Logging.ILog> logs,
            IEnumerable<Logging.ITimedLog> timedLogs
            )
        {
            if (null == validatorNode)
                throw new ArgumentNullException("validatorNode");
            if (null == xmlnsmgr)
                throw new ArgumentNullException("xmlnsmgr");
            switch (validatorNode.Name.LocalName.ToLower())
            {
                case "urlvalidator":
                    var urlvalidator = new ContentValidation.UrlValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(), 
                        logs, 
                        timedLogs
                        );
                    if (
                        (null != validatorNode.Attribute("allowRelative"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("allowRelative").Value))
                        )
                        urlvalidator.AllowRelative = (validatorNode.Attribute("allowRelative").Value.ToLower() == "true");
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        urlvalidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    return urlvalidator;
                case "uniquevalidator":
                    var uniquevalidator = new ContentValidation.UniqueValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(),
                        logs,
                        timedLogs
                        );
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        uniquevalidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    if (
                        (null != validatorNode.Attribute("uniqueAcross"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("uniqueAcross").Value))
                        )
                        uniquevalidator.UniqueAcross = validatorNode.Attribute("uniqueAcross").Value
                            .ParseEnumFrom<ContentValidation.UniqueValidator.UnqiueAcrossTypes>();
                    return uniquevalidator;
                case "emptyelementvalidator":
                    var emptyElementValidator = new ContentValidation.EmptyElementValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(),
                        logs,
                        timedLogs
                        );
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        emptyElementValidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    if (
                        (null != validatorNode.Attribute("enforcementType"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("enforcementType").Value))
                        )
                        emptyElementValidator.EnforcementType = validatorNode.Attribute("enforcementType").Value
                            .ParseEnumFrom<ContentValidation.EmptyElementValidator.EnforcementTypes>();
                    return emptyElementValidator;
                case "manualvalidator":
                    var manualvalidator = new ContentValidation.ManualValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(),
                        logs,
                        timedLogs
                        );
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        manualvalidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    return manualvalidator;
                case "numbervalidator":
                    var numbervalidator = new ContentValidation.NumberValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(),
                        logs,
                        timedLogs
                        );
                    decimal value;
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
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        numbervalidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    return numbervalidator;
                case "stringlengthvalidator":
                    var stringlengthvalidator = new ContentValidation.StringLengthValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(),
                        logs,
                        timedLogs
                        );
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
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        stringlengthvalidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    return stringlengthvalidator;
                case "regularexpressionvalidator":
                    var regularExpressionValidator = new ContentValidation.RegularExpressionValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(),
                        logs,
                        timedLogs
                        );
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        regularExpressionValidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    if (
                        (null != validatorNode.Attribute("pattern"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("pattern").Value))
                        )
                        regularExpressionValidator.Pattern = validatorNode.Attribute("pattern").Value;
                    return regularExpressionValidator;
                case "agevalidator":
                    var ageValidator = new ContentValidation.AgeValidator
                        (
                        null,
                        xmlnsmgr,
                        validatorNode.Attribute("selector").Value,
                        validatorNode.Attribute("message").Value,
                        validatorNode.Attribute("status").Value.ParseEnumFrom<ContentValidation.ValidationStatus>(),
                        logs,
                        timedLogs
                        );
                    if (
                        (null != validatorNode.Attribute("validationGroup"))
                        &&
                        (false == String.IsNullOrEmpty(validatorNode.Attribute("validationGroup").Value))
                        )
                        ageValidator.ValidationGroup = validatorNode.Attribute("validationGroup").Value;
                    return ageValidator;
                default:
                    throw new NotImplementedException(String.Format
                        (
                        "The validator type {0} was not handled",
                        validatorNode.Name
                        ));
            }
        }
    }
}
