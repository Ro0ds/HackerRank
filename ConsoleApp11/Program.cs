using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();
        public static int firstDiagSum = 0;
        public static int secondDiagSum = 0;
        public static int difference = 0;

        public static void Main(string[] args) {
            Console.Write("Linhas: ");
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> arr = new List<List<int>>();

            for (int i = 0; i < n; i++) {
                Console.WriteLine($"\nNúmero de itens: {n}");
                Console.Write($"Item #{i}: ");
                arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
            }

            int result = diagonalDifference(arr);
            Console.WriteLine(sb);
        }

        public static int diagonalDifference(List<List<int>> arr) {
            for (int i = 0; i < arr.Count; i++) {
                for (int j = 0; j < arr.Count; j++) {
                    if (arr.IndexOf(arr[i]) == arr.IndexOf(arr[j])) {
                        firstDiagSum += arr[i][j];
                    }
                }
            }

            arr.Reverse();

            for (int i = 0; i < arr.Count; i++) {
                for (int j = 0; j < arr.Count; j++) {
                    if (arr.IndexOf(arr[i]) == arr.IndexOf(arr[j])) {
                        secondDiagSum += arr[i][j];
                    }
                }
            }

            difference = firstDiagSum - secondDiagSum;
            sb.AppendLine($"\ndifference: {difference}");

            return difference;
        }
    }
}