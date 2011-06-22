C# Test Driven Design
=====================

This library contains a TestBase class to help when using Test Driven Development & Design in C#.

Inheriting from the TestBase class will provide a TestContext property.
The TestContext property is useful for tests involving file I/O and for finding information about the current test run.
See http://msdn.microsoft.com/en-us/library/ms404699.aspx 

		[TestClass]
		public class MyExampleTest : TestBase

Inheriting from the typed TestBase<T> class will provide a test Subject.

		[TestClass]
		public class MyExampleTest : TestBase<MyExample>
