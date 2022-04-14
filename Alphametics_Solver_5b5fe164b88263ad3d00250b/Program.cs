using System;
using System.Collections.Generic;
using System.Linq;

namespace Alphametics_Solver_5b5fe164b88263ad3d00250b
{
    public class Cryptarithm
    {
        private static Alphabet _alphabet;
        private static List<string> _equationLeft;
        private static string _equationRight;
        private static HashSet<char> _firstLetters;

        public static string Alphametics(string s)
        {
            var equationParts = s.Split('=', '+').Select(x => x.Trim()).ToList();

            _firstLetters = equationParts.Select(x => x[0]).ToHashSet();

            _alphabet = new Alphabet();
            _equationRight = equationParts.Last();
            equationParts.RemoveAt(equationParts.Count - 1);
            _equationLeft = equationParts;

            return SearchSolution();
        }

        private static string SearchSolution(int definedTailLetters = 0, int reminder = 0)
        {
            if (definedTailLetters == _equationRight.Length)
            {
                return CheckEquation()
                    ? string.Join(" + ", _equationLeft.Select(ConvertToInteger)) + " = " + ConvertToInteger(_equationRight)
                    : null;
            }

            var currentLetter = _equationRight[_equationRight.Length - 1 - definedTailLetters];
            var currentLetterAssignedDigit = _alphabet.GetAssignedDigit(currentLetter);

            var availableDigitOptionsForCurrentLetter = currentLetterAssignedDigit.HasValue
                ? new[] { currentLetterAssignedDigit.Value }
                : _alphabet.GetUnassignedDigits();

            foreach (var currentDigit in availableDigitOptionsForCurrentLetter)
            {
                if (currentDigit == 0 && _firstLetters.Contains(currentLetter))
                {
                    continue;
                }

                if (!currentLetterAssignedDigit.HasValue)
                {
                    _alphabet.AssignLetterValue(currentLetter, currentDigit);
                }

                var currentLevelLetters = _equationLeft
                    .Where(x => x.Length > definedTailLetters)
                    .Select(x => x[x.Length - 1 - definedTailLetters])
                    .ToArray();

                var lettersToAssign = currentLevelLetters.Distinct().Where(x => _alphabet.GetAssignedDigit(x) == null).ToList();

                var permutations = GetPermutations(_alphabet.GetUnassignedDigits(), lettersToAssign.Count);

                foreach (var permutation in permutations)
                {
                    var currentPermutationAssignedLetters = lettersToAssign.Zip(permutation).ToList();

                    if (currentPermutationAssignedLetters.Any(x => x.Second == 0 && _firstLetters.Contains(x.First)))
                    {
                        // This case not considered because it causes leading zeroes in the solution.
                        continue;
                    }

                    foreach (var (letter, digit) in currentPermutationAssignedLetters)
                    {
                        _alphabet.AssignLetterValue(letter, digit);
                    }

                    var levelSum = currentLevelLetters.Aggregate(0, (acc, x) => acc + _alphabet.GetAssignedDigit(x)!.Value) + reminder;
                    var letterValue = levelSum % 10;

                    if (letterValue == currentDigit)
                    {
                        var newLevelReminder = levelSum / 10;
                        var result = SearchSolution(definedTailLetters + 1, newLevelReminder);
                        if (result != null) return result;
                    }

                    foreach (var (letter, _) in currentPermutationAssignedLetters)
                    {
                        _alphabet.UnAssignLetterValue(letter);
                    }
                }

                if (!currentLetterAssignedDigit.HasValue)
                {
                    _alphabet.UnAssignLetterValue(currentLetter);
                }
            }

            return null;
        }

        private static IEnumerable<IEnumerable<T>> GetPermutations<T>(ICollection<T> list, int length)
        {
            if (length == 0) return new[] { Array.Empty<T>() };

            return length == 1
                ? list.Select(t => new[] { t })
                : GetPermutations(list, length - 1).SelectMany(t => list.Where(o => !t.Contains(o)), (t1, t2) => t1.Concat(new[] { t2 }));
        }

        private static bool CheckEquation()
        {
            var leftPart = _equationLeft.Aggregate(0, (acc, component) => ConvertToInteger(component) + acc);
            var rightPart = ConvertToInteger(_equationRight);
            return leftPart == rightPart;
        }

        private static int ConvertToInteger(IEnumerable<char> number)
        {
            return int.Parse(number.Select(x => (char)(_alphabet.GetAssignedDigit(x)!.Value + '0')).ToArray().AsSpan());
        }
    }

    internal class Alphabet
    {
        private readonly int?[] _letterAssignment = Enumerable.Repeat((int?)null, 26).ToArray();
        private readonly char?[] _digitAssignment = Enumerable.Repeat((char?)null, 10).ToArray();

        public void AssignLetterValue(char letter, int digit)
        {
            _letterAssignment[letter - 'A'] = digit;
            _digitAssignment[digit] = letter;
        }

        public void UnAssignLetterValue(char letter)
        {
            var digit = _letterAssignment[letter - 'A'];
            _letterAssignment[letter - 'A'] = null;
            _digitAssignment[digit!.Value] = null;
        }

        public int? GetAssignedDigit(char letter)
        {
            return _letterAssignment[letter - 'A'];
        }

        public int[] GetUnassignedDigits()
        {
            return _digitAssignment.Select((x, i) => new { x, i }).Where(x => x.x == null).Select(x => x.i).ToArray();
        }
    }
}
