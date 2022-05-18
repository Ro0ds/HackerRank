using System.Collections.Generic;
using System;
using System.Text;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();
        public static void Main(string[] args) {
            findMedian(new List<int> { 0, 1, 2, 4, 5, 6, 3 });

            Console.WriteLine(sb);
        }

        public static int findMedian(List<int> arr) {
            arr.Sort();
            int median = arr.Count / 2;
            int result = 0;
            List<int> res = new List<int>();

            res.Add(arr[median]);

            foreach (var item in res) {
                result = item;
            }

            sb.Append(result.ToString());

            return result;
        }
    }
}