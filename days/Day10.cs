using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;

namespace Days
{
    static class Day10
    {
        private static string[] lines = File.ReadAllLines("inputs/input_10.txt");

        public static void Main()
        {
            calculateSignalStrengthSum();
        }

        private static void calculateSignalStrengthSum()
        {
            int x = 1;
            int cycle = 1;
            int sum = 0;
            foreach (string line in lines)
            {
                string[] function = line.Split(' ');
                if (function[0].Equals("noop"))
                {
                    sum += addToSumIfInterestingSignal(cycle, x);
                    cycle++;
                    continue;
                }
                if (function[0].Equals("addx"))
                {
                    sum += addToSumIfInterestingSignal(cycle, x);
                    cycle++;
                    sum += addToSumIfInterestingSignal(cycle, x);
                    cycle++;
                    x += int.Parse(function[1]);
                    continue;
                }
            }
            Console.WriteLine($"Part one: {sum}");
        }

        private static int addToSumIfInterestingSignal(int cycle, int x)
        {
            if (Math.Abs(cycle % 40 - 1 - x) < 2)
            {
                Console.Write("#");
            }
            else
            {
                Console.Write(".");
            }
            if (cycle % 40 == 0)
            {
                Console.WriteLine();
            }
            if (cycle % 40 == 20)
            {
                return cycle * x;
            }
            return 0;
        }
    }
}