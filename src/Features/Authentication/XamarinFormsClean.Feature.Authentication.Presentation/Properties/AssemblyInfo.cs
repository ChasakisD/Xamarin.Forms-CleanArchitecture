using Xamarin.Forms.Xaml;
using XamarinBackgroundKit.Controls;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace XamarinFormsClean.Feature.Authentication.Presentation.Properties
{
    public static class Linker
    {
        static Linker()
        {
            var _ = typeof(MaterialContentView);
        }

        public static void Preserve() { }
    }
}