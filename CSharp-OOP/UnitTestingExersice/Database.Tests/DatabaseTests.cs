using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWithSixteenElements()
        {
            int[] numbers = Enumerable.Range(1, 16).ToArray();

            Database.Database database = new Database.Database(numbers);

            var expectedResult = 16;
            var actualResult = database.Count;

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void ConstructorShouldThrowExceptionIfLengthIsDifferentFromSixteen()
        {
            int[] numbers = Enumerable.Range(1, 10).ToArray();

            Database.Database database = new Database.Database(numbers);

            var expectedResult = 10;
            var actualResult = database.Count;

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 10).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Add(5);
            var allElements = database.Fetch();

            //Assert
            var expectedValue = 5;
            var actualValue = allElements[10];

            var expectedCount = 11;
            var actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void AddOperationException()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act-Assert

            Assert.Throws<InvalidOperationException>(() => database.Add(10));
        }

        [Test]
        public void RemoveOperationShouldSupportOnlyRemovingElementAtLastIndex()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 16).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            database.Remove();
            //var allElements = database.Fetch(); //

            //Assert
            var expectedValue = 15;
            var actualValue = database.Fetch()[14];

            var expectedCount = 15;
            var actualCount = database.Count;

            Assert.AreEqual(expectedValue, actualValue);

        }

        [Test]
        public void RemoveOperationException()
        {
            int[] numbers = Enumerable.Range(0, 0).ToArray();
            Database.Database database = new Database.Database(numbers);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchShouldReturnAllElementsAsArray()
        {
            //Arrange
            int[] numbers = Enumerable.Range(1, 5).ToArray();
            Database.Database database = new Database.Database(numbers);

            //Act
            var allItems = database.Fetch();

            //Assert
            int[] expectedValue = { 1, 2, 3, 4, 5 };

            CollectionAssert.AreEqual(expectedValue, allItems);

        }
    }
}