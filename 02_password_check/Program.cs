using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02_password_check
{
    /// <summary>
    /// Your flight departs in a few days from the coastal airport; the easiest way down to the coast from here is via toboggan.
    /// 
    /// The shopkeeper at the North Pole Toboggan Rental Shop is having a bad day. "Something's wrong with our computers; we can't log in!" You ask if you can take a look.
    /// 
    /// Their password database seems to be a little corrupted: some of the passwords wouldn't have been allowed by the Official Toboggan Corporate Policy that was in effect when they were chosen.
    /// 
    /// 
    /// To try to debug the problem, they have created a list (your puzzle input) of passwords(according to the corrupted database) and the corporate policy when that password was set.
    /// 
    /// For example, suppose you have the following list:
    /// 
    /// 1-3 a: abcde
    /// 1-3 b: cdefg
    /// 2-9 c: ccccccccc
    /// Each line gives the password policy and then the password.The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid.For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.
    /// 
    /// In the above example, 2 passwords are valid.The middle password, cdefg, is not; it contains no instances of b, but needs at least 1. The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.
    /// 
    /// How many passwords are valid according to their policies?
    /// 
    /// 
    /// Your puzzle answer was 580.
    /// 
    /// --- Part Two ---
    /// While it appears you validated the passwords correctly, they don't seem to be what the Official Toboggan Corporate Authentication System is expecting.
    /// 
    /// 
    /// The shopkeeper suddenly realizes that he just accidentally explained the password policy rules from his old job at the sled rental place down the street! The Official Toboggan Corporate Policy actually works a little differently.
    /// 
    /// 
    /// Each policy actually describes two positions in the password, where 1 means the first character, 2 means the second character, and so on. (Be careful; Toboggan Corporate Policies have no concept of "index zero"!) Exactly one of these positions must contain the given letter.Other occurrences of the letter are irrelevant for the purposes of policy enforcement.
    /// 
    /// Given the same example list from above:
    /// 
    /// 1-3 a: abcde is valid: position 1 contains a and position 3 does not.
    /// 1-3 b: cdefg is invalid: neither position 1 nor position 3 contains b.
    /// 2-9 c: ccccccccc is invalid: both position 2 and position 9 contain c.
    /// How many passwords are valid according to the new interpretation of the policies?
    /// 
    /// Your puzzle answer was 611.
    /// 
    /// Both parts of this puzzle are complete! They provide two gold stars: **
    /// 
    /// At this point, you should return to your Advent calendar and try another puzzle.
    /// 
    /// If you still want to see it, you can get your puzzle input.
    /// 
    /// You can also[Share] this puzzle.
    /// </summary>
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
