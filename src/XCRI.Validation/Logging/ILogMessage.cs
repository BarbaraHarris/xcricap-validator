﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Logging
{
    public interface ILogMessage : ILogEntry
    {
        string Message { get; set; }
    }
}
