
namespace Days
{
    static class Day2
    {
        static string[] lines = File.ReadAllLines("inputs/input_2.txt");
        static Dictionary<string, int> partOneMap = new Dictionary<string, int>{{"AX", 4}, {"AY", 8}, {"AZ", 3}, {"BX", 1}, {"BY", 5}, {"BZ", 9},  {"CX", 7}, {"CY", 2}, {"CZ", 6}};
        static Dictionary<string, int> partTwoMap = new Dictionary<string, int>{{"AX", 3}, {"AY", 4}, {"AZ", 8}, {"BX", 1}, {"BY", 5}, {"BZ", 9},  {"CX", 2}, {"CY", 6}, {"CZ", 7}};

        static void day2() {
            int partOneSum = 0;
            int partTwoSum = 0;
            foreach (string line in lines) {
                string key = line.Replace(" ", string.Empty);
                partOneMap.TryGetValue(key, out int parteOneVal);
                partTwoMap.TryGetValue(key, out int parteTwoVal);
                partOneSum += parteOneVal;
                partTwoSum += parteTwoVal;

            }
            Console.WriteLine($"Part one: {partOneSum}");
            Console.WriteLine($"Part two: {partTwoSum}");
        }

        public static void Main() {
            Console.WriteLine("Day 2 results:");
            day2();
        }
    }
}