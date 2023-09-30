namespace test;
using StringExtractors;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual("d", StringExtractor.Extract("abcdefg", "abc", "efg").Value);
    }

    [TestMethod]
    public void TestMethod2()
    {
        Assert.AreEqual("", StringExtractor.Extract("abcdefg", "abc", "defg").Value);
    }

    [TestMethod]
    public void TestMethod3()
    {
        Assert.AreEqual("bcdef", StringExtractor.Extract("abcdefg", "a", "g").Value);
    }

    [TestMethod]
    public void TestMethod4()
    {
        Assert.AreEqual("abc", StringExtractor.Extract("abcdefg", rightString: "defg").Value);
    }

    [TestMethod]
    public void TestMethod5()
    {
        Assert.AreEqual("defg", StringExtractor.Extract("abcdefg", leftString: "abc").Value);
    }

    [TestMethod]
    public void TestMethod6()
    {
        Assert.AreEqual("abcdefg", StringExtractor.Extract("abcdefg", null, null).Value);
    }

    [TestMethod]
    public void TestMethod7()
    {
        Assert.AreEqual("d", StringExtractor.Extract("abcdefg", "c", "e").Value);
    }

    [TestMethod]
    public void TestMethod8()
    {
        Assert.AreEqual("abc", StringExtractor.Extract("abcabcdef", "abc", "d").Value);
    }

    [TestMethod]
    public void TestMethod9()
    {
        Assert.AreEqual("a", StringExtractor.Extract("abcabcdef", "abc", "b").Value);
    }

    [TestMethod]
    public void TestMethod10()
    {
        Assert.AreEqual("bc", StringExtractor.Extract("abcabcdef", "a", "a").Value);
    }

    [TestMethod]
    public void TestMethod11()
    {
        Assert.AreEqual("bcd", StringExtractor.Extract(
            "abcabcdef",
            new LeftString("a") { SearchDirection = SearchDirection.Backward },
            new RightString("e")).Value);
    }

    [TestMethod]
    public void TestMethod12()
    {
        Assert.AreEqual("1ca2", StringExtractor.Extract(
            "a1ca2cdef",
            new LeftString("a"),
            new RightString("c") { SearchDirection = SearchDirection.Backward }).Value);
    }

    [TestMethod]
    public void TestMethod13()
    {
        Assert.AreEqual("2", StringExtractor.Extract(
            "a1ca2cdef",
            new LeftString("a") { SearchDirection = SearchDirection.Backward },
            new RightString("c") { SearchDirection = SearchDirection.Backward }).Value);
    }
}