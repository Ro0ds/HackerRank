using System.Collections.Generic;
using System;
using System.Text;
using System.Linq;

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();

        public static void Main(string[] args) {
            int q = Convert.ToInt32(Console.ReadLine().Trim());
            long result;

            for (int qItr = 0; qItr <= q; qItr++) {
                long n = Convert.ToInt64(Console.ReadLine().Trim());

                result = flippingBits(n);

                Console.WriteLine(result);
            }
        }

        public static long flippingBits(long n) { // 32bits
            long BruteNumber = 0;
            string ConvertedToBits = string.Empty;
            string invertedBits = string.Empty;
            string finalDecimal = string.Empty;
            string restoDiv = string.Empty;
            long getNumber = 0;
            int baseBits = 32;
            int count = 0;

            BruteNumber = n;
            getNumber = BruteNumber;

            ConvertedToBits = Convert.ToString(BruteNumber, 2);

            do {
                restoDiv += getNumber % 2;
                getNumber /= 2;
            } while (getNumber > 0);

            count = baseBits - restoDiv.Length;

            for (int i = 0; i < count; i++) {
                ConvertedToBits = "0" + ConvertedToBits;
            }

            for (int i = 0; i < ConvertedToBits.Length; i++) {
                if (ConvertedToBits.Substring(i, 1) == "0") {
                    invertedBits += ConvertedToBits.Substring(i, 1).Replace("0", "1");
                }
                else {
                    invertedBits += ConvertedToBits.Substring(i, 1).Replace("1", "0");
                }
            }

            finalDecimal = Convert.ToInt64(invertedBits, 2).ToString();

            return Math.Abs(long.Parse(finalDecimal));
        }
    }
}