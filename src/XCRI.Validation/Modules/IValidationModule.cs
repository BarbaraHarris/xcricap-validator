﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XCRI.Validation.Modules
{
    public interface IValidationModule
    {
        List<Logging.ILog> Logs { get; }
        List<Logging.ITimedLog> TimedLogs { get; }
        ContentValidation.IValidatorFactory ValidatorFactory { get; set; }
        IEnumerable<ContentValidation.IValidator> ExtractValidators(FileInfo fi);
    }
}
