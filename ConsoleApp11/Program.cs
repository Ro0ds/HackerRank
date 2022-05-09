using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace ConsoleApp11 {
    class Program {
        public List<int> arr = new List<int>(); // { 1, 1, 0, -1, -1 }
        public static Tuple<double, double, double> tuple;
        public static StringBuilder sb = new StringBuilder();

        static void Main(string[] args) {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            plusMinus(arr);

            sb.AppendLine(tuple.Item1.ToString("F6"));
            sb.AppendLine(tuple.Item2.ToString("F6"));
            sb.AppendLine(tuple.Item3.ToString("F6"));

            Console.WriteLine(sb);
        }

        public static void plusMinus(List<int> arr) {
            int div = arr.Count;
            List<double> pos, neg, zer;


            pos = new List<double>();
            neg = new List<double>();
            zer = new List<double>();

            foreach (double elem in arr) {
                Convert.ToDouble(elem);

                if (elem > 0) {
                    pos.Add(elem);
                }
                else if (elem < 0) {
                    neg.Add(elem);
                }
                else if (elem == 0) {
                    zer.Add(elem);
                }
            }

            tuple = new Tuple<double, double, double>
                ((Convert.ToDouble(pos.Count) / div),
                (Convert.ToDouble(neg.Count) / div),
                (Convert.ToDouble(zer.Count) / div));
        }
    }

}