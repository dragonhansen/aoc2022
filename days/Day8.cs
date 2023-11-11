using System.ComponentModel.DataAnnotations;

namespace Days
{
    static class Day8
    {
        private static string[] lines = File.ReadAllLines("inputs/input_8.txt");


        public static void Solve()
        {
            computeVisibleTreeCount();
        }

        private static void computeVisibleTreeCount()
        {
            double count = Math.Pow(lines.Length, 2) - Math.Pow(lines.Length - 2, 2);
            int maxScenicScore = 0;
            for (int i = 1; i < lines.Length - 1; i++)
            {
                for (int j = 1; j < lines[i].Length - 1; j++)
                {
                    int[] scores = { 0, 0, 0, 0 };
                    bool visibleFromLeft = true;
                    bool visibleFromRight = true;
                    bool visibleFromTop = true;
                    bool visibleFromBot = true;
                    for (int k = j - 1; k >= 0; k--)
                    {
                        if (lines[i][k] >= lines[i][j])
                        {
                            visibleFromLeft = false;
                            scores[0]++;
                            break;
                        }
                        else
                        {
                            scores[0]++;
                        }
                    }
                    for (int k = j + 1; k < lines[i].Length; k++)
                    {
                        if (lines[i][k] >= lines[i][j])
                        {
                            visibleFromRight = false;
                            scores[1]++;
                            break;
                        }
                        else
                        {
                            scores[1]++;
                        }
                    }
                    for (int k = i - 1; k >= 0; k--)
                    {
                        if (lines[k][j] >= lines[i][j])
                        {
                            visibleFromTop = false;
                            scores[2]++;
                            break;
                        }
                        else
                        {
                            scores[2]++;
                        }
                    }
                    for (int k = i + 1; k < lines[i].Length; k++)
                    {
                        if (lines[k][j] >= lines[i][j])
                        {
                            visibleFromBot = false;
                            scores[3]++;
                            break;
                        }
                        else
                        {
                            scores[3]++;
                        }
                    }
                    if (visibleFromBot | visibleFromTop | visibleFromLeft | visibleFromRight)
                    {
                        count++;
                    }
                    int scenicScore = scores[0] * scores[1] * scores[2] * scores[3];
                    if (scenicScore > maxScenicScore)
                    {
                        maxScenicScore = scenicScore;
                    }

                }
            }
            Console.WriteLine("Day eight results:");
            Console.WriteLine($"Part one: {count}");
            Console.WriteLine($"Part two: {maxScenicScore}");
        }
    }
}