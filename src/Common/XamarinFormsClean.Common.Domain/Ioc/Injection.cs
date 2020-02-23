using System;
using Prism.Ioc;

namespace XamarinFormsClean.Common.Domain.Ioc
{
    public static class Injection
    {
        private static IContainerExtension? _current;
        public static IContainerExtension Current
        {
            get => _current ?? 
                throw new InvalidOperationException("Container not initialized");
            set => _current = value;
        }
    }
}