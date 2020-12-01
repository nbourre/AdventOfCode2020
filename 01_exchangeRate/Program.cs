using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _01_exchangeRate
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "01_input.txt";
            var fileContent = File.ReadAllLines(filename);

            var values = fileContent.Select(Int32.Parse).ToList();

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
    }
}
