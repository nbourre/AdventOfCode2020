using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01_exchangeRate
{
    /// <summary>
    /// --- Day 1: Report Repair ---
    /// After saving Christmas five years in a row, you've decided to take a vacation at a nice resort on a tropical island. Surely, Christmas will go on without you.
    /// 
    /// The tropical island has its own currency and is entirely cash-only. The gold coins used there have a little picture of a starfish; the locals just call them stars. None of the currency exchanges seem to have heard of them, but somehow, you'll need to find fifty of these coins by the time you arrive so you can pay the deposit on your room.
    /// 
    /// To save your vacation, you need to get all fifty stars by December 25th.
    /// 
    /// Collect stars by solving puzzles. Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first. Each puzzle grants one star. Good luck!
    /// 
    /// Before you leave, the Elves in accounting just need you to fix your expense report (your puzzle input); apparently, something isn't quite adding up.
    /// 
    /// Specifically, they need you to find the two entries that sum to 2020 and then multiply those two numbers together.
    /// 
    /// For example, suppose your expense report contained the following:
    /// 
    /// 1721
    /// 979
    /// 366
    /// 299
    /// 675
    /// 1456
    /// In this list, the two entries that sum to 2020 are 1721 and 299. Multiplying them together produces 1721 * 299 = 514579, so the correct answer is 514579.
    /// 
    /// Of course, your expense report is much larger. Find the two entries that sum to 2020; what do you get if you multiply them together?
    /// 
    /// Your puzzle answer was 388075.
    /// 
    /// --- Part Two ---
    /// The Elves in accounting are thankful for your help; one of them even offers you a starfish coin they had left over from a past vacation. They offer you a second one if you can find three numbers in your expense report that meet the same criteria.
    /// 
    /// Using the above example again, the three entries that sum to 2020 are 979, 366, and 675. Multiplying them together produces the answer, 241861950.
    /// 
    /// In your expense report, what is the product of the three entries that sum to 2020?
    /// 
    /// Your puzzle answer was 293450526.
    /// 
    /// Both parts of this puzzle are complete! They provide two gold stars: **
    /// 
    /// At this point, you should return to your Advent calendar and try another puzzle.
    /// 
    /// If you still want to see it, you can get your puzzle input.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Answer : 215 * 1805 = 388075
        /// </summary>
        /// <param name="content"></param>
        static void PartA(string[] content)
        {
            var values = content.Select(Int32.Parse).ToList();

            int goal = 2020;

            int opA = 0;
            int opB = 0;


            foreach (var val in values)
            {
                var delta = goal - val;
                opA = val;

                foreach (var checkWith in values)
                {
                    if (checkWith == delta)
                    {
                        opB = checkWith;
                        break;
                    }
                }

                if (opB == delta)
                {
                    break;
                }
                else
                    opB = 0;
            }

            Console.WriteLine($"Operand A : {opA}");
            Console.WriteLine($"Operand B : {opB}");
            Console.WriteLine($"Result of opA * opB = {opA * opB}");
        }

        /// <summary> 
        /// Answer : 558 * 823 * 639 = 293450526
        /// </summary>
        /// <param name="content"></param>
        static void PartB(string[] content)
        {
            var values = content.Select(Int32.Parse).ToList();

            int goal = 2020;

            // Les opérandes
            int opA = 0;
            int opB = 0;
            int opC = 0;

            for (int i = 0; i < values.Count; i++)
            {
                var v1 = values[i];

                opA = v1;

                var delta1 = goal - opA;

                opB = 0;
                for (int j = i + 1; j < values.Count; j++)
                {
                    var v2 = values[j];

                    /// Si la valeur est plus grande
                    /// que le delta, ça ne sert à rien
                    /// de continuer avec cette valeur
                    /// on va toujours dépasser l'objectif sinon
                    if (v2 >= delta1) continue;

                    opB = v2;

                    var delta2 = goal - opA - opB;

                    opC = 0;
                    for (int k = j + 1; k < values.Count; k++)
                    {
                        var v3 = values[k];

                        if (v3 == delta2)
                        {
                            /// On vient de trouver un triplet qui est bon
                            opC = v3;
                            break;
                        }
                    }

                    if (opC > 0)
                        break;
                }

                if (opC > 0)
                    break;
            }

            Console.WriteLine($"Operand A : {opA}");
            Console.WriteLine($"Operand B : {opB}");
            Console.WriteLine($"Operand C : {opC}");
            Console.WriteLine($"Sum: {opA + opB + opC}");
            Console.WriteLine($"Mult: {opA * opB * opC}");
        }

        static void Main(string[] args)
        {
            var filename = "01_input.txt";
            var fileContent = File.ReadAllLines(filename);

            PartA(fileContent);
            PartB(fileContent);            
        }
    }
}
