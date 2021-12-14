using Common.Extensions.Contracts;
using System;

namespace Common.Extensions.Concrete
{
    public class DateTimeOffsetRange : IRange<DateTimeOffset>
    {
        public DateTimeOffsetRange(DateTimeOffset start, DateTimeOffset end)
        {
            Start = start;
            End = end;
        }

        public DateTimeOffset Start { get; }
        public DateTimeOffset End { get; }

        public bool Includes(DateTimeOffset value)
        {
            return (value >= Start) && (value <= End);
        }

        public bool Includes(IRange<DateTimeOffset> range)
        {
            return (Start <= range.Start) && (range.End < End);
        }
    }
}
