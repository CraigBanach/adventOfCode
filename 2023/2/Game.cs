namespace Game
{
    public class Games
    {
        public static int CalculatePossibleGames()
        {
            var games = File.ReadAllLines("input.txt");

            int sum = 0;
            for (var i = 0; i < games.Length; i++)
            {
                Console.WriteLine($"Game: {i}");
                var value = CalculateGameValue(games[i], i + 1);
                sum += value;
                Console.WriteLine($"\nGame Value Is: {value}\n");
            }
            return sum;
        }

        public static int CalculateGameValue(string game, int gameNumber)
        {
            var games = game.Split(':')[1];
            var rounds = games.Split(';');

            foreach (var round in rounds)
            {
                Console.WriteLine("Round: ");
                if (!CalculateRoundPossible(round)) return 0;
            }

            return gameNumber;
        }

        private static Dictionary<string, int> allowableDice = new Dictionary<string, int>(){
            {"red", 12},
            {"green", 13},
            {"blue", 14}
        };

        public static bool CalculateRoundPossible(string round)
        {
            var dice = round.Split(',');

            foreach (var die in dice)
            {
                var entry = die.Trim().Split(' ');
                Console.WriteLine("die: ");
                Console.WriteLine(entry[0]);
                Console.WriteLine(entry[1]);
                if (!(int.Parse(entry[0]) <= allowableDice[entry[1]])) return false;
            }

            return true;
        }
    }

    public class Power
    {
        public static int CalculateMinDice()
        {
            var games = File.ReadAllLines("input.txt");

            int sum = 0;
            foreach (var game in games)
            {
                sum += CalculateGameValue(game);
            }

            return sum;
        }

        public static int CalculateGameValue(string game)
        {
            var games = game.Split(':')[1];
            var rounds = games.Split(';');

            Dictionary<string, int> minDice = new Dictionary<string, int>() {
                {"red", 0},
                {"green", 0},
                {"blue", 0}
            };

            foreach (var round in rounds)
            {
                UpdateMinDiceWithRound(round, minDice);
            }

            return minDice.Values.Aggregate(1, (sum, next) => sum * next);
        }

        public static void UpdateMinDiceWithRound(string round, Dictionary<string, int> minDice)
        {
            var dice = round.Split(',');

            foreach (var die in dice)
            {
                var entry = die.Trim().Split(' ');
                if (minDice[entry[1]] < int.Parse(entry[0]))
                {
                    minDice[entry[1]] = int.Parse(entry[0]);
                }
            }
        }
    }
}
