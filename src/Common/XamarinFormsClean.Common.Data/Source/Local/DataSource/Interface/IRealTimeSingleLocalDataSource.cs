using System;
using XamarinFormsClean.Common.Data.Model.Local;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface
{
    public interface IRealTimeSingleLocalDataSource<T> : ISingleLocalDataSource<T> where T : BaseData
    {
        IObservable<T> ItemChanged { get; }
    }
}