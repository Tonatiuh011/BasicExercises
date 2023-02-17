using System;
using System.Text;
using System.Xml.Linq;
using C = Classes.Constant.Constants;
using D = Classes.Common.Delegates;

namespace Classes.Common {

    public static class Utils {

        public static void PrintResult(string name, string? value = null) => PrintMsg(FormatResult(name, value));
        public static void PrintMsg(string msg) => Console.WriteLine(FormatLine(msg));
        public static void BreakLine(string? title = null) {

            string line = FormatLine(C.CHAR_LIMIT, C.CHAR_BG);

            if (!string.IsNullOrEmpty(title) && line.Length > 0 && line.Length > title.Length  ) {

                char[] titleChars = title.ToCharArray();
                int count = 0;
                int titleLen = title.Length;
                int lineMiddle = line.Length / 2 - 1;
                int titleMiddle = title.Length / 2 - 1;

                decimal midStr = Math.Round((decimal)lineMiddle, 1);
                decimal titleMidStr = Math.Round((decimal)titleMiddle, 1);

                decimal beforeMid = midStr - titleMidStr;

                char[] lineChars = line.ToCharArray();

                for(int x = 0; x < lineChars.Length ; x++) {
                    if (x >= beforeMid && count < titleLen) {
                        lineChars[x] = titleChars[count];
                        count++;
                    }
                }

                line = new string(lineChars);

            }

            Console.WriteLine(line);
        }

        public static void EmptyLine() => Console.WriteLine("\n");

        public static string? ReadLine(string name) {
            Console.Write(FormatLine(FormatResult(name)));
            return Console.ReadLine();
        }

        public static T ReadLine<T>(string name) where T : struct => Parser.Parse<T>(
            ReadLine(name)
        );

        public static void WaitLine()
        {
            Console.Write(FormatLine("Press a key to continue..."));
            Console.ReadLine();
        }

        private static string FormatLine(int len, char c) {
            var line = new StringBuilder();

            for(int x = 0; x < len ; x ++) line.Append(c);

            return line.ToString();
        }
        public static string FormatLine (string text) => $"* \t {text}";        
        public static string FormatResult (string name, string? value = null) => $"{name}: {value}";

        // Math Stuff 
        public static string MathProcessor(D.MathCallback mathBlock, D.OnExeption? onError = null) {
            try {
                return mathBlock().ToString();
            } catch (Exception ex) {
                onError?.Invoke(ex);
                return string.Empty;
            }
        }
    }


    public static class Parser {

        public static T Parse<T>(object? obj, D.OnExeption? onExeption = null) where T : struct 
        {
            try {

                var str = ToString(obj);
                return (T)Convert.ChangeType(str, typeof(T));

            } catch (Exception ex){

                onExeption?.Invoke(ex);                
                return default;

            }
        }

        public static string ToString(object? obj) {

            var str = obj?.ToString();

            if (!string.IsNullOrEmpty(str)) {
                return str;
            } else {
                return string.Empty;
            }

        }                
        
    }
}