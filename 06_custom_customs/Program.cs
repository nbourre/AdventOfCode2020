using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _06_custom_customs
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var fileContent = File.ReadAllLines(filename);

            DoIt(fileContent);
        }

        private static void DoIt(string[] fileContent)
        {
            List<List<string>> groups = new List<List<string>>();

            List<string> group = new List<string>();
            int lineCount = 0;

            /// Grouping
            foreach (var line in fileContent)
            {
                if (line != "")
                {
                    group.Add(line);
                }

                if (line == string.Empty || lineCount == fileContent.Length - 1)
                {
                    groups.Add(group);

                    group = new List<string>();
                }

                lineCount++;
            }


            int result = 0;

            /// Individual
            /// 
            foreach (var gang in groups)
            {
                result += GetGroupResult(gang);
            }

            Console.WriteLine($"The result is {result}");
            
        }

        private static int GetGroupResult(List<string> gang)
        {
            int result = 0;

            result = gang.Aggregate((i, j) => i + j).Distinct().Count();

            return result;
        }
    }
}
