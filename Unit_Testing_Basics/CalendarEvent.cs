using System;

namespace Unit_Testing_Basics
{
    public class CalendarEvent
    {
        public string Name { get; }
        public DateTimeOffset StartsAt { get; }
        public DateTimeOffset EndsAt { get; }
        public string Description { get; }
        public TimeSpan Duration => EndsAt - StartsAt;

        public CalendarEvent(
            string name,
            DateTimeOffset startsAt,
            DateTimeOffset endsAt,
            string description = null)
        {
            Name = name;
            StartsAt = startsAt;
            EndsAt = endsAt;
            Description = description;
        }
    }
}
