using XamarinFormsClean.Common.Data.Source.Local.Dao;
using XamarinFormsClean.Feature.Authentication.Data.Model.Local;
using XamarinFormsClean.Feature.Authentication.Data.Source.Local.Dao.Interface;

namespace XamarinFormsClean.Feature.Authentication.Data.Source.Local.Dao
{
    public class SessionDao : BaseSingleDao<SessionData>, ISessionDao { }
}