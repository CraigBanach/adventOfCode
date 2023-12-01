using System.Text.RegularExpressions;

namespace Trebuchet {
    public class Trebuchet {
        static Regex regex = new(@"(?<!\d.)(\d).*(\d)(?!.*\d)|(\d)");
        static Regex regexWithWords = new(@"(?<!\d.)(\d|one|two|three|four|five|six|seven|eight|nine).*(\d|one|two|three|four|five|six|seven|eight|nine)(?!.*\d)|(\d|one|two|three|four|five|six|seven|eight|nine)");
        
        public static int CalculateSum() {
            string lines = File.ReadAllText("input.txt");

            int sum = 0;
            foreach (var match in regex.Matches(lines)) {
                var groups = (match as Match).Groups;

                if (groups[1].Value == string.Empty) {
                    sum += int.Parse(groups[0].Value + groups[0].Value);
                } else {
                    sum += int.Parse(groups[1].Value + groups[2].Value);
                }
            }

            return sum;
        }

        public static int CalculateSumWithWords() {
            string lines = File.ReadAllText("input.txt");

            int sum = 0;
            foreach (var match in regexWithWords.Matches(lines)) {
                var groups = (match as Match).Groups;

                if (groups[1].Value == string.Empty) {
                    sum += int.Parse(GetValueFromText(groups[0].Value) + GetValueFromText(groups[0].Value));
                } else {
                    sum += int.Parse(GetValueFromText(groups[1].Value) + GetValueFromText(groups[2].Value));
                }
            }

            return sum;
        }

        static Dictionary<string, string> textToNumberMap = new() {
            {"one", "1"},
            {"two", "2"},
            {"three", "3"},
            {"four", "4"},
            {"five", "5"},
            {"six", "6"},
            {"seven", "7"},
            {"eight", "8"},
            {"nine", "9"},
        };

        private static string GetValueFromText(string text) {
            if (text.Length > 1) {
                return textToNumberMap[text];
            }
            return text;
        }
    }
}

