using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System;

/*
 * S - Split
 * C - Combine
 * ------------------
 * M - Method
 * C - Class
 * V - Variable
 */

namespace ConsoleApp11 {
    class Program {
        public static StringBuilder sb = new StringBuilder();
        public static List<string> palavra = new List<string>();

        public static void Main(string[] args) {
            string linha;

            while ((linha = Console.ReadLine()) != null && linha != "") {
                palavra.Add(linha);
            }

            foreach (string item in palavra) {
                Dividir(item.TrimEnd());
            }

            Console.WriteLine(sb.ToString());
        }

        private static string Dividir(string entrada) {
            string SeparaCategoria = entrada.Remove(4);
            string PalavraBruta = string.Empty;
            string Operacao = SeparaCategoria.Remove(1);
            string Operando = SeparaCategoria.Remove(3).Last().ToString();
            string RecolocaUpper;
            string SemEspacos;

            // Split case (M, C, V)
            if (Operacao == "S") {
                switch (Operando) {
                    case "M":
                    case "C":
                        for (int i = 0; i < entrada.Length; i++) {
                            if (char.IsUpper(entrada[i]) || entrada[i] == ';') {
                                PalavraBruta += string.Join(PalavraBruta, $" {entrada[i]}");
                            }
                            else {
                                PalavraBruta += string.Join(PalavraBruta, entrada[i]);
                            }
                        }

                        if (PalavraBruta.Contains("()")) {
                            PalavraBruta = PalavraBruta.Remove(PalavraBruta.LastIndexOf("("), 2);
                        }

                        if (PalavraBruta.StartsWith(string.Empty)) {
                            PalavraBruta = PalavraBruta.Remove(0, PalavraBruta.LastIndexOf(";") + 1);
                            PalavraBruta = PalavraBruta.TrimStart(' ');
                        }
                        else {
                            PalavraBruta = PalavraBruta.Remove(PalavraBruta.IndexOf(Operacao), PalavraBruta.LastIndexOf(";"));
                        }

                        sb.AppendLine(PalavraBruta.ToLower());
                        break;

                    case "V":
                        for (int i = 0; i < entrada.Length; i++) {
                            if (char.IsUpper(entrada[i])) {
                                PalavraBruta += string.Join(PalavraBruta, $" {entrada[i]}");
                            }
                            else {
                                PalavraBruta += string.Join(PalavraBruta, entrada[i]);
                            }
                        }

                        if (PalavraBruta.Contains("()")) {
                            PalavraBruta = PalavraBruta.Remove(PalavraBruta.LastIndexOf("("), 2);
                        }

                        if (PalavraBruta.StartsWith(string.Empty)) {
                            PalavraBruta = PalavraBruta.Remove(0, PalavraBruta.LastIndexOf(";") + 1);
                            PalavraBruta = PalavraBruta.TrimStart(' ');
                        }
                        else {
                            PalavraBruta = PalavraBruta.Remove(PalavraBruta.IndexOf(Operacao), PalavraBruta.LastIndexOf(";"));
                        }

                        sb.AppendLine(PalavraBruta.ToLower());
                        break;
                }
            }

            // Combine case (M, C, V)
            if (Operacao == "C") {
                switch (Operando) {
                    case "C":
                        for (int i = 0; i < entrada.Length; i++) {
                            if (char.IsWhiteSpace(entrada[i]) || entrada[i] == ';') {
                                var regex = new Regex(Regex.Escape(entrada[i + 1].ToString()));
                                RecolocaUpper = regex.Replace(entrada[i + 1].ToString(), entrada[i + 1].ToString().ToUpper(), 1);

                                PalavraBruta = regex.Replace(PalavraBruta, RecolocaUpper, 1);
                            }

                            if (!entrada.Contains("()")) {
                                if (PalavraBruta == string.Empty) {
                                    PalavraBruta = entrada;
                                }
                            }

                            if (PalavraBruta.StartsWith(string.Empty)) {
                                PalavraBruta = PalavraBruta.Remove(0, PalavraBruta.LastIndexOf(";") + 1);
                                PalavraBruta = PalavraBruta.TrimStart(' ');
                            }
                            else {
                                PalavraBruta = PalavraBruta.Remove(PalavraBruta.IndexOf(Operacao), PalavraBruta.LastIndexOf(";"));
                            }
                        }

                        SemEspacos = Regex.Replace(PalavraBruta, @"\s+", "");

                        sb.AppendLine(SemEspacos);
                        break;

                    case "M":
                        for (int i = 0; i < entrada.Length; i++) {
                            if (char.IsWhiteSpace(entrada[i])) {
                                var regex = new Regex(Regex.Escape(entrada[i + 1].ToString()));
                                RecolocaUpper = regex.Replace(entrada[i + 1].ToString(), entrada[i + 1].ToString().ToUpper(), 1);

                                PalavraBruta = regex.Replace(PalavraBruta, RecolocaUpper, 1);
                            }

                            if (!entrada.Contains("()")) {
                                entrada += string.Join("(", "()");
                                PalavraBruta += entrada;
                            }

                            if (PalavraBruta.StartsWith(string.Empty)) {
                                PalavraBruta = PalavraBruta.Remove(0, PalavraBruta.LastIndexOf(";") + 1);
                                PalavraBruta = PalavraBruta.TrimStart(' ');
                            }
                            else {
                                PalavraBruta = PalavraBruta.Remove(PalavraBruta.IndexOf(Operacao), PalavraBruta.LastIndexOf(";"));
                            }
                        }

                        SemEspacos = Regex.Replace(PalavraBruta, @"\s+", "");

                        sb.AppendLine(SemEspacos);
                        break;

                    case "V":
                        if (!entrada.Contains("()")) {
                            if (PalavraBruta == string.Empty) {
                                PalavraBruta = entrada;
                            }
                        }

                        for (int i = 0; i < PalavraBruta.Length; i++) {
                            if (char.IsWhiteSpace(PalavraBruta[i])) {
                                var regex = new Regex(Regex.Escape(PalavraBruta[i + 1].ToString()));
                                RecolocaUpper = regex.Replace(PalavraBruta[i + 1].ToString(), PalavraBruta[i + 1].ToString().ToUpper(), 1);

                                int AjustaIndex = i + 1;

                                PalavraBruta = PalavraBruta.Remove(AjustaIndex, 1).Insert(AjustaIndex, RecolocaUpper);
                            }

                            if (PalavraBruta.StartsWith(string.Empty) && PalavraBruta.Contains(";")) {
                                PalavraBruta = PalavraBruta.Remove(0, PalavraBruta.LastIndexOf(";") + 1);
                                PalavraBruta = PalavraBruta.TrimStart(' ');
                            }
                        }

                        SemEspacos = Regex.Replace(PalavraBruta, @"\s+", string.Empty);

                        sb.AppendLine(SemEspacos);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}