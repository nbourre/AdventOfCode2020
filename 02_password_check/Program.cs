using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_password_check
{
    class Program
    {
        static void Main(string[] args)
        {
            var filename = "02_input.txt";
            var fileContent = File.ReadAllLines(filename);

            PartA(fileContent);
            PartB(fileContent);
        }

        private static void PartA(string[] fileContent)
        {
            int count = 0;
            foreach(var line in fileContent)
            {
                count += IsValidPasswordA(line) ? 1 : 0;
            }


            Console.WriteLine($"A. Nombre de mot de passe valide : {count}");
        }

        private static void PartB(string[] fileContent)
        {
            int count = 0;
            foreach (var line in fileContent)
            {
                count += IsValidPasswordB(line) ? 1 : 0;
            }


            Console.WriteLine($"B. Nombre de mot de passe valide : {count}");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="line">Format : 0-1 l: pw. 0 <= min occurence, 1 <= max occurence, pw <= password</param>
        /// <returns></returns>
        private static bool IsValidPasswordA (string line)
        {
            bool result = false;
            var splitted = line.Split(":");

            string rule = splitted[0];
            string password = splitted[1].Trim();

            Regex ruleCheck = new Regex(@"(\d{1,2})-(\d{1,2}) (\w)") ;

            var match = ruleCheck.Match(rule);

            var min = int.Parse(match.Groups[1].Value);
            var max = int.Parse(match.Groups[2].Value);
            var letter = match.Groups[3].Value.ToCharArray()[0];

            int count = password.Count(c => c == letter);

            result = count >= min && count <= max;

            return result;
        }

        private static bool IsValidPasswordB(string line)
        {
            bool result = false;
            var splitted = line.Split(":");

            string rule = splitted[0];
            string password = splitted[1]; // No trim must keep space

            Regex ruleCheck = new Regex(@"(\d{1,2})-(\d{1,2}) (\w)");

            var match = ruleCheck.Match(rule);

            var posA = int.Parse(match.Groups[1].Value);
            var posB = int.Parse(match.Groups[2].Value);
            var letter = match.Groups[3].Value.ToCharArray()[0];

            // Ou exclusif (XOR)
            result = password[posA] == letter ^ password[posB] == letter;


            return result;
        }
    }
}
