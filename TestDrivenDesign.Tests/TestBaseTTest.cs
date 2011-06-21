using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrivenDesign.Tests
{
    [TestClass]
    public class TestBaseTTest : TestBase<ExampleSubject>
    {
        private ExampleSubject _subject1;
        private ExampleSubject _subject2;

        [TestMethod]
        public void Initialization()
        {
            // Arrange
            ExampleSubject subject = base.Subject;

            // Assert
            Assert.IsInstanceOfType(subject, typeof(ExampleSubject));
            Assert.IsInstanceOfType(this, typeof(TestBase));
        }

        [TestMethod]
        public void TestInitializeConstructsNewSubject()
        {
            // Arrange
            var subject1 = Subject;

            // Act
            base.TestInitialize();

            // Assert
            var subject2 = Subject;
            Assert.AreNotSame(subject1, subject2);
        }

        [TestMethod]
        public void DifferentSubjectPerTest1()
        {
            // Act
            _subject1 = Subject;

            // Assert
            Assert.AreNotSame(_subject1, _subject2);
        }

        [TestMethod]
        public void DifferentSubjectPerTest2()
        {
            // Act
            _subject2 = Subject;

            // Assert
            Assert.AreNotSame(_subject1, _subject2);
        }

        [TestMethod]
        public void AbleToFactorOutPropertyGetter()
        {
            // Arrange
            int expected = 12;
            Subject.MyProperty = expected;

            // Act
            var actual = Get(() => Subject.MyProperty);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AbleToFactorOutPropertySetter()
        {
            // Arrange
            int expected = 12;

            // Act
            Set(() => Subject.MyProperty, expected);

            // Assert
            Assert.AreEqual(expected, Subject.MyProperty);
        }
    }

    public class ExampleSubject
    {
        public int MyProperty { get; set; }
    }
}
