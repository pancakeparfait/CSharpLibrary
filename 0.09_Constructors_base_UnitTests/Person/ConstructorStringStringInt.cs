using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _0._09_Constructors_base_UnitTests.Person
{
    // test class is named by its parameter types
    // a test class like this is difficult to name, but this example is guaranteed to be unique no matter how many
    // constructors there are because of the compiler's overloading rules
    [TestClass]
    public class ConstructorStringStringInt
    {
        // some expected values to assert against
        // it's easier to locate these by their symbol rather than use magic strings that are identical but otherwise unrelated
        private const string ExpectedFirstName = "first"; 
        private const string ExpectedLastName = "last"; 
        private const int ExpectedAge = 45; 

        private _09_Constructors_base.Person Act()
        {
            // pass in expected values to constructor under test
            return new _09_Constructors_base.Person(ExpectedFirstName, ExpectedLastName, ExpectedAge);
        }

        // again, be clear in naming what exactly you are testing 
        [TestMethod]
        public void ShouldSetFirstNameProperty()
        {
            var result = Act();

            // assert expected value
            Assert.AreEqual(ExpectedFirstName, result.FirstName);
        }

        [TestMethod]
        public void ShouldSetLastNameProperty()
        {
            var result = Act();

            Assert.AreEqual(ExpectedLastName, result.LastName);
        }

        [TestMethod]
        public void ShouldSetAgeProperty()
        {
            var result = Act();

            Assert.AreEqual(ExpectedAge, result.Age);
        }
    }
}
