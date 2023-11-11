using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
namespace Days
{
    static class Day7
    {
        private static string[] lines = File.ReadAllLines("inputs/input_7.txt");

        private static void day7()
        {
            Stack<string> directories = new Stack<string>();
            Dictionary<string, int> directorySizes = new Dictionary<string, int>();
            string currentPath = "";
            foreach (string line in lines)
            {
                string[] args = line.Split(' ');
                if (args[0].Equals("dir") | args[1].Equals("ls"))
                {
                    continue;
                }
                if (args[0].Equals("$"))
                {
                    if (args[1].Equals("cd") & args[2].Equals(".."))
                    {
                        directories.Pop();
                        currentPath = directories.First();
                    }
                    else if (args[1].Equals("cd"))
                    {
                        currentPath += args[2] + "/";
                        directories.Push(currentPath);
                    }
                }
                else
                {
                    int fileSize = int.Parse(args[0]);
                    //Push arg0 to size list for the current stack element
                    foreach (string dir in directories)
                    {
                        if (!directorySizes.ContainsKey(dir))
                        {
                            directorySizes.Add(dir, fileSize);
                        }
                        else
                        {

                            directorySizes[dir] += fileSize;
                        }
                    }



                }

            }
            int sum = 0;
            directorySizes.TryGetValue("//", out int rootSize);
            int availableSpace = 70000000 - rootSize;
            int min = 70000000;
            foreach (var dir in directorySizes)
            {
                if (dir.Value <= 100000)
                {
                    sum += dir.Value;
                    Console.WriteLine(dir.Key);
                }
                if (availableSpace + dir.Value >= 30000000 & dir.Value < min)
                {
                    min = dir.Value;
                }
            }
            Console.WriteLine($"Part one: {sum}");
            Console.WriteLine($"Part two: {min}");

        }

        public static void Solve()
        {

            Console.WriteLine("Day 7 results:");
            day7();


        }


    }
}