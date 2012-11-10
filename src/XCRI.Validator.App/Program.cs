using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCRI.Validation;
using Ninject;
using v = XCRI.Validation;
using mi = XCRI.Validation.XmlExceptionInterpretation;
using xr = XCRI.Validation.XmlRetrieval;
using l = XCRI.Validation.Logging;
using XCRI.Validation.ExtensionMethods;
using m = XCRI.Validation.Modules;
using cv = XCRI.Validation.ContentValidation;
using System.IO;
using XCRI.Validation.Logging;
using XCRI.Validation.Modules;

namespace XCRI.Validator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var logs = new List<ILog>();
            var timedLogs = new List<ITimedLog>();
            timedLogs.Add(new XCRI.Validator.App.Logging.TimedLogToConsole());
            var xmlResolver = new xr.XmlCachingResolver(new [] { new xr.NullXmlCacheLocation() }, logs, timedLogs);
            var source = new xr.UriSource(logs, xmlResolver);
            var validatorFactory = new cv.ValidatorFactory(logs, timedLogs, source);
            var validationModule = new ValidationModule(logs, timedLogs, validatorFactory);
            var interpreterFactory = new mi.InterpreterFactory(logs, timedLogs);
            var interpretationModule = new m.InterpretationModule(logs, timedLogs, interpreterFactory);
            var validationService = new ValidationService<Uri>
            (
                System.Globalization.CultureInfo.CurrentUICulture,
                null,
                null,
                logs,
                timedLogs,
                source,
                xmlResolver
            );
            var runner = new ValidateRunner
                (
                    timedLogs[0],
                    validationService,
                    validationModule,
                    interpretationModule
                );
            System.IO.FileInfo fileToValidate = null;
            System.IO.FileInfo validationModuleLocation = new FileInfo(@"xml-files\ValidationModules\XCRICAP12.xml");
            System.IO.FileInfo interpretationModuleLocation = new FileInfo(@"xml-files\XmlExceptionInterpretation.xml");
            AnalyseArguments
                (
                args, 
                ref fileToValidate,
                ref validationModuleLocation,
                ref interpretationModuleLocation
                );
            runner.FileToValidate = fileToValidate;
            runner.ValidationModuleLocation = validationModuleLocation;
            runner.InterpretationModuleLocation = interpretationModuleLocation;
            runner.Run();
        }
        public static void AnalyseArguments
            (
            string[] args,
            ref System.IO.FileInfo fileToValidate,
            ref System.IO.FileInfo validationModule,
            ref System.IO.FileInfo interpretationModule
            )
        {
            if (null == args)
                return;
            if (1 == args.Length)
            {
                fileToValidate = new FileInfo(args[0]);
                return;
            }
            string value;
            for (var i = 0; i < args.Length; i++)
            {
                var argument = args[i];
                value = "";
                switch ((argument ?? String.Empty) .ToLower())
                {
                    case "-i":
                        value = args[++i];
                        fileToValidate = new FileInfo(value);
                        break;
                    case "-vm":
                        value = args[++i];
                        validationModule = new FileInfo(value);
                        break;
                    case "-im":
                        value = args[++i];
                        interpretationModule = new FileInfo(value);
                        break;
                }
            }
        }
    }
}
