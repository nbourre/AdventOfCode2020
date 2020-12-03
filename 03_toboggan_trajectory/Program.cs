using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03_toboggan_trajectory
{
    /// <summary>
    /// --- Day 3: Toboggan Trajectory ---
    /// With the toboggan login problems resolved, you set off toward the airport. While travel by toboggan might be easy, it's certainly not safe: there's very minimal steering and the area is covered in trees. You'll need to see which angles will take you near the fewest trees.
    /// 
    /// Due to the local geology, trees in this area only grow on exact integer coordinates in a grid. You make a map (your puzzle input) of the open squares (.) and trees (#) you can see. For example:
    /// 
    /// ..##.......
    /// #...#...#..
    /// .#....#..#.
    /// ..#.#...#.#
    /// .#...##..#.
    /// ..#.##.....
    /// .#.#.#....#
    /// .#........#
    /// #.##...#...
    /// #...##....#
    /// .#..#...#.#
    /// These aren't the only trees, though; due to something you read about once involving arboreal genetics and biome stability, the same pattern repeats to the right many times:
    /// 
    /// ..##.........##.........##.........##.........##.........##.......  --->
    /// #...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
    /// .#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
    /// ..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
    /// .#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
    /// ..#.##.......#.##.......#.##.......#.##.......#.##.......#.##.....  --->
    /// .#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
    /// .#........#.#........#.#........#.#........#.#........#.#........#
    /// #.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...
    /// #...##....##...##....##...##....##...##....##...##....##...##....#
    /// .#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
    /// You start on the open square (.) in the top-left corner and need to reach the bottom (below the bottom-most row on your map).
    /// 
    /// The toboggan can only follow a few specific slopes (you opted for a cheaper model that prefers rational numbers); start by counting all the trees you would encounter for the slope right 3, down 1:
    /// 
    /// From your starting position at the top-left, check the position that is right 3 and down 1. Then, check the position that is right 3 and down 1 from there, and so on until you go past the bottom of the map.
    /// 
    /// The locations you'd check in the above example are marked here with O where there was an open square and X where there was a tree:
    /// 
    /// ..##.........##.........##.........##.........##.........##.......  --->
    /// #..O#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..
    /// .#....X..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#.
    /// ..#.#...#O#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#
    /// .#...##..#..X...##..#..#...##..#..#...##..#..#...##..#..#...##..#.
    /// ..#.##.......#.X#.......#.##.......#.##.......#.##.......#.##.....  --->
    /// .#.#.#....#.#.#.#.O..#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#
    /// .#........#.#........X.#........#.#........#.#........#.#........#
    /// #.##...#...#.##...#...#.X#...#...#.##...#...#.##...#...#.##...#...
    /// #...##....##...##....##...#X....##...##....##...##....##...##....#
    /// .#..#...#.#.#..#...#.#.#..#...X.#.#..#...#.#.#..#...#.#.#..#...#.#  --->
    /// In this example, traversing the map using this slope would cause you to encounter 7 trees.
    /// 
    /// Starting at the top-left corner of your map and following a slope of right 3 and down 1, how many trees would you encounter?
    /// 
    /// Your puzzle answer was 252.
    /// 
    /// The first half of this puzzle is complete! It provides one gold star: *
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var fileContent = File.ReadAllLines(filename);

            PartA(fileContent);
            PartB(fileContent);
        }

        private static void PartB(string[] fileContent)
        {
            List<(int, int)> inputs = new List<(int, int)>();
            List<int> results = new List<int>();

            inputs.Add((1, 1));
            inputs.Add((3, 1));
            inputs.Add((5, 1));
            inputs.Add((7, 1));
            inputs.Add((1, 2));

            foreach (var input in inputs)
            {
                results.Add(Traverse(fileContent, input.Item1, input.Item2));
            }

            Console.WriteLine($"Number of trees : {String.Join(", ", results)}");

            long mult = 1;

            foreach (var r in results)
            {
                mult *= r;
            }

            Console.WriteLine($"Multiplication : {mult}");
        }

        private static void PartA(string[] fileContent)
        {
            int result = Traverse(fileContent, 3, 1);
            Console.WriteLine($"Number of trees : {result}");
        }


        private static int Traverse(string[] fileContent, int dX, int dY)
        {
            int width = fileContent[0].Length;
            int height = fileContent.Length;

            var currentHeight = 0;
            var currentX = 0;

            int nbTrees = 0;

            while (currentHeight < height)
            {

                var currentChar = fileContent[currentHeight][currentX];

                if (currentChar == '#') nbTrees++;

                currentX = (currentX + dX) % width;
                currentHeight += dY;
            }

            return nbTrees;
        }
    }
}
