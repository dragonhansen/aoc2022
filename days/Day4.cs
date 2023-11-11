namespace Days
{

    static class Day4
    {

        private static string[] lines = File.ReadAllLines("inputs/input_4.txt");

        private static int countOverlap(string line, bool partial)
        {
            string[] substrings = line.Split(',');
            string[] first = substrings[0].Split('-');
            string[] second = substrings[1].Split('-');
            int a = int.Parse(first[0]);
            int b = int.Parse(first[1]);
            int c = int.Parse(second[0]);
            int d = int.Parse(second[1]);
            if ((a <= c) && (b >= d)) return 1;
            if ((a >= c) && (b <= d)) return 1;
            if (!partial) return 0;
            if (b - c < 0) return 0;
            if (a - d > 0) return 0;
            return 1;
        }

        public static void Solve()
        {
            int full = 0;
            int partial = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                full += countOverlap(line, false);
                partial += countOverlap(line, true);

            }
            Console.WriteLine("Day 4 results:");
            Console.WriteLine("Part One: " + full);
            Console.WriteLine("Part Two: " + partial);
        }

    }

}