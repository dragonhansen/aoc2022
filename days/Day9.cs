using System.Collections;
using System.Diagnostics.Metrics;

namespace Days
{
    static class Day9
    {
        private static string[] lines = File.ReadAllLines("inputs/input_9.txt");
        private static List<(int, int)> tailPositionList = new List<(int, int)>(){(0,0)};
        private static int tailLength = 10;
        private static (int, int)[] tail = new (int,int)[tailLength];
        private static void findSumOfTailPositions() {
            foreach(string line in lines) {
                string[] instruction = line.Split(' ');
                string direction = instruction[0];
                int steps = int.Parse(instruction[1]);
                for(int i = 0; i < steps; i++) {
                    moveHead(direction, tailLength);
                    logTailPosition();
                }
            }
            int sumOfTailPositions = tailPositionList.Count();
            Console.WriteLine($"Part one: {sumOfTailPositions}");
        }


        private static void moveHead(string direction, int tailLength) {
            switch(direction) {
                case "U": 
                    tail[0].Item1 += 1;
                    break;
                case "D": 
                    tail[0].Item1 -= 1;
                    break;
                case "L": 
                    tail[0].Item2 -= 1;
                    break;
                case "R": 
                    tail[0].Item2 += 1;
                    break;
            }
            for(int i = 1; i<tailLength; i++) {

                int verticalDifference = tail[i-1].Item1-tail[i].Item1; 
                int horizontalDifference = tail[i-1].Item2-tail[i].Item2; 
                if((Math.Abs(verticalDifference) == 2 & Math.Abs(horizontalDifference) == 1)|(Math.Abs(verticalDifference) == 1 & Math.Abs(horizontalDifference) == 2)) {
                    if(direction.Equals("U") | direction.Equals("D")) {
                        tail[i].Item2 = tail[i-1].Item2;
                    } else {
                        tail[i].Item1 = tail[i-1].Item1;
                    }
                }
                if(Math.Abs(verticalDifference) > 1) {
                    tail[i].Item1 +=  Math.Sign(verticalDifference);
                }
                if(Math.Abs(horizontalDifference) > 1) {
                    tail[i].Item2 +=  Math.Sign(horizontalDifference);
                }
            }
        }

        private static void logTailPosition() {
            if(!tailPositionList.Contains(tail.Last())) {
                tailPositionList.Add(tail.Last());
            }
        }

        public static void Solve() {
            findSumOfTailPositions();
        }

    }
}