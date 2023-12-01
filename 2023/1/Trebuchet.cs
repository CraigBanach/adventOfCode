using System.Text.RegularExpressions;

namespace Trebuchet {
    public class Trebuchet {
        static Regex regex = new(@"(?<!\d.)(\d).*(\d)(?!.*\d)|(\d)");

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
    }
}

