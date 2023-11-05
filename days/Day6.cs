using System.Threading.Tasks.Dataflow;

namespace Days {
    static class Day6 {
        static string input = File.ReadAllText("inputs/input_6.txt");

        private static int findMarker(int markerLength) {
            string currentFour = input.Substring(0, markerLength);
            for (int i = markerLength-1; i<input.Length; i++) {
                var groups = currentFour.GroupBy(c => c);
                if (groups.Any(g => g.Count() > 1)) {
                    currentFour = input.Substring(i, markerLength);
                    continue;
                }
                return i + markerLength -1;                
            }
            return -1;
        }

        public static void Main() {
                Console.WriteLine($"Part one: {findMarker(4)}");
                Console.WriteLine($"Part two: {findMarker(14)}");   
        }
    }
}