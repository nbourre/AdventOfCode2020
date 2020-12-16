using System;
using System.Collections.Generic;
using System.IO;

namespace _encoding_error
{
    class MainClass
    {

        Dictionary<(int, int), int> keyValuePairs = new Dictionary<(int, int), int>();

        public static void Main(string[] args)
        {
            var filename = "test.txt";
            var fileContent = File.ReadAllLines(filename);

            PartA(fileContent);
        }

        private static void PartA(string[] fileContent)
        {
            
            int preamble = 5;

            int nbPairs = preamble * (preamble - 1) / 2;

            int[] values = new int[preamble];
            int count = 0;

            int answerIndex = 0;
            bool filled = false;

            foreach (var line in fileContent)
            {
                var value = int.Parse(line);

                if (count >= values.Length)
                    filled = true;

                if (filled)
                {
                    UpdateKVPairs(values);
                    if (!isValidValue(values, value))
                    {
                        answerIndex = count;
                        break;
                    }
                    

                    count = count % values.Length;
                }
                    

                values[count] = value;
                
                count++;

            }

            var answer = fileContent[answerIndex];

            Console.WriteLine($"The first wrong number is : {answer}");

        }

        private static void UpdateKVPairs(int[] values)
        {
            var nbPairs = values.Length!;
        }

        private static bool isValidValue(int[] values, int value)
        {
            bool result = false;

            return result;
        }

        
    }
}
