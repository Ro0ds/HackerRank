using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();
        public static void Main(string[] args) {
            lonelyinteger(new List<int> { 1,2,3,4,3,2,1 });
            Console.WriteLine(sb);
        }

        public static int lonelyinteger(List<int> a) {
            var result = a.GroupBy(x => x).Where(g => g.Count() < 2).Select(y => y.Key).ToList();
            int final = 0;

            foreach(var item in result) {
                final = item;
            }

            sb.Append(final);
            return final;
        }
    }
}