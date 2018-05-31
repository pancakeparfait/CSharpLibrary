using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Testing_Basics.CalendarTests
{
    // another example of a method under test with its own test class
    [TestClass]
    public class GetEventsForDate
    {
        private Calendar _calendar;

        private const string ExpectedOwner = "test owner";

        [TestInitialize]
        public void Arrange()
        {
            _calendar = new Calendar(ExpectedOwner);

            var date = DateTimeOffset.Now;
            _calendar.AddEvent(new CalendarEvent("one", date.AddDays(-1), date.AddDays(-1)));
            _calendar.AddEvent(new CalendarEvent("two", date, date));
            _calendar.AddEvent(new CalendarEvent("three", date.AddDays(1), date.AddDays(1)));
            _calendar.AddEvent(new CalendarEvent("four", date.AddDays(1), date.AddDays(1)));
        }

        private IEnumerable<CalendarEvent> Act(DateTimeOffset date)
        {
            return _calendar.GetEventsForDate(date);
        }

        [TestMethod]
        public void ShouldReturnOnlyEventForYesterday()
        {
            var result = Act(DateTimeOffset.Now.AddDays(-1));

            Assert.AreEqual("one", result.Single().Name);
        }

        [TestMethod]
        public void ShouldReturnEventsForTomorrow()
        {
            var result = Act(DateTimeOffset.Now.AddDays(1));

            Assert.AreEqual(2, result.Count());
            Assert.AreEqual("three", result.First().Name);
            Assert.AreEqual("four", result.Last().Name);
        }
    }
}
