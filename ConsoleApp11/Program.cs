using System;
using System.Text;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();

        public static void Main(string[] args) {
            countingValleys(8, "UDDDUDUU");
        }

        public static int countingValleys(int steps, string path) {
            int level = 0;
            int valleys = 0;
            for (int i = 0; i < steps; i++) {
                if (path[i] == 'U') {
                    level++;
                }
                else {
                    level--;
                }
                if (level == 0 && path[i] == 'U') {
                    valleys++;
                }
            }
            return valleys;
        }
    }
}