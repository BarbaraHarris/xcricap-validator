using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XCRI.Validation.ExtensionMethods
{
    public static class IEnumerableExtensionMethods
    {
        public static IEnumerable<T> Union<T>(this IEnumerable<T> input, T item)
        {
            return input.Union(new T[]{ item });
        }
    }
}
