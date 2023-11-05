using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;

namespace Days
{
    static class Day3
    {
        private static string[] lines = File.ReadAllLines("inputs/input_3.txt");

        private static void partOne()
        {
            int sum = 0;
            foreach (string line in lines)
            {
                int compartmentLength = line.Length / 2;
                string leftCompartment = line.Substring(0, compartmentLength);
                string rightCompartment = line.Substring(compartmentLength);
                foreach (char item in leftCompartment)
                {
                    if (rightCompartment.Contains(item))
                    {
                        sum += itemToInt(item);
                        break;
                    }
                }
            }
            Console.WriteLine($"Part one: {sum}");
        }

        private static int itemToInt(char item)
        {
            for (char c = 'a'; c <= 'z'; c++)
            {
                if (item.Equals(c)) { return c - 96; }
            }
            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (item.Equals(c)) { return c - 38; }
            }
            return -1;
        }

        private static void partTwo()
        {
            int sum = 0;
            for (int i = 0; i < lines.Length; i += 3)
            {
                char badge = '1';
                string commonFirstTwo = string.Empty;
                foreach (char item in lines[i])
                {
                    if (lines[i + 1].Contains(item))
                    {
                        commonFirstTwo += item;
                    }
                }
                foreach (char item in commonFirstTwo)
                {
                    if (lines[i + 2].Contains(item))
                    {
                        badge = item;
                    }
                }
                sum += itemToInt(badge);
                if (badge.Equals('1')) {Console.WriteLine("ERROR!");}
            }
            Console.WriteLine($"Part two: {sum}");
        }

        public static void Main()
        {
            Console.WriteLine("Day 3 results:");
            partOne();
            partTwo();
        }

    }
}