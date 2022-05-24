using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyscrapers6By6_5679d5a3f2272011d700000d;

public static class Skyscrapers
{
    private class Clue
    {
        public int StartClue { get; init; }

        public int EndClue { get; init; }

        public (int X, int Y)[] CellLocations { get; init; } = Array.Empty<(int, int)>();
    }

    private const int SideSize = 6;
    private const int SkyscraperMaxHeight = 6;

    private static int[][] _field;

    private static Dictionary<(int StartClue, int EndClue), HashSet<int[]>> _cluesCache;
    private static Clue[] _clues;

    public static int[][] SolvePuzzle(int[] clues)
    {
        InitCache();
        InitClues(clues);
        InitField();

        return CluesLookup()!;
    }

    private static void InitField()
    {
        _field = Enumerable.Range(1, SideSize).Select(_ => Enumerable.Repeat(0, SideSize).ToArray()).ToArray();
    }

    private static void InitClues(int[] clues)
    {
        var verticalClues = Enumerable.Range(0, SideSize)
            .Select(x => new Clue
            {
                StartClue = clues[x],
                EndClue = clues[SideSize * 3 - x - 1],
                CellLocations = Enumerable.Range(0, SideSize).Select(y => (x, y)).ToArray()
            }).ToArray();

        var horizontalClues = Enumerable.Range(0, SideSize)
            .Select(y => new Clue
            {
                StartClue = clues[SideSize * 4 - y - 1],
                EndClue = clues[y + SideSize],
                CellLocations = Enumerable.Range(0, SideSize).Select(x => (x, y)).ToArray()
            }).ToArray();

        _clues = verticalClues.Concat(horizontalClues).OrderBy(x => _cluesCache[(x.StartClue, x.EndClue)].Count).ToArray();
    }

    private static void InitCache()
    {
        _cluesCache = new(720 * 4);
        var permutations = GetPermutations(Enumerable.Range(1, SideSize).ToList(), SideSize);

        void AddToCache((int StartClue, int EndClue) key, int[] permutation)
        {
            if (!_cluesCache.ContainsKey(key))
            {
                _cluesCache.Add(key, new());
            }

            _cluesCache[key].Add(permutation);
        }

        foreach (var permutation in permutations.Select(x => x.ToArray()))
        {
            var forwardHint = CalculateClue(permutation);
            var backwardHint = CalculateClue(permutation.AsEnumerable().Reverse());
            AddToCache((0, 0), permutation);
            AddToCache((forwardHint, 0), permutation);
            AddToCache((0, backwardHint), permutation);
            AddToCache((forwardHint, backwardHint), permutation);
        }
    }

    private static int[][] CluesLookup(int index = 0)
    {
        if (index >= SideSize + SideSize)
        {
            return _field;
        }

        var currentClue = _clues[index];

        var availableHeights = currentClue.CellLocations.Select(loc => GetPossibleCellHeights(loc.X, loc.Y)).ToArray();
        var possibleVariants = GetPossibleRowsOrColumns(currentClue.StartClue, currentClue.EndClue, availableHeights).ToArray();

        var oldValues = currentClue.CellLocations.Select(loc => _field[loc.Y][loc.X]).ToArray();

        foreach (var possibleVariant in possibleVariants)
        {
            for (var i = 0; i < currentClue.CellLocations.Length; i++)
            {
                _field[currentClue.CellLocations[i].Y][currentClue.CellLocations[i].X] = possibleVariant[i];
            }

            var res = CluesLookup(index + 1);
            if (res != null)
            {
                return res;
            }
        }

        for (var i = 0; i < currentClue.CellLocations.Length; i++)
        {
            _field[currentClue.CellLocations[i].Y][currentClue.CellLocations[i].X] = oldValues[i];
        }

        return null;
    }

    private static IEnumerable<int[]> GetPossibleRowsOrColumns(int startClue, int endClue, bool[][] availableHeights)
    {
        var hasNotPossibleCell = availableHeights.Any(x => x.All(y => !y));
        return hasNotPossibleCell
            ? Array.Empty<int[]>()
            : _cluesCache[(startClue, endClue)].Where(x => x.Zip(availableHeights).All(tuple => tuple.Second[tuple.First - 1]));
    }

    private static bool[] GetPossibleCellHeights(int x, int y)
    {
        var arr = Enumerable.Repeat(true, SkyscraperMaxHeight).ToArray();

        if (_field[y][x] != 0)
        {
            arr = new bool[SkyscraperMaxHeight];
            arr[_field[y][x] - 1] = true;
            return arr;
        }

        for (var i = 0; i < SideSize; i++)
        {
            if (_field[i][x] != 0)
            {
                arr[_field[i][x] - 1] = false;
            }
        }

        for (var i = 0; i < SideSize; i++)
        {
            if (_field[y][i] != 0)
            {
                arr[_field[y][i] - 1] = false;
            }
        }

        return arr;
    }

    private static int CalculateClue(IEnumerable<int> heights)
    {
        var visibleCount = 0;
        var maxH = 0;

        foreach (var h in heights)
        {
            if (h <= maxH) continue;
            visibleCount++;
            maxH = h;
        }

        return visibleCount;
    }

    private static IEnumerable<IEnumerable<T>> GetPermutations<T>(ICollection<T> list, int length)
    {
        if (length == 1) return list.Select(t => new[] { t });
        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(o => !t.Contains(o)),
                (t1, t2) => t1.Concat(new[] { t2 }));
    }
}
