using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Testing_Basics.CalendarTests
{
    // unit tests test one thing, usually a method or sometimes a constructor
    // name the test class per the method under test (AddEvent in this case)
    [TestClass]
    public class AddEvent
    {
        // class under test that contains the method under test
        private Calendar _calendar;

        // some constant values for testing can be declared so you don't need magic strings all over the place
        private const string ExpectedOwner = "owner test";

        // AAA paradigm, before each test you need to arrange your class under test
        // an Arrange() function decorated with [TestInitialize] performs arrangement that is common to all your tests
        [TestInitialize]
        public void Arrange()
        {
            _calendar = new Calendar(ExpectedOwner);
        }

        // AAA paradigm, encapsulate your function under test in a method with the meaningful name "Act" 
        private void Act(CalendarEvent calendarEvent)
        {
            _calendar.AddEvent(calendarEvent);
        }

        // use meaningful test names to describe what you intend to assert
        // for non-void functions, return type assertion is useful because you add intention as documentation
        //   later changing the return type forces you to revisit your unit test and confirm you do indeed desire a return type change
        [TestMethod]
        public void ShouldAddEvent()
        {
            var expectedEvent = new CalendarEvent("test", DateTimeOffset.Now, DateTimeOffset.Now.AddHours(3));

            Act(expectedEvent);

            var result = _calendar.Events.Single();
            Assert.AreEqual(expectedEvent, result);
        }

        // test your exception cases as well
        // be very specific about the case you are testing
        // "Should" as basic assertion sentence, "Given" as specific scenario that doesn't conform to the happy path
        [TestMethod]
        public void ShouldThrowArgumentNullException_GivenNullCalendarEvent()
        {
            Assert.ThrowsException<ArgumentNullException>(() => Act(null));
        }
    }
}