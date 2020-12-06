using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05_binary_boarding
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var fileContent = File.ReadAllLines(filename);

            PartA(fileContent);
        }

        private static void PartA(string[] fileContent)
        {
            List<int> seats = new List<int>();

            foreach (var line in fileContent)
            {
                int row = GetRowNumber(line);
                int column = GetColumnNumber(line);
                int seat = row * 8 + column;
                seats.Add(seat);

                Console.WriteLine($"{line} : row {row}, column {column}, seat {seat}.");
            }

            Console.WriteLine($"Max seat : {seats.Max()}");
        }

        private static int GetColumnNumber(string line)
        {
            int result = -1;
            int start = 0;
            int end = 7;

            for (int i = 7; i < 10; i++)
            {
                char direction = line[i];
                int range = (end - start) + 1;

                if (direction == 'L')
                {
                    end = end - range / 2;
                }
                else
                {
                    start = start + range / 2;
                }
            }

            result = start;

            return result;
        }

        private static int GetRowNumber(string line)
        {
            int result = -1;
            int start = 0;
            int end = 127;
            IEnumerable<int> values = Enumerable.Range(start, end);


            for (int i = 0; i < 7; i++)
            {
                char direction = line[i];
                int range = (end - start) + 1;

                if (direction == 'F')
                {
                    end = end - range / 2;
                } else
                {
                    start = start + range / 2;
                }
            }

            result = start;

            return result;
        }
    }
}
