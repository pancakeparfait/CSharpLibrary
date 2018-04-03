using Microsoft.VisualStudio.TestTools.UnitTesting;

// same class under test, so same namespace (folder)
namespace _0._07_Methods_UnitTests.Customer
{
    // again, name the test class for the method under test for clarity
    [TestClass]
    public class PostInterest
    {
        // class under test
        private _07_Methods.Customer _customer;

        // additional constants used for easy assertions
        private const string ExpectedFirstName = "Jared";

        [TestInitialize]
        public void Arrange()
        {
            _customer = new _07_Methods.Customer
            {
                FirstName = ExpectedFirstName
            };
        }

        // the method under test is parameterized, so we'll do the same for Act, but with a default to handle most test cases
        // which we can easily override
        private string Act(string interest = "default")
        {
            return _customer.PostInterest(interest);
        }

        // tell a story with your test method name
        [TestMethod]
        public void ShouldReturnString()
        {
            var result = Act();

            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void ShouldReturnExpectedString()
        {
            var result = Act();

            Assert.AreEqual("Jared appears interested in a default", result);
        }

        // be very specific about the case you are testing
        // "Should" as basic assertion sentence, "Given" as specific scenario that doesn't conform to the most basic use cases
        [TestMethod]
        public void ShouldReturnDifferentName_GivenNewNameAssigned()
        {
            // "Given" usually means additional arrangement inside the test method
            _customer.FirstName = "Paul";

            var result = Act();

            Assert.AreEqual("Paul appears interested in a default", result);
        }
    }
}
