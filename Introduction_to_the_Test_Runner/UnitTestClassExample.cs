using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Introduction_to_the_Test_Runner
{
    // the TestClassAttribute decorates a class to tell the Visual Studio Test Explorer it can find tests here
    [TestClass]
    public class UnitTestClassExample
    {
        // the TestMethodAttribute represents a single thing to test
        // the Test Explorer lists all methods decorated with the TestMethodAttribute as individual tests
        // test methods use return type void
        [TestMethod]
        public void EmptyTest()
        {
            // Tests that do not throw an exception are considered passing tests, even if empty
        }

        [TestMethod]
        public void FailingTest()
        {
            // Tests that throw any kind of exception are considered failing tests
            // Exception stack traces are linked in the box below the list of tests in the Test Explorer
            throw new Exception("failure");
        }

        [TestMethod]
        public void TestWithConsole()
        {
            // In order to see some output in the Test Explorer, you can use Console
            // Output content is linked in the box below the list of tests in the Test Explorer
            Console.WriteLine("Output to test explorer");
        }

        [TestMethod]
        public void TestWithTrace()
        {
            // Test explorer output can also come from the Trace library
            // Trace content is also linked in the box below the list of tests in the Test Explorer
            Trace.WriteLine("Trace to test explorer");
        }

        [TestMethod]
        public void TestingSomeLogic()
        {
            // You can use a test to see how bits of code work without the overhead of a whole console app
            var content = "string interpolation";
            var result = $"see how some {content} works";

            Console.WriteLine(result);
        }

        [TestMethod]
        public void TestingSomeBigMath()
        {
            // You can run almost any snippet of code inside a test method, including literal math
            var result = 10405683 / 4353;

            Console.WriteLine(result); // should be 2390
        }

        [TestMethod]
        public void TestingObjects()
        {
            // You can create instances of objects in tests, since they are just methods
            var result = new TestObject("test name", new DateTime(1998, 01, 01));

            // And you can output their properties and such to observe behavior
            Console.WriteLine(result.Name);
            Console.WriteLine(result.BirthDate.ToShortDateString());
        }

        // you can decorate a test method with DataTestMethodAttribute to parameterize test methods
        // and the Test Runner will execute the method once for each set of parameters
        [DataTestMethod]
        [DataRow("param one")]
        [DataRow("param two")]
        public void TestingParameterizedMethods(string parameter)
        {
            Console.WriteLine(parameter); // shows two outputs, one for each DataRowAttribute
        }

        [DataTestMethod]
        [DataRow("Bilbo", "Baggins", "Bag End", 111)] // you can put any compile-time constant values here
        [DataRow("John", "Cena", "West Newbury, MA", 40)]
        public void TestingMultipleParameterSets(string givenName, string surname, string address, int age)
        {
            // each run of the test method can succeed or fail independently, but if any fail, the test is listed under "Failed Tests"
            // and the output box lists each test
            if (surname != "Cena") throw new Exception("Never give up!");
        }
    }

    public class TestObject
    {
        public string Name { get; }
        public DateTime BirthDate { get; }

        public TestObject(string name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }
    }
}
