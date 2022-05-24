using LinqOperator_59e4b634f703c4c95c000097;
using NUnit.Framework;
using System;
using System.Linq;

namespace LinqOperator_59e4b634f703c4c95c000097_Tests
{
    [TestFixture]
    public class SelectConsecutiveTests
    {
        [Test]
        public void EmptyTest()
        {
            var singleItem = Enumerable.Repeat(1, 1);

            var selectConsecutive = singleItem.SelectConsecutive(Tuple.Create);
            CollectionAssert.IsEmpty(selectConsecutive);
        }

        [Test]
        public void WorksWithSimpleData()
        {
            Tuple<int, int>[] expected = { Tuple.Create(0, 1), Tuple.Create(1, 2), Tuple.Create(2, 3) };
            var actual = Enumerable.Range(0, 4)
                .SelectConsecutive(Tuple.Create);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
