﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;

namespace XCRI.Validation
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class NinjectResolver : Ninject.Modules.NinjectModule, IResolver
    {
        private readonly StandardKernel _kernel;

        public NinjectResolver()
        {
            _kernel = new StandardKernel(this);
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public IEnumerable<T> ResolveAll<T>()
        {
            return _kernel.GetAll<T>();
        }

        public override void Load()
        {
            
        }
    }
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class IoC
    {
        private static IResolver _resolver;

        public static T Resolve<T>()
        {
            try
            {
                return _resolver.Resolve<T>();
            }
            catch (ActivationException e)
            {
                throw new IoCDependencyInjectionNotFoundException<T>(e);
            }
        }

        public static IEnumerable<T> ResolveAll<T>()
        {
            return _resolver.ResolveAll<T>();
        }

        public static void Initialize(IResolver resolver)
        {
            _resolver = resolver;
        }
        public static void Initialize<T>(T resolver, Action<T> loadAction)
            where T : IResolver
        {
            _resolver = resolver;
            if (null != loadAction)
                loadAction(resolver);
        }
    }
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [Serializable]
    public class IoCDependencyInjectionNotFoundException<T> : ActivationException
    {
        public IoCDependencyInjectionNotFoundException()
            : base("Dependency injection for " + typeof(T) + " not found")
        {
        }
        public IoCDependencyInjectionNotFoundException(ActivationException innerException)
            : base("Dependency injection for " + typeof(T) + " not found", innerException)
        {
        }
    }
    public interface IResolver
    {
        T Resolve<T>();
        IEnumerable<T> ResolveAll<T>();
    }
}
