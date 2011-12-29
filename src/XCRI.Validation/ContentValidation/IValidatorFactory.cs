using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ContentValidation
{
    public interface IValidatorFactory
    {
        T GetValidator<T>() where T : class, IValidator;
    }
}
