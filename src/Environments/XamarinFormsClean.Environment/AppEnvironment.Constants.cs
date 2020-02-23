namespace XamarinFormsClean.Environment
{
    public partial class AppEnvironment
    {
        public static class Config
        {
            public static class Db
            {
                public const string FileName = "xamarin-forms-clean.db";
                public const string SecureFileName = "xamarin-forms-clean-secure.db";

                public static class Keys
                {
                    public const string SessionKey = "active-session-key";
                }
            }
            
            public static class Api
            {
                public const string BaseUrl = "https://api.themoviedb.org/3";
                public const string AuthenticationHeader = "Authorization: ApiKey";
            }
        }
    }
}