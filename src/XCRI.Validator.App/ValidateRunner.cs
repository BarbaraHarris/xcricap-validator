using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation;
using XCRI.Validation.Modules;
using XCRI.Validation.Logging;

namespace XCRI.Validator.App
{
    public class ValidateRunner
    {
        public ValidateRunner
            (
            ITimedLog log,
            IValidationService<Uri> validationService,
            IValidationModule validationModule,
            IInterpretationModule interpretationModule
            )
        {
            if (null == log)
                throw new ArgumentNullException("log");
            this.Log = log;
            if (null == validationService)
                throw new ArgumentNullException("validationService");
            this.ValidationService = validationService;
            if (null == validationModule)
                throw new ArgumentNullException("validationModule");
            this.ValidationModule = validationModule;
            if (null == interpretationModule)
                throw new ArgumentNullException("interpretationModule");
            this.InterpretationModule = interpretationModule;
        }
        public IValidationService<Uri> ValidationService { get; private set; }
        public ITimedLog Log { get; private set; }
        public IValidationModule ValidationModule { get; private set; }
        public IInterpretationModule InterpretationModule { get; private set; }
        public System.IO.FileInfo ValidationModuleLocation { get; set; }
        public System.IO.FileInfo InterpretationModuleLocation { get; set; }
        public System.IO.FileInfo FileToValidate { get; set; }
        public bool CanRun()
        {
            return false;
        }
        public void Run()
        {
            IList<ValidationResult> r = null;
            using (this.Log.Step("Validating"))
            {
                var moduleXDocument = System.Xml.Linq.XDocument.Load(this.ValidationModuleLocation.FullName);
                var validators = this.ValidationModule.ExtractValidators(moduleXDocument);
                if (null != validators)
                {
                    foreach (var validator in validators)
                        if (null != validator)
                            this.ValidationService.XmlContentValidators.Add(validator);
                }
                var interpreterXml = System.Xml.Linq.XDocument.Load(this.InterpretationModuleLocation.FullName);
                var interpreters = this.InterpretationModule.ExtractInterpreters(interpreterXml);
                if (null != interpreters)
                {
                    foreach (var interpreter in interpreters)
                        if (null != interpreter)
                            this.ValidationService.XmlExceptionInterpreters.Add(interpreter);
                }
                r = this.ValidationService.Validate
                    (
                    //new Uri(@"file://F:/Users/Craig/Documents/Visual Studio 2010/Projects/JISC/XCRI.Misc/XCRI.Validation.Runner/ou-example.xml", UriKind.Absolute)
                    new Uri("file://" + this.FileToValidate.FullName.Replace("\\", "/"), UriKind.Absolute)
                    );
            }
            using (this.Log.Step("Outputting results"))
            {
                foreach (var result in r
                    .Where(vr => vr.FailedCount > 0)
                    .OrderBy(vr => vr.ValidationGroup)
                    .ThenByDescending(vr => vr.Status))
                {
                    System.Console.WriteLine
                        (
                        "{0}\t{1}\t{2}\t({3}/{4} passed)",
                        result.ValidationGroup,
                        result.Status,
                        result.Message,
                        result.SuccessCount,
                        result.Count
                        );
                }
            }
        }
    }
}
