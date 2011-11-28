using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace TestDrivenDesign
{
    [TestClass]
    public abstract class TestBase<T> : TestBase where T : class, new()
    {
        /// <summary>
        /// The test subject.  A new instance is default constructed for each test method.
        /// </summary>
        public T Subject { get; set; }

        /// <summary>
        /// Allows factoring out code that only differs by which property is being "get"
        /// </summary>
        /// <param name="propertyExpression">For example: () => Subject.MyProperty</param>
        /// <returns>Returns current value of property given by expression</returns>
        protected TProperty Get<TProperty>(Expression<Func<TProperty>> propertyExpression)
        {
            var property = GetProperty(propertyExpression);
            return (TProperty)Get(property);
        }

        /// <summary>
        /// Allows factoring out code that only differs by which property is being "set"
        /// </summary>
        /// <param name="propertyExpression">For example: () => Subject.MyProperty</param>
        /// <returns>Sets value of property given by expression</returns>
        protected void Set<TProperty>(Expression<Func<TProperty>> propertyExpression, TProperty value)
        {
            var property = GetProperty(propertyExpression);
            Set(property, value);
        }

        protected Mock<T> MockSubject()
        {
            var mock = new Mock<T> { CallBase = true };
            Subject = mock.Object;
            return mock;
        }

        protected void Verify(Expression<Action<T>> expression)
        {
            try
            {
                Mock.Get(Subject).Verify(expression);
            }
            catch (MockException)
            {
                // Translate the MockException to an AssertFailedException so it reads better with Microsoft's testing tools
                throw new AssertFailedException("Expected invocation: " + expression.ToString());
            }
        }

        #region Behind the scenes...

        [TestInitialize]
        public void TestInitialize()
        {
            Subject = new T();
        }

        private object Get(PropertyInfo property)
        {
            return property.GetValue(Subject, EmptyArray());
        }

        private void Set(PropertyInfo property, object value)
        {
            property.SetValue(Subject, value, EmptyArray());
        }

        private static PropertyInfo GetProperty<P>(Expression<Func<P>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            return memberExpression.Member as PropertyInfo;
        }

        private static object[] EmptyArray()
        {
            return new object[] { };
        }

        #endregion
    }
}
