using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace ConsoleApp11 {
    class Program {
        public static int maxScore, minScore, maxCount, minCount;
        public static StringBuilder sb = new StringBuilder();
        public static List<int> result;
        public static Tuple<int, int> tuple;

        public static List<int> breakingRecords(List<int> scores) {
            maxScore = scores[0];
            minScore = scores[0];
            result = new List<int>(2);

            for (int i = 1; i < scores.Count; i++) {
                if(scores[i] > maxScore) {
                    maxScore = scores[i];
                    maxCount++;
                }
                else if(scores[i] < minScore) {
                    minScore = scores[i];
                    minCount++;
                }
            }

            result.Add(maxCount);
            result.Add(minCount);

            tuple = new Tuple<int, int>(result[0], result[1]);

            return result;
        }

        static void Main(string[] args) {
            Console.WriteLine(breakingRecords(new List<int> { 12, 24, 10, 24 }));

            sb.Append(Program.tuple.Item1 + " " + Program.tuple.Item2);

            Console.WriteLine(sb);
        }
    }
}