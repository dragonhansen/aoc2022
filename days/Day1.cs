namespace Days
{
    static class Day1
    {
        static string[] lines = File.ReadAllLines("inputs/input_1.txt");

        static void day1()
        {
            int max = 0;
            int sum = 0;
            List<int> top3 = new List<int>() { 0, 0, 0 };
            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    if (sum > max)
                    {
                        max = sum;
                    }
                    if (sum > top3[0]) {
                        top3[0] = sum;
                        top3.Sort();
                    }
                    sum = 0;
                    continue;
                }
                sum += int.Parse(lines[i]);
            }
            Console.WriteLine("Day 1 results:");
            Console.WriteLine($"Part one: {max}");
            Console.WriteLine($"Part two: {top3.Sum()}");
        }

        public static void Main()
        {
            day1();
        }

    }
}