using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Unit_Testing_Basics
{
    // unit tests are code that tests code, that is they assert whether the code behaves as you intend
    // test code is the question, and production code is the answer
    // test code is the documentation, and production code is the behavior
    // test code is the scientific method, and production code is reality to observe
    [TestClass]
    public class UnitTestingMethods
    {
        // most unit tests are testing methods
        [TestMethod]
        public void GetFullName_ReturnsString()
        {
            var person = new Person("test", "person");
            var result = person.GetFullName();

            Assert.IsInstanceOfType(result, typeof(string));
        }

        // when testing, we tend care about input and output first and foremost
        [TestMethod]
        public void GetFullName_ReturnsConcatenatedName()
        {
            var person = new Person("first", "last"); // in goes "first" "last"
            var result = person.GetFullName();

            Assert.AreEqual("first last", result); // out comes "first last" we assert
        }

        // we should test logic (if, for, foreach, switch, etc.) and make sure we cover each possible code path
        [TestMethod]
        public void GetFullName_ReturnsSurnameFirst_GivenTrue()
        {
            var person = new Person("Gary", "Oldman");
            var result = person.GetFullName(true); // this parameter changes our expected behavior

            Assert.AreEqual("Oldman, Gary", result); // we expect to enter the body of the if statement and yield a different result 
        }
    }

    public class Person
    {
        public string GivenName { get; }
        public string Surname { get; }

        public Person(string givenName, string surname)
        {
            GivenName = givenName;
            Surname = surname;
        }

        public string GetFullName(bool isSurnameFirst = false)
        {
            if (isSurnameFirst)
            {
                return $"{Surname}, {GivenName}";
            }

            return $"{GivenName} {Surname}";
        }
    }
}
