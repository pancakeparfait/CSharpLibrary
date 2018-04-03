using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace (folder) corresponds to the name of the class under test
// we will want multiple test classes, one per method under test, to maximize readability
//  so a folder for the class under test helps us organize
namespace _0._07_Methods_UnitTests.Customer
{
    // unit tests test one thing, usually a method or sometimes a constructor
    // name the test class per the method under test (GetCustomer in this case)
    [TestClass]
    public class GetCustomer
    {
        // class under test that contains the method under test
        private _07_Methods.Customer _customer;

        // AAA paradigm, before each test you need to arrange your class under test
        // an Arrange() function decorated with [TestInitialize] performs arrangement that is common to all your tests
        [TestInitialize]
        public void Arrange()
        {
            _customer = new _07_Methods.Customer();
        }

        // AAA paradigm, encapsulate your function under test in a method with the meaningful name "Act" 
        private string Act()
        {
            return _customer.GetCustomer();
        }

        // use meaningful test names to describe what you intend to assert
        // for non-void functions, return type assertion is useful because you add intention as documentation
        //   later changing the return type forces you to revisit your unit test and confirm you do indeed desire a return type change
        [TestMethod]
        public void GetCustomerShouldReturnString()
        {
            // Act - call the function under test
            var result = Act();

            // write your assertion according to how you named your test
            // we only care to test one thing at a time, so we only test the return type and not its value
            // use Assert library to ensure expected results of the Act()
            Assert.IsInstanceOfType(result, typeof(string));
        }

        // parameterized test methods let us run the same test multiple times for different values
        // this is much more concise than testing all these values in one test, which would obscure results in the case of failure,
        //  or testing them in individual test methods, whcih clutters readability
        [DataTestMethod]
        [DataRow("Frodo", "Baggins", "FrodoBaggins")]
        [DataRow("Gandalf", "Greyhame", "GandalfGreyhame")]
        public void ShouldReturnConcatenatedName(string firstName, string lastName, string expected)
        {
            // additional arrangement relevant to only the current test should be put inside the test method
            _customer.FirstName = firstName;
            _customer.LastName = lastName;

            // Act
            var result = Act();

            // againusing Assert library to ensure expected results
            Assert.AreEqual(expected, result);
        }
    }
}
