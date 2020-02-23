using System;

namespace XamarinFormsClean.Common.Data.Model.Local
{
    public abstract class BaseData
    {
        public Guid Id { get; set; }

        public string UniqueId =>
            $"{GetType().Name}{Id.ToString()}";

        protected BaseData()
        {
            Id = Guid.NewGuid();
        }
    }
}