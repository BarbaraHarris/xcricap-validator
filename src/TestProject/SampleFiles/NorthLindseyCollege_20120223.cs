using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XCRI.Validation.XmlRetrieval;
using System.Xml;

namespace TestProject.SampleFiles
{
    [TestClass]
    public class NorthLindseyCollege_20120223
    {
        public System.Xml.XmlNamespaceManager XmlNamespaceManager = null;
        [TestInitialize]
        public void SetupNamespaceManager()
        {
            this.XmlNamespaceManager = new System.Xml.XmlNamespaceManager(new NameTable());
            this.XmlNamespaceManager.AddNamespace("xcri12", "http://xcri.org/profiles/1.2/catalog");
            this.XmlNamespaceManager.AddNamespace("mlo", "http://purl.org/net/mlo");
            this.XmlNamespaceManager.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
            this.XmlNamespaceManager.AddNamespace("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            this.XmlNamespaceManager.AddNamespace("credit", "http://purl.org/net/cm");
            this.XmlNamespaceManager.AddNamespace("xml", "http://www.w3.org/XML/1998/namespace");
        }
        /*
        [TestMethod]
        public void AllTitlesMustContainATitle()
        {
            XCRI.Validation.ContentValidation.ElementValidator courseValidator = new XCRI.Validation.ContentValidation.ElementValidator()
            {
                XPathSelector = "//xcri12:course",
                NamespaceManager = this.XmlNamespaceManager
            };
            courseValidator.Validators.Add(new XCRI.Validation.ContentValidation.NumberValidator()
            {
                XPathSelector = "count(./dc:title)",
                NamespaceManager = this.XmlNamespaceManager,
                Minimum = 1
            });
            XCRI.Validation.ValidationService<string> validationService = new XCRI.Validation.ValidationService<string>();
            validationService.Source = new XCRI.Validation.XmlRetrieval.StringSource(null, new XmlCachingResolver(null, null, null));
            validationService.XmlContentValidators.Add(courseValidator);
            var results = validationService.Validate(Resources.IValidationService.SampleFiles.NorthLindseyCollege_20120223);
        }
         * */
    }
}
