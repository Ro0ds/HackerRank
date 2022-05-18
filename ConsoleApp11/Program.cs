using System.Collections.Generic;
using System;
using System.Text;

namespace ConsoleApp11 {
    class Program {
        public static List<int> result = new List<int>();
        public static StringBuilder sb = new StringBuilder();
        public static int count;
        public static void Main(string[] args) {

        }

        public static List<int> matchingStrings(List<string> strings, List<string> queries) {
            for (int i = 0; i < queries.Count; i++) {
                for (int j = 0; j < strings.Count; j++) {
                    if (queries[i].Equals(strings[j])) {
                        count++;
                    }
                }
                result.Add(count);
                count = 0;
            }
            return result;
        }
    }
}