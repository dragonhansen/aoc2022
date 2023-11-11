using System.Collections;
using System.Diagnostics.Metrics;

namespace Days
{
    static class Day9
    {
        private static string[] lines = File.ReadAllLines("inputs/input_9.txt");

        private static (int, int) headPosition = (0,0);
        private static (int, int) tailPosition = (0,0);
        private static List<(int, int)> tailPositionList = new List<(int, int)>(){(0,0)};

        private static void findSumOfTailPositions() {
            foreach(string line in lines) {
                string[] instruction = line.Split(' ');
                string direction = instruction[0];
                int steps = int.Parse(instruction[1]);
                for(int i = 0; i < steps; i++) {
                    moveHead(direction);
                }
            }
            int sumOfTailPositions = tailPositionList.Count();
            Console.WriteLine($"Part one: {sumOfTailPositions}");
        }


        private static void moveHead(string direction) {
            switch(direction) {
                case "U": 
                    headPosition.Item1 += 1;
                    break;
                case "D": 
                    headPosition.Item1 -= 1;
                    break;
                case "L": 
                    headPosition.Item2 -= 1;
                    break;
                case "R": 
                    headPosition.Item2 += 1;
                    break;
            }
            int verticalDifference = headPosition.Item1 - tailPosition.Item1;
            int horizontalDifference = headPosition.Item2 - tailPosition.Item2;
            if((Math.Abs(verticalDifference) == 2 & Math.Abs(horizontalDifference) == 1)|(Math.Abs(verticalDifference) == 1 & Math.Abs(horizontalDifference) == 2)) {
                if(direction.Equals("U") | direction.Equals("D")) {
                    tailPosition.Item2 = headPosition.Item2;
                } else {
                    tailPosition.Item1 = headPosition.Item1;
                }
            }
            if(Math.Abs(verticalDifference) > 1) {
                tailPosition.Item1 +=  Math.Sign(verticalDifference);
            }
            if(Math.Abs(horizontalDifference) > 1) {
                tailPosition.Item2 +=  Math.Sign(horizontalDifference);
            }
            logTailPosition();
        }

        private static void logTailPosition() {
            if(!tailPositionList.Contains(tailPosition)) {
                tailPositionList.Add(tailPosition);
            }
        }

        public static void Main() {
            findSumOfTailPositions();
        }

    }
}