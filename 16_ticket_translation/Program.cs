using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _ticket_translation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var filename = "test.txt";
            var fileContent = File.ReadAllLines(filename);

            PartA(fileContent);
        }

        private static void PartA(string[] fileContent)
        {
            int blockCounter = 0;
            int lineCounter = 0;
            
            var rules = new Dictionary<string, List<int>>();

            foreach (var line in fileContent)
            {
                

                if (line == string.Empty)
                    blockCounter++;

                if (blockCounter == 0)
                {
                    // rules
                    var rule = line.Split(':');
                    var parts = rule[1].Split(new string[] { " or " }, StringSplitOptions.None);
                    var partA1 = int.Parse(parts[0].Split('-')[0].Trim());
                    var partA2 = int.Parse(parts[0].Split('-')[1].Trim());
                    var partB1 = int.Parse(parts[1].Split('-')[0].Trim());
                    var partB2 = int.Parse(parts[1].Split('-')[1].Trim());

                    //rules.Add(rule[0], Enumerable.Range())

                } else if (blockCounter == 1)
                {   // my ticket


                } else
                {   // all tickets do outside
                    break;
                }

                lineCounter++;

            }
        }
    }
}
