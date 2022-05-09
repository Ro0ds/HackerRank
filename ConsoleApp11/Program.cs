using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();
        public static Tuple<Int64, Int64> tuple;

        public static void miniMaxSum(List<int> arr) {
            Int64 resMax = 0;
            Int64 resMin = 0;
            arr.Sort();

            for (int i = 1; i <= 4; i++) {
                resMax += arr[i];
            }

            for (int i = 0; i < 4; i++) {
                resMin += arr[i];
            }
            tuple = new Tuple<long, long>(resMin, resMax);
        }

        static void Main(string[] args) {
            miniMaxSum(new List<int> {5,2,3,1,4});
            sb.AppendLine(tuple.Item1 + " " + tuple.Item2);
            Console.WriteLine(sb);
        }
    }
}