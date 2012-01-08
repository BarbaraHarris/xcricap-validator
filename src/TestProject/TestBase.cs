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
        public Type BaseType
        {
            get { return typeof(T); }
        }
        public Type ClassType
        {
            get { return typeof(A); }
        }
        public A Instantiate()
        {
            return Activator.CreateInstance<A>();
        }
        public A Instantiate(params object[] args)
        {
            return (A)Activator.CreateInstance(typeof(A), args);
        }
    }
}
