using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests;

[TestClass]
public class Class1
{
    public void TestMethod1()
    {
        // Arrange
        var x = 1;
        var y = 2;
        var expected = 3;

        // Act
        var actual = x + y;

        // Assert
        Assert.AreEqual(expected, actual);
    }
}
