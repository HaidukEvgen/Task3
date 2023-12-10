using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    public class Game(string[] moves)
    {
        private readonly Random random = new();

        public void Play()
        {
            var menu = GetMenu();
            while (true)
            {
                var key = KeyGenerator.Generate();
                var computerMove = GenerateComputerMove();
                var hmac = HmacGenerator.Generate(key, moves[computerMove]);

                Console.WriteLine($"HMAC: {hmac}");
                Console.WriteLine(menu);

                var userMove = GetUserMove();

                Console.WriteLine($"Your move: {moves[userMove]}");
                Console.WriteLine($"Computer move: {moves[computerMove]}");

                var gameResultMessage = GameRules.GetGameResultMessage(userMove, computerMove, moves);

                Console.WriteLine(gameResultMessage);
                Console.WriteLine($"HMAC key: {BitConverter.ToString(key).Replace("-", "")}\n");
            }
        }

        private string GetMenu()
        {
            var menu = new StringBuilder();
            menu.Append("Available moves:\n");
            for (int i = 0; i < moves.Length; i++)
            {
                menu.Append($"{i + 1} - {moves[i]}\n");
            }
            menu.Append("0 - exit\n");
            menu.Append("? - help");
            return menu.ToString();
        }

        private int GenerateComputerMove()
        {
            return random.Next(0, moves.Length);
        }

        private int GetUserMove()
        {
            while (true)
            {
                Console.Write("Enter your move: ");
                var input = Console.ReadLine();
                if (input == "?")
                {
                    Table.Generate(moves);
                    continue;
                }
                if (input == "0")
                {
                    Console.WriteLine("Exiting the game. Goodbye!");
                    Environment.Exit(0);
                }
                if (int.TryParse(input, out int userMove) && userMove >= 0 && userMove <= moves.Length)
                {
                    return userMove - 1;
                }
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }
}
