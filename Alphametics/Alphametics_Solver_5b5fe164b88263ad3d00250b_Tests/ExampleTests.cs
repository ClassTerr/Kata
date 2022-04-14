using Alphametics_Solver_5b5fe164b88263ad3d00250b;
using NUnit.Framework;
using System.Linq;

namespace Alphametics_Solver_5b5fe164b88263ad3d00250b_Tests;

[TestFixture]
public class ExampleTests
{
    [Test, Description("5 Example Tests"), TestCaseSource(nameof(_examples))]
    public static void ExampleTest(string s)
    {
        var z = s.Split(" -> ").Select(e => e.Substring(1, e.Length - 2)).ToArray();
        Assert.That(Cryptarithm.Alphametics(z[0]), Is.EqualTo(z[1]));
    }

    private static string[] _examples =
    {
        "\"BILL + JIM = DUDES\" -> \"9422 + 743 = 10165\"",
        "\"ZEROES + ONES = BINARY\" -> \"698392 + 3192 = 701584\"",
        "\"SEND + MORE = MONEY\" -> \"9567 + 1085 = 10652\"",
        "\"COUPLE + COUPLE = QUARTET\" -> \"653924 + 653924 = 1307848\"",
        "\"DO + YOU + FEEL = LUCKY\" -> \"57 + 870 + 9441 = 10368\"",
        "\"ELEVEN + NINE + FIVE + FIVE = THIRTY\" -> \"797275 + 5057 + 4027 + 4027 = 810386\"",
        "\"NINETEEN + THIRTEEN + THREE + TWO + TWO + ONE + ONE + ONE = FORTYTWO\" -> \"42415114 + 56275114 + 56711 + 538 + 538 + 841 + 841 + 841 = 98750538\""
    };
}
