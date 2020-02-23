namespace XamarinFormsClean.Environment
{
    public class DevelopmentEnvironment : BaseEnvironment
    {
        public override string ApiKey { get; } = "";
        
        internal DevelopmentEnvironment() { }
    }
}