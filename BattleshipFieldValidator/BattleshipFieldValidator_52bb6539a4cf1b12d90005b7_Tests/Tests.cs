using NUnit.Framework;
using Solution;

namespace BattleshipFieldValidator_52bb6539a4cf1b12d90005b7_Tests
{
    [TestFixture]
    public class Tests
    {
        [TestFixture]
        public class SolutionTest
        {
            [Test]
            public void OkCase()
            {
                var field = new[,]
                {
                    { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                    { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
                    { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                Assert.IsTrue(BattleshipField.ValidateBattlefield(field));
            }

            [Test]
            public void DiagonalCase()
            {
                var field = new[,]
                {
                    { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 1, 0, 0, 0, 1, 1, 1, 0, 1, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 1, 0, 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
            }

            [Test]
            public void OneMoreShipsCase()
            {
                var field = new[,]
                {
                    { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 1, 0, 0, 0, 1, 1, 1, 0, 1, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 1, 0, 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
            }

            [Test]
            public void OneLessShipsCase()
            {
                var field = new[,]
                {
                    { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 1, 0, 0, 0, 1, 1, 1, 0, 1, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
            }

            [Test]
            public void TooLongShipCase()
            {
                var field = new[,]
                {
                    { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 1, 0, 0, 0, 1, 1, 1, 0, 1, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
            }

            [Test]
            public void CurvedShipCase()
            {
                var field = new[,]
                {
                    { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                    { 1, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 1, 1, 0, 0, 1, 1, 1, 0, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 1, 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
                };

                Assert.IsFalse(BattleshipField.ValidateBattlefield(field));
            }
        }
    }
}
