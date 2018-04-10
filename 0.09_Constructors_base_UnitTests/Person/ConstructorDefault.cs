using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _0._09_Constructors_base_UnitTests.Person
{
    // negative tests can be useful as well to assert when something doesn't happen
    // folder/namespace named for the class under test
    // test class named for the constructor under test (the default parameterless one)
    [TestClass]
    public class ConstructorDefault
    {
        // AAA paradigm
        private _09_Constructors_base.Person Act()
        {
            // use the expected default constructor
            return new _09_Constructors_base.Person();
        }

        // when testing negative cases, be just as clear with your test names
        [TestMethod]
        public void ShouldNotSetFirstNameProperty()
        {
            var result = Act();

            // strings default to null, so I would choose one of these two ways to test this, but not both
            Assert.IsNull(result.FirstName);
            Assert.AreEqual(default(string), result.FirstName);
        }

        [TestMethod]
        public void ShouldNotSetLastNameProperty()
        {
            var result = Act();

            // one of these two is a fine test
            Assert.IsNull(result.LastName);
            Assert.AreEqual(default(string), result.LastName);
        }

        [TestMethod]
        public void ShouldNotSetAgeProperty()
        {
            var result = Act();

            // int defaults to 0, so while the first of these expresses the expectation better, the second asserts the same thing
            Assert.AreEqual(default(int), result.Age);
            Assert.AreEqual(0, result.Age);
        }
    }
}
