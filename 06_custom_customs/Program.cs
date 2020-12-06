using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _06_custom_customs
{
    /// <summary>
    /// /// --- Day 6: Custom Customs ---
    /// As your flight approaches the regional airport where you'll switch to a much larger plane, customs declaration forms are distributed to the passengers.
    /// 
    /// The form asks a series of 26 yes-or-no questions marked a through z. All you need to do is identify the questions for which anyone in your group answers "yes". Since your group is just you, this doesn't take very long.
    /// 
    /// However, the person sitting next to you seems to be experiencing a language barrier and asks if you can help. For each of the people in their group, you write down the questions for which they answer "yes", one per line. For example:
    /// 
    /// abcx
    /// abcy
    /// abcz
    /// In this group, there are 6 questions to which anyone answered "yes": a, b, c, x, y, and z. (Duplicate answers to the same question don't count extra; each question counts at most once.)
    /// 
    /// Another group asks for your help, then another, and eventually you've collected answers from every group on the plane (your puzzle input). Each group's answers are separated by a blank line, and within each group, each person's answers are on a single line. For example:
    /// 
    /// abc
    /// 
    /// a
    /// b
    /// c
    /// 
    /// ab
    /// ac
    /// 
    /// a
    /// a
    /// a
    /// a
    /// 
    /// b
    /// This list represents answers from five groups:
    /// 
    /// The first group contains one person who answered "yes" to 3 questions: a, b, and c.
    /// The second group contains three people; combined, they answered "yes" to 3 questions: a, b, and c.
    /// The third group contains two people; combined, they answered "yes" to 3 questions: a, b, and c.
    /// The fourth group contains four people; combined, they answered "yes" to only 1 question, a.
    /// The last group contains one person who answered "yes" to only 1 question, b.
    /// In this example, the sum of these counts is 3 + 3 + 3 + 1 + 1 = 11.
    /// 
    /// For each group, count the number of questions to which anyone answered "yes". What is the sum of those counts?
    /// 
    /// Your puzzle answer was 6612.
    /// 
    /// The first half of this puzzle is complete! It provides one gold star: *
    /// 
    /// --- Part Two ---
    /// As you finish the last group's customs declaration, you notice that you misread one word in the instructions:
    /// 
    /// You don't need to identify the questions to which anyone answered "yes"; you need to identify the questions to which everyone answered "yes"!
    /// 
    /// Using the same example as above:
    /// 
    /// abc
    /// 
    /// a
    /// b
    /// c
    /// 
    /// ab
    /// ac
    /// 
    /// a
    /// a
    /// a
    /// a
    /// 
    /// b
    /// This list represents answers from five groups:
    /// 
    /// In the first group, everyone (all 1 person) answered "yes" to 3 questions: a, b, and c.
    /// In the second group, there is no question to which everyone answered "yes".
    /// In the third group, everyone answered yes to only 1 question, a. Since some people did not answer "yes" to b or c, they don't count.
    /// In the fourth group, everyone answered yes to only 1 question, a.
    /// In the fifth group, everyone (all 1 person) answered "yes" to 1 question, b.
    /// In this example, the sum of these counts is 3 + 0 + 1 + 1 + 1 = 6.
    /// 
    /// For each group, count the number of questions to which everyone answered "yes". What is the sum of those counts?
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "input.txt";
            var fileContent = File.ReadAllLines(filename);

            List<List<string>> groups = CreateGroups(fileContent);

            int resultA = PartA(groups);

            Console.WriteLine($"Part A result is {resultA}");

            int resultB = PartB(groups);
            Console.WriteLine($"Part B result is {resultB}");
        }

        private static int PartB(List<List<string>> groups)
        {
            int result = 0;

            foreach (var group in groups)
            {
                int nbPeople = group.Count();

                if (nbPeople == 1)
                    result += group[0].Length;
                else
                {
                    byte[] bins = new byte[26];

                    foreach (var person in group)
                    {
                        var bytes = Encoding.ASCII.GetBytes(person);
                        
                        foreach (var value in bytes) {
                            int index = (int)value - 97;
                            bins[index]++;
                        }
                    }

                    result += bins.Where(x => x == nbPeople).Count();
                }


            }

            return result;
        }

        private static List<List<string>> CreateGroups(string[] fileContent)
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

            return groups;
        }

        #region PartA
        private static int PartA(List<List<string>> groups)
        {
            int result = 0;

            /// Individual
            /// 
            foreach (var gang in groups)
            {
                result += GetGroupResultA(gang);
            }

            return result;
            
        }

        private static int GetGroupResultA(List<string> gang)
        {
            int result = 0;

            result = gang.Aggregate((i, j) => i + j).Distinct().Count();

            return result;
        }
        #endregion
    }
}
