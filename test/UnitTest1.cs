namespace test;
using StringExtractors;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestMethod1()
    {
        var rslt = StringExtractor.Extract("abcdefg", "abc", "efg");

        Assert.AreEqual("d", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(3, rslt.IndexCollection.Head);
        Assert.AreEqual(4, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod2()
    {
        var rslt = StringExtractor.Extract("abcdefg", "abc", "defg");

        Assert.AreEqual("", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(null, rslt.IndexCollection.Head);
        Assert.AreEqual(3, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod3()
    {
        var rslt = StringExtractor.Extract("abcdefg", "a", "g");
        Assert.AreEqual("bcdef", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(1, rslt.IndexCollection.Head);
        Assert.AreEqual(6, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod4()
    {
        var rslt = StringExtractor.Extract("abcdefg", rightString: "defg");
        Assert.AreEqual("abc", rslt.Value);
        Assert.AreEqual(null, rslt.IndexCollection.Left);
        Assert.AreEqual(0, rslt.IndexCollection.Head);
        Assert.AreEqual(3, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod5()
    {
        var rslt = StringExtractor.Extract("abcdefg", leftString: "abc");
        Assert.AreEqual("defg", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(3, rslt.IndexCollection.Head);
        Assert.AreEqual(null, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod6()
    {
        var rslt = StringExtractor.Extract("abcdefg", null, null);
        Assert.AreEqual("abcdefg", rslt.Value);
        Assert.AreEqual(null, rslt.IndexCollection.Left);
        Assert.AreEqual(0, rslt.IndexCollection.Head);
        Assert.AreEqual(null, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod7()
    {
        var rslt = StringExtractor.Extract("abcdefg", "c", "e");
        Assert.AreEqual("d", rslt.Value);
        Assert.AreEqual(2, rslt.IndexCollection.Left);
        Assert.AreEqual(3, rslt.IndexCollection.Head);
        Assert.AreEqual(4, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod8()
    {
        var rslt = StringExtractor.Extract("abcabcdef", "abc", "d");
        Assert.AreEqual("abc", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(3, rslt.IndexCollection.Head);
        Assert.AreEqual(6, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod9()
    {
        var rslt = StringExtractor.Extract("abcabcdef", "abc", "b");
        Assert.AreEqual("a", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(3, rslt.IndexCollection.Head);
        Assert.AreEqual(4, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod10()
    {
        var rslt = StringExtractor.Extract("abcabcdef", "a", "a");
        Assert.AreEqual("bc", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(1, rslt.IndexCollection.Head);
        Assert.AreEqual(3, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod11()
    {
        var parameters = new StringExtractorParameters(
            "abcabcdef",
            new LeftString("a", direction: SearchDirection.Backward),
            new RightString("e"));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("bcd", rslt.Value);
        Assert.AreEqual(3, rslt.IndexCollection.Left);
        Assert.AreEqual(4, rslt.IndexCollection.Head);
        Assert.AreEqual(7, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod12()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdef",
            new LeftString("a"),
            new RightString("c", direction: SearchDirection.Backward));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("1ca2", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(1, rslt.IndexCollection.Head);
        Assert.AreEqual(5, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod13()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdef",
            new LeftString("a", direction: SearchDirection.Backward),
            new RightString("c", direction: SearchDirection.Backward));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("2", rslt.Value);
        Assert.AreEqual(3, rslt.IndexCollection.Left);
        Assert.AreEqual(4, rslt.IndexCollection.Head);
        Assert.AreEqual(5, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod14()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdef",
            new LeftString("a", skip: 1),
            new RightString("c"));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("2", rslt.Value);
        Assert.AreEqual(3, rslt.IndexCollection.Left);
        Assert.AreEqual(4, rslt.IndexCollection.Head);
        Assert.AreEqual(5, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod15()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdef",
            new LeftString("a"),
            new RightString("c", skip: 1));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("1ca2", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(1, rslt.IndexCollection.Head);
        Assert.AreEqual(5, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod16()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdef",
            new LeftString("a"),
            new RightString("c"),
            startIndex: 1);

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("2", rslt.Value);
        Assert.AreEqual(3, rslt.IndexCollection.Left);
        Assert.AreEqual(4, rslt.IndexCollection.Head);
        Assert.AreEqual(5, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod17()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdefa3ca4cdefa5ca6cdef",
            new LeftString("a", direction: SearchDirection.Backward),
            new RightString("c"),
            startIndex: 10);

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("3", rslt.Value);
        Assert.AreEqual(9, rslt.IndexCollection.Left);
        Assert.AreEqual(10, rslt.IndexCollection.Head);
        Assert.AreEqual(11, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod18()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdefa3ca4cdefa5ca6cdef",
            new LeftString("a"),
            new RightString("c"),
            searchOrder: SearchOrder.RightFirst,
            startIndex: 10);

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("3", rslt.Value);
        Assert.AreEqual(9, rslt.IndexCollection.Left);
        Assert.AreEqual(10, rslt.IndexCollection.Head);
        Assert.AreEqual(11, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod19()
    {
        var parameters = new StringExtractorParameters(
            "a1ca2cdefa3ca4cdefa5ca6cdef",
            new LeftString("a", direction: SearchDirection.Backward),
            new RightString("c"),
            searchOrder: SearchOrder.RightFirst,
            startIndex: 10);

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("3", rslt.Value);
        Assert.AreEqual(9, rslt.IndexCollection.Left);
        Assert.AreEqual(10, rslt.IndexCollection.Head);
        Assert.AreEqual(11, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod20()
    {
        var source = "AB_hoge_1_DD_fuga_23_JIMI_HENDRIX_1969_TYLER_DURDEN_1999";
        var rs = new RightString("_", skip: 2);
        var startIndex = 0;

        var parameters = new StringExtractorParameters(
            source,
            null,
            rs,
            startIndex: startIndex);

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("AB_hoge_1", rslt.Value);
        Assert.AreEqual(null, rslt.IndexCollection.Left);
        Assert.AreEqual(0, rslt.IndexCollection.Head);
        Assert.AreEqual(9, rslt.IndexCollection.Right);

        var ls = new LeftString("_");

        startIndex = rslt.IndexCollection.Right!.Value;
        parameters = new StringExtractorParameters(
            source,
            ls,
            rs,
            startIndex: startIndex);
        rslt = StringExtractor.Extract(parameters);

        Assert.AreEqual("DD_fuga_23", rslt.Value);
        Assert.AreEqual(9, rslt.IndexCollection.Left);
        Assert.AreEqual(10, rslt.IndexCollection.Head);
        Assert.AreEqual(20, rslt.IndexCollection.Right);

        startIndex = rslt.IndexCollection.Right!.Value;
        parameters = new StringExtractorParameters(
            source,
            ls,
            rs,
            startIndex: startIndex);
        rslt = StringExtractor.Extract(parameters);

        Assert.AreEqual("JIMI_HENDRIX_1969", rslt.Value);
        Assert.AreEqual(20, rslt.IndexCollection.Left);
        Assert.AreEqual(21, rslt.IndexCollection.Head);
        Assert.AreEqual(38, rslt.IndexCollection.Right);

        startIndex = rslt.IndexCollection.Right!.Value;
        parameters = new StringExtractorParameters(
            source,
            ls,
            null,
            startIndex: startIndex);
        rslt = StringExtractor.Extract(parameters);

        Assert.AreEqual("TYLER_DURDEN_1999", rslt.Value);
        Assert.AreEqual(38, rslt.IndexCollection.Left);
        Assert.AreEqual(39, rslt.IndexCollection.Head);
        Assert.AreEqual(null, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod21()
    {
        var parameters = new StringExtractorParameters(
            "a1cA2cdefa3ca4cdefa5ca6cdef",
            new LeftString(
                "A",
                stringComparison: StringComparison.OrdinalIgnoreCase),
            new RightString("c"));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("1", rslt.Value);
        Assert.AreEqual(0, rslt.IndexCollection.Left);
        Assert.AreEqual(1, rslt.IndexCollection.Head);
        Assert.AreEqual(2, rslt.IndexCollection.Right);
    }
    [TestMethod]
    public void TestMethod22()
    {
        var parameters = new StringExtractorParameters(
            "a1a2fa5ca6cdef",
            new LeftString(
                new RegexStringType(
                    @"\d"
                )
                {
                    Options = RegexStringTypeOptions.RightToLeft
                }),
            new RightString("e"));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("cd", rslt.Value);
        Assert.AreEqual(9, rslt.IndexCollection.Left);
        Assert.AreEqual(10, rslt.IndexCollection.Head);
        Assert.AreEqual(12, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod23()
    {
        var parameters = new StringExtractorParameters(
            "a1a2fa5ca6cdef",
            new LeftString(
                new RegexStringType(
                    @"\d"
                )),
            new RightString("f"));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("a2", rslt.Value);
        Assert.AreEqual(1, rslt.IndexCollection.Left);
        Assert.AreEqual(2, rslt.IndexCollection.Head);
        Assert.AreEqual(4, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod24()
    {
        var parameters = new StringExtractorParameters(
            "a1a2fa52ca6cd3ef",
            new LeftString(
                new RegexStringType(
                    @"\d+"
                )
                {
                    Skip = 2
                }),
            new RightString(
                new RegexStringType(
                    @"\d"
                )
                {
                    Skip = 1
                }
            ));

        var rslt = StringExtractor.Extract(parameters);
        Assert.AreEqual("ca6cd", rslt.Value);
        Assert.AreEqual(6, rslt.IndexCollection.Left);
        Assert.AreEqual(8, rslt.IndexCollection.Head);
        Assert.AreEqual(13, rslt.IndexCollection.Right);
    }

    [TestMethod]
    public void TestMethod25()
    {
        var parameters = new StringExtractorParameters(
            "testtesttest",
            new LeftString(
                "s",
                direction: SearchDirection.Forward
            ),
            new RightString(
                "e",
                direction: SearchDirection.Backward
            )
        );

        var rslt = StringExtractor.Extract(parameters);

        Assert.AreEqual("ttestt", rslt.Value);
        Assert.AreEqual(2, rslt.IndexCollection.Left);
        Assert.AreEqual(3, rslt.IndexCollection.Head);
        Assert.AreEqual(9, rslt.IndexCollection.Right);
    }
}