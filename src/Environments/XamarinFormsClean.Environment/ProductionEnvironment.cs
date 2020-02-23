namespace XamarinFormsClean.Environment
{
    public class ProductionEnvironment : BaseEnvironment
    {
        public override string ApiKey { get; } = "";
        
        internal ProductionEnvironment() { }
    }
}