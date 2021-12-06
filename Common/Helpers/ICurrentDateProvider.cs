using System;

namespace Common.Helpers
{
    public interface ICurrentDateProvider
    {
        public DateTimeOffset Now { get; }
        public DateTimeOffset UtcNow { get; }
    }
}
