using KReverseSingleLinkedList_5cf92c3092613c00130b987e;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace KReverseSingleLinkedList_5cf92c3092613c00130b987e_Tests;

[TestFixture]
public class KataTest
{
    [Test]
    public static void SampleTest001()
    {
        var arr = new[] { 1, 2, 3, 4 };
        var cr = new[] { 2, 1, 4, 3 };
        var l = ToLinkedList(arr);
        var res = FromLinkedList(Kata.KReverse(l, 2));

        Assert.IsTrue(cr.SequenceEqual(res));
    }

    [Test]
    public static void SampleTest002()
    {
        var arr = new[] { 1, 2, 3, 4, 5, 6 };
        var cr = new[] { 3, 2, 1, 6, 5, 4 };
        var l = ToLinkedList(arr);
        var res = FromLinkedList(Kata.KReverse(l, 3));

        Assert.IsTrue(cr.SequenceEqual(res));
    }

    [Test]
    public static void SampleTest003()
    {
        var arr = new[] { 1, 2, 3, 4, 5, 6 };
        var cr = new[] { 6, 5, 4, 3, 2, 1 };
        var l = ToLinkedList(arr);
        var res = FromLinkedList(Kata.KReverse(l, 6));

        Assert.IsTrue(cr.SequenceEqual(res));
    }

    [Test]
    public static void SampleTest004()
    {
        var arr = new[] { 1, 2, 3, 4, 5, 6 };
        var cr = new[] { 4, 3, 2, 1, 6, 5};
        var l = ToLinkedList(arr);
        var res = FromLinkedList(Kata.KReverse(l, 4));

        Assert.IsTrue(cr.SequenceEqual(res));
    }

    private static KReverseSingleLinkedList_5cf92c3092613c00130b987e.LinkedListNode<T> ToLinkedList<T>(T[] arr)
    {
        var start = default(KReverseSingleLinkedList_5cf92c3092613c00130b987e.LinkedListNode<T>);
        var node = default(KReverseSingleLinkedList_5cf92c3092613c00130b987e.LinkedListNode<T>);

        foreach (var elem in arr)
        {
            if (node == null)
            {
                node = new(elem);
                start = node;
            }
            else
            {
                var next = new KReverseSingleLinkedList_5cf92c3092613c00130b987e.LinkedListNode<T>(elem);
                node.Next = next;
                node = node.Next;
            }
        }

        return start;
    }

    private static T[] FromLinkedList<T>(KReverseSingleLinkedList_5cf92c3092613c00130b987e.LinkedListNode<T> start)
    {
        var res = new List<T>();
        var n = start;

        while (n != null)
        {
            res.Add(n.Value);
            n = n.Next;
        }

        return res.ToArray();
    }

}
