using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

        [TestMethod]
        public void ShouldMockAProperty()
        {
            // Act
            Mock<IExampleInterface> mockedProperty =
                MockProperty(() => Subject.MyInterfaceProperty);

            // Assert
            Assert.AreSame(mockedProperty.Object, Subject.MyInterfaceProperty);
        }

        [TestMethod]
        public void ShouldMockSubjectAndCallBaseImplementations()
        {
            // Act
            Mock<ExampleSubject> mock = base.MockSubject();

            // Assert
            Assert.AreSame(Subject, mock.Object, "The Subject is mocked");
            Assert.IsTrue(mock.CallBase, "Because the Subject's behavior is being tested, we default to calling its implementations");
        }

        [TestMethod, ExpectedException(typeof(AssertFailedException))]
        public void ShouldThrowWhenVerifyingMethodThatWasNotCalled()
        {
            // Arrange
            MockSubject();

            // Act
            base.Verify(s => s.MyVirtualMethod());
        }

        [TestMethod]
        public void ShouldNotThrowWhenVerifyingMethodThatWasCalled()
        {
            // Arrange
            MockSubject();
            Subject.MyVirtualMethod();

            // Act
            base.Verify(s => s.MyVirtualMethod());
        }
    }

    public interface IExampleInterface
    {
        int Unimportant { get; }
    }

    public class ExampleSubject
    {
        public int MyProperty { get; set; }
        public IExampleInterface MyInterfaceProperty { get; set; }

        public virtual void MyVirtualMethod()
        {
        }
    }
}
