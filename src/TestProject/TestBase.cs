using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject
{
    [TestClass]
    public abstract class TestBase<T, A>
            where A : T
    {
        public T Instantiate()
        {
            return Activator.CreateInstance<A>();
        }
        public T Instantiate(params object[] args)
        {
            return (T)Activator.CreateInstance(typeof(A), args);
        }
    }
}
