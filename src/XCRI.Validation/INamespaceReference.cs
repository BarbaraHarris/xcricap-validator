using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation
{
    public interface INamespaceReference
    {
        Uri Namespace { get; }
        string Prefix { get; }
    }
}
