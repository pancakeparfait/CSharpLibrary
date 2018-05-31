using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Introduction_to_the_Test_Runner
{
    // test classes and test methods must have the "public" access modifier so the Test Runner can find them after a build completes
    // the Test Runner will instantiate a test class once for a full run of test methods, so stateful members will persist until all
    // tess have run
    [TestClass]
    public class UnitTestClassWithInitializeExample
    {
        private CalendarEvent _calendarEvent;

        // a method with the TestInitializeAttribute is run once before each test
        // this is a good place to write common setup code
        [TestInitialize]
        public void BeforeEachTest() // this can be called anything, but it's helpful to call it something meaningful
        {
            _calendarEvent = new CalendarEvent(
                new DateTime(2018, 12, 25, 13, 00, 00),
                new DateTime(2018, 12, 25, 18, 30, 00)); // we will get a new instance in our private field right before each test is run
        }

        [TestMethod]
        public void TestAssertionWithDurationProperty()
        {
            // using MSTest's Assert library, we can write meaningful tests that make assertions about code
            var result = _calendarEvent.Duration;

            Assert.AreEqual(new TimeSpan(0, 5, 30, 0), result);
        }

        [TestMethod]
        public void TestDurationPropertyIsNotNegative()
        {
            var result = _calendarEvent.Duration;

            Assert.IsTrue(result.Ticks > 0, "Duration should not be negative."); // the optional message parameter is included in the output on failure
        }

        [TestMethod]
        public void TestDurationPropertyReturnType()
        {
            // you can test types!
            var result = _calendarEvent.Duration;

            Assert.IsInstanceOfType(result, typeof(TimeSpan));
        }
    }

    public class CalendarEvent
    {
        public DateTime StartsAt { get; }
        public DateTime EndsAt { get; }

        public CalendarEvent(DateTime startsAt, DateTime endsAt)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        public TimeSpan Duration => EndsAt - StartsAt;
    }
}
