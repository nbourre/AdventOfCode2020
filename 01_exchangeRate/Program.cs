using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01_exchangeRate
{
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
