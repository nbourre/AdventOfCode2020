using System;
using System.Collections.Generic;
using System.IO;

namespace _encoding_error
{
    class MainClass
    {

        private static Dictionary<(long, long), long> keyValuePairs = new Dictionary<(long, long), long>();

        public static void Main(string[] args)
        {
            var filename = "input.txt";
            var fileContent = File.ReadAllLines(filename);

            var answerA = PartA(fileContent);
            PartB(fileContent, answerA);
        }

        private static void PartB(string[] fileContent, (int, long) answerA)
        {
            var delta = answerA.Item2;
            int endIndex = answerA.Item1 - 1;
            int currentIndex = endIndex;
            while (delta != 0)
            {
                if (delta < 0)
                {
                    delta = answerA.Item2;
                    endIndex--;
                    currentIndex = endIndex;
                }
                delta -= long.Parse(fileContent[currentIndex--]);

                
            }
            currentIndex++;
            Console.WriteLine($"L'index de départ est {currentIndex} et l'index de fin est {endIndex}");

            var v1 = long.Parse(fileContent[currentIndex]);
            var v2 = long.Parse(fileContent[endIndex]);
            Console.WriteLine($"Valeur de départ est {v1}, la valeur de fin est {v2} et la somme est de {v1 + v2}");
        }

        private static (int, long) PartA(string[] fileContent)
        {
            
            int preamble = 25;

            int nbPossiblePairs = preamble * (preamble - 1) / 2;

            long[] values = new long[preamble];
            int count = 0;
            int countWrongIndex = 0;

            long wrongValue = 0;
            bool filled = false;

            foreach (var line in fileContent)
            {
                var value = long.Parse(line);

                if (count >= values.Length)
                    filled = true;

                if (filled)
                {
                    UpdateKVPairs(values);
                    if (!isValidValue(values, value))
                    {
                        wrongValue = value;
                        
                        break;
                    }
                    

                    count = count % values.Length;
                }
                    

                values[count] = value;
                
                count++;
                countWrongIndex++;

            }


            Console.WriteLine($"The first wrong number is : {wrongValue} at line {countWrongIndex}");

            return (countWrongIndex, wrongValue);

        }

        private static void UpdateKVPairs(long[] values)
        {
            keyValuePairs = new Dictionary<(long, long), long>();
            foreach (var v1 in values)
            {

                foreach (var v2 in values)
                {
                    if (v1 == v2) continue;
                    if (!(keyValuePairs.ContainsKey((v1, v2)) || keyValuePairs.ContainsKey((v2, v1))))
                    {
                        keyValuePairs.Add((v1, v2), v1 + v2);
                    }

                }

            }
        }

        private static bool isValidValue(long[] values, long value)
        {
            bool result = keyValuePairs.ContainsValue(value);

            return result;
        }

        
    }
}
