using System;
using System.Collections.Generic;
using XamarinFormsClean.Common.Data.Model.Local;

namespace XamarinFormsClean.Common.Data.Source.Local.DataSource.Interface
{
    public interface IRealTimeLocalDataSource<out T> where T : BaseData
    {
        IObservable<IEnumerable<T>> ItemsChanged { get; }
    }
}