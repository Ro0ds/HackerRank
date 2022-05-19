using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();
        public static void Main(string[] args) {
            gradingStudents(new List<int> { 4,73,67,38,33 });

            Console.WriteLine(sb);
        }

        public static List<int> gradingStudents(List<int> grades) {
            List<int> res = new List<int>();
            int oldGrade = 0;
            int multGrade = 0;
            int roundedGrade = 0;

            for (int i = 1; i < grades.Count; i++) {
                if(grades[i] < 35) {
                    res.Add(grades[i]);
                }
                
                if(grades[i] > 35) {
                    oldGrade = grades[i];
                    multGrade = oldGrade;

                    while(multGrade % 5 != 0) {
                        multGrade++;
                    }

                    if(multGrade - oldGrade < 3) {
                        roundedGrade = multGrade;
                    }
                    else {
                        roundedGrade = oldGrade;
                    }

                    res.Add(roundedGrade);
                }
            }

            int[] final = new int[res.Count];

            for(int i = 0; i < res.Count; i++) {
                //foreach(int a in res) {
                    final[i] = res[i];
                //}
            }

            foreach (var item in final) {
                sb.AppendLine($"{item}");
            }

            return final.ToList();
        }
    }
}