C# Test Driven Design
=====================

Here is a quick reference of the classes and members available

- TestBase
 - TestContext
 - TestPath()
 - TextPath()
 - TestDirectory()
 - DataValueAsInt(name)
 - DataValueAsFloat(name)
 - DataValueAsString(name)
 - DataValueAsBool(name)
- TestBase<T>
 - Subject
 - Get(propertyExpression)
 - Set(propertyExpression, value)
- DirectoryAssert
 - Exists(directory)
 - Contains(directory, searchPattern)
 - DoesNotContain(directory, searchPattern)
 - IsEmpty(directory)
 - Count(directory, expected)
 - Count(directory, searchPattern, expected)
- TextFileAssert
 - Exists(path)
 - AreEqual(expectedPath, actualPath)
 - Contains(path, expected)
 - ContainsLine(path, expected)
 - StartsWith(path, expected)
 - EndsWith(path, expected)
- BinaryFileAssert
 - Exists(path)
 - AreEqual(expectedPath, actualPath)
 - StartsWith(path, expected)
 - BytesAt(path, byteIndex, expected)
 - [ StartsWith() or BytesAt() ].FollowedBy(expected)

Inheriting from the TestBase class will provide a TestContext property.
The TestContext property is useful for tests involving file I/O and for finding information about the current test run.
See http://msdn.microsoft.com/en-us/library/ms404699.aspx 

		[TestClass]
		public class MyExampleTest : TestBase

Inheriting from the typed TestBase<T> class will provide a test Subject.

		[TestClass]
		public class MyExampleTest : TestBase<MyExample>

Keywords: TDD, Unit Testing, Test Driven Development, Test Driven Design
