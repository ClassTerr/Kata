using NavigatingAMaze_56d08f810f9408079200102f;
using NUnit.Framework;

namespace NavigatingAMaze_56d08f810f9408079200102f_Tests;

[TestFixture]
public class MazePathfindingTest
{
    [Test]
    public void StaticMaze1()
    {
        int[] path = { 36, 37, 38, 31, 24, 25, 26 };
        var field = new[]
        {
            false, false, false, false, false, false, false, false, true, false, true, true, true, false, false, true, false, true, false,
            false, false, false, true, true, true, true, true, false, false, false, false, true, false, true, false, false, true, true,
            true, false, true, false, false, false, false, false, false, false, false
        };

        CollectionAssert.AreEqual(path, Kata.FindPath(field, 7, 36, 26));
    }

    [Test]
    public void StaticMaze2()
    {
        int[] path = { 78, 89, 100, 101, 102, 103, 104, 105, 106, 107, 108 };
        var field = new[]
        {
            false, false, false, false, false, false, false, false, false, false, false, false, true, false, true, false, true, false, true,
            false, true, false, false, true, false, true, false, true, false, true, false, true, false, false, true, true, true, false,
            true, false, true, true, true, false, false, false, false, true, false, true, false, true, false, true, false, false, true,
            true, true, false, true, true, true, false, true, false, false, false, false, true, false, true, false, false, false, false,
            false, false, true, false, true, true, true, false, true, false, true, false, false, true, false, false, false, true, false,
            true, false, true, false, false, true, true, true, true, true, true, true, true, true, false, false, false, false, false, false,
            false, false, false, false, false, false
        };

        CollectionAssert.AreEqual(path, Kata.FindPath(field, 11, 78, 108));
    }

    [Test]
    public void StaticMaze3()
    {
        int[] path =
        {
            46, 61, 76, 91, 106, 121, 136, 151, 166, 167, 168, 183, 198, 199, 200, 201, 202, 203, 204, 205, 206, 191, 176, 161, 146, 147,
            148, 133, 118, 103, 88, 73, 58, 43, 28
        };

        var field = new[]
        {
            false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true,
            true, true, true, true, true, false, true, false, true, true, true, false, false, true, false, false, false, true, false, false,
            false, true, false, true, false, true, false, false, true, true, true, false, true, false, true, false, true, false, true,
            false, true, false, false, true, false, false, false, false, false, true, false, true, false, false, false, true, false, false,
            true, false, true, true, true, true, true, true, true, false, true, true, true, false, false, true, false, false, false, true,
            false, false, false, false, false, false, false, true, false, false, true, false, true, false, true, true, true, false, true,
            false, true, false, true, false, false, true, false, true, false, true, false, false, false, true, false, true, false, true,
            false, false, true, false, true, true, true, false, true, false, true, true, true, true, true, false, false, true, false, false,
            false, true, false, true, false, false, false, true, false, true, false, false, true, true, true, false, true, true, true, true,
            true, false, true, false, true, false, false, true, false, true, false, false, false, true, false, false, false, true, false,
            false, false, false, true, false, true, true, true, true, true, true, true, true, true, true, true, false, false, false, false,
            false, false, false, false, false, false, false, false, false, false, false, false
        };

        CollectionAssert.AreEqual(path, Kata.FindPath(field, 15, 46, 28));
    }
}
