using System;
using System.Reactive;

namespace XamarinFormsClean.Common.Data.Source.Local.Dao.Interface
{
    public interface IDao
    {
        IObservable<Unit> Invalidate();
    }
}