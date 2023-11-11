namespace Days
{
    static class Day5
    {
        private static string[] lines = File.ReadAllLines("inputs/input_5.txt");

        private static int emptyLineIndex = Array.FindIndex(lines, string.IsNullOrEmpty);
        private static string[] stackLines = lines.Take(emptyLineIndex - 1).ToArray();
        private static string[] controlLines = lines.Skip(emptyLineIndex + 1).ToArray();
        private static List<Stack<char>> stacks = new List<Stack<char>>();

        private static void readToStack(List<Stack<char>> stacks)
        {
            for (int i = 0; i < 9; i++)
            {
                stacks.Add(new Stack<char>());
            }

            for (int i = 0; i < 9; i++)
            {
                // Loop over the lines in reverse to get the correct order
                foreach (string line in stackLines.Reverse())
                {
                    char stackElement = line[i * 4 + 1];
                    if (!stackElement.Equals(' '))
                    {
                        stacks[i].Push(stackElement);
                    }
                }
            }
        }

        private static void partOne()
        {
            readToStack(stacks);
            foreach (string line in controlLines)
            {
                string[] substrings = line.Split(' ');
                int numberToMove = int.Parse(substrings[1]);
                int source = int.Parse(substrings[3]) - 1;
                int destination = int.Parse(substrings[5]) - 1;
                for (int i = 0; i < numberToMove; i++)
                {
                    char element = stacks[source].Pop();
                    stacks[destination].Push(element);
                }
            }
            Console.Write("Part one: ");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(stacks[i].First());
            }
            Console.WriteLine();
        }

        private static void partTwo()
        {
            readToStack(stacks);
            foreach (string line in controlLines)
            {
                string[] substrings = line.Split(' ');
                int numberToMove = int.Parse(substrings[1]);
                int source = int.Parse(substrings[3]) - 1;
                int destination = int.Parse(substrings[5]) - 1;
                Stack<char> tempStack = new Stack<char>();
                for (int i = 0; i < numberToMove; i++)
                {
                    char element = stacks[source].Pop();
                    tempStack.Push(element);
                }
                tempStack.Reverse();
                foreach (char element in tempStack)
                {
                    stacks[destination].Push(element);
                }
            }
            Console.Write("Part Two: ");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(stacks[i].First());
            }
            Console.WriteLine();
        }

        public static void Solve()
        {
            Console.WriteLine("Day 5 results:");
            partOne();
            partTwo();
        }



    }
}
