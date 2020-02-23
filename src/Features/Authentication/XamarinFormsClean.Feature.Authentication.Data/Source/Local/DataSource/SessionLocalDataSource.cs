using XamarinFormsClean.Common.Data.Source.Local.DataSource;
using XamarinFormsClean.Environment;
using XamarinFormsClean.Feature.Authentication.Data.Model.Local;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.Dao.Interface;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.DataSource.Interface;

namespace XamarinFormsClean.Feature.Authentication.Data.Source.Local.DataSource
{
    public class SessionLocalDataSource : BaseRealTimeSingleLocalDataSource<SessionData>, ISessionLocalDataSource
    {
        protected override string ItemKey { get; } = AppEnvironment.Config.Db.Keys.SessionKey;
        
        public SessionLocalDataSource(ISessionDao singleDao) : base(singleDao) { }
    }
}