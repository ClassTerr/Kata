using System.Linq;

// ReSharper disable once CheckNamespace
namespace Solution
{
    public class BattleshipField
    {
        private static int[,] _field;
        private static bool[,] _visitedCells;

        public static bool ValidateBattlefield(int[,] field)
        {
            _visitedCells = new bool[10, 10];
            _field = field;

            var shipsCount = new int[4];

            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    var shipLength = VisitCell(i, j);

                    if (shipLength == -1 || shipLength >= 5)
                    {
                        return false;
                    }

                    if (shipLength != 0)
                    {
                        shipsCount[shipLength - 1]++;
                    }
                }
            }

            return !shipsCount.Where((x, i) => x != 4 - i).Any();
        }

        private static readonly (int x, int y)[] Diagonal =
        {
            (1, 1),
            (1, -1),
            (-1, 1),
            (-1, -1)
        };

        private static int VisitCell(int i, int j)
        {
            if (!IsInBounds(i, j) || _field[i, j] == 0 || _visitedCells[i, j])
            {
                return 0;
            }

            _visitedCells[i, j] = true;

            // Diagonal touchings are not allowed.
            if (Diagonal.Select(coordinates => (x: coordinates.x + i, y: coordinates.y + j))
                .Where(coordinates => IsInBounds(coordinates.x, coordinates.y))
                .Any(coordinates => _field[coordinates.x, coordinates.y] == 1))
            {
                return -1;
            }

            return VisitCell(i - 1, j) + VisitCell(i, j - 1) + VisitCell(i + 1, j) + VisitCell(i, j + 1) + 1;
        }

        private static bool IsInBounds(int i, int j) => i >= 0 && j >= 0 && i < 10 && j < 10;
    }
}
