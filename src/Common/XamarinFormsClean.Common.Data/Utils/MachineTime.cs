using System;

namespace XamarinFormsClean.Common.Data.Utils
{
    public class MachineTime
    {
        public static DateTime Now => DateTime.UtcNow;
        public static DateTimeOffset OffsetNow => DateTimeOffset.UtcNow;
    }
}