using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace ConsoleApp11 {
    class Program {
        public static string newTime, oldValue, newValue;

        public static string timeConversion(string s) {
            if (s.Contains("AM")) {
                newTime = s.Remove(8, 2);
                oldValue = s.Remove(2);
                if(int.Parse(oldValue) > 10) {
                    newValue = (int.Parse(oldValue) - 12).ToString();
                }
                else {
                    newValue = oldValue;
                }
                
                if(int.Parse(newValue) < 10 && newValue.Length == 1) {
                    newValue = "0" + newValue;
                }

                newTime = newTime.Replace($"{oldValue}", $"{newValue}");
            }
            else if (s.Contains("PM")) {
                newTime = s.Remove(8, 2);
                oldValue = s.Remove(2);
                if(oldValue != "12") {
                    newValue = (int.Parse(oldValue) + 12).ToString();
                }
                else {
                    newValue = oldValue;
                }
                
                newTime = newTime.Replace($"{oldValue}", $"{newValue}");
            }

            return newTime;
        }

        static void Main(string[] args) {
            Console.WriteLine(timeConversion("12:45:54PM"));
        }
    }
}