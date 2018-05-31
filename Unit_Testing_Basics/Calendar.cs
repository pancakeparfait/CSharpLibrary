using System;
using System.Collections.Generic;
using System.Linq;

namespace Unit_Testing_Basics
{
    public class Calendar
    {
        public string Owner { get; }
        private readonly List<CalendarEvent> _events = new List<CalendarEvent>();
        public IEnumerable<CalendarEvent> Events => _events.AsEnumerable();

        public Calendar(string owner)
        {
            Owner = owner;
        }

        public void AddEvent(CalendarEvent calendarEvent)
        {
            if (calendarEvent == null) throw new ArgumentNullException(nameof(calendarEvent));

            _events.Add(calendarEvent);
        }

        public IEnumerable<CalendarEvent> GetEventsForDate(DateTimeOffset date)
        {
            return _events
                .Where(e => e.StartsAt.Date == date.Date);
        }

        public IEnumerable<CalendarEvent> GetTodaysEvents()
        {
            return GetEventsForDate(DateTimeOffset.Now.Date);
        }
    }
}