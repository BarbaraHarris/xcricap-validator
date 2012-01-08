using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.Modules
{
    public interface IInterpretationModule
    {
        IEnumerable<XmlExceptionInterpretation.IInterpreter> ExtractInterpreters(System.IO.FileInfo fi);
    }
}
