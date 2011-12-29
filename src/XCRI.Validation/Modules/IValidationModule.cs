using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace XCRI.Validation.Modules
{
    public interface IValidationModule
    {
        IEnumerable<ContentValidation.IValidator> ExtractValidators(FileInfo fi);
    }
}
