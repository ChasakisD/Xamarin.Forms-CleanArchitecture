using System;
using System.Threading;

namespace XamarinFormsClean.Environment
{
    public partial class AppEnvironment
    {
        private static readonly Lazy<BaseEnvironment> DevelopmentLazy =
            new Lazy<BaseEnvironment>(
                () => new DevelopmentEnvironment(), 
                LazyThreadSafetyMode.PublicationOnly);

        public static BaseEnvironment Development => DevelopmentLazy.Value;

        private static readonly Lazy<BaseEnvironment> ProductionLazy =
            new Lazy<BaseEnvironment>(
                () => new ProductionEnvironment(),
                LazyThreadSafetyMode.PublicationOnly);

        public static BaseEnvironment Production => ProductionLazy.Value;

        public static BaseEnvironment Default
        {
            get
            {
#if DEBUG
                return Development;
#else
                return Production;
#endif
            }
        }
    }
}