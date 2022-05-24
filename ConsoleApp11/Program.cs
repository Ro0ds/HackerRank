using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();

        public static void Main(string[] args) {
            countingSort(new List<int> { 1, 1, 3, 2, 1 });
        }

        public static List<int> countingSort(List<int> arr) {
            int[] range = new int[100];

            foreach (int item in arr) {
                range[item]++;
            }

            return range.ToList();
        }

    }
}