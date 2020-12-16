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

            PartA(fileContent);
        }

        private static void PartA(string[] fileContent)
        {
            
            int preamble = 25;

            int nbPossiblePairs = preamble * (preamble - 1) / 2;

            long[] values = new long[preamble];
            int count = 0;

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

            }


            Console.WriteLine($"The first wrong number is : {wrongValue}");

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
