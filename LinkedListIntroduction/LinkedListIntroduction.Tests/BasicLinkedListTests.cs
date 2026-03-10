using LinkedListIntroduction.Lib;

namespace LinkedListIntroduction.Tests;

[TestClass]
public sealed class BasicLinkedListTests
{
    [TestMethod]
    public void TestEmpty()
    {
        IntegerLinkedList ill = new IntegerLinkedList();
        Assert.AreEqual(0, ill.Count);
    }

    [TestMethod]
    public void TestCount()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(3, ill.Count);
    }

    [TestMethod]
    public void TestSum()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual(21, ill.Sum);
    }

    [TestMethod]
    public void TestToStringExplicit()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.AreEqual("{5, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestPrepend()
    {
        var ill = new IntegerLinkedList(7);
        ill.Prepend(5);
        Assert.AreEqual("{5, 7}", ill.ToString());
    }

    [TestMethod]
    public void TestDelete()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.IsTrue(ill.Delete(7));
        Assert.AreEqual("{5, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestInsert()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        ill.Insert(8, 1);
        Assert.AreEqual("{5, 8, 7, 9}", ill.ToString());
    }

    [TestMethod]
    public void TestJoin()
    {
        var a = new IntegerLinkedList(5);
        a.Append(7);

        var b = new IntegerLinkedList(9);
        b.Append(11);

        a.Join(b);
        Assert.AreEqual("{5, 7, 9, 11}", a.ToString());
    }

    [TestMethod]
    public void TestContains()
    {
        var ill = new IntegerLinkedList(5);
        ill.Append(7);
        ill.Append(9);
        Assert.IsTrue(ill.Contains(7));
        Assert.IsFalse(ill.Contains(10));
    }

}