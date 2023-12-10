namespace Task3
{
    class Program
    {
        private const int MIN_ARGS_AMOUNT = 3;

        static void Main(string[] args)
        {
            if (args.Length < MIN_ARGS_AMOUNT || args.Length % 2 == 0 || args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("Invalid arguments. Please provide an odd number of unique moves.");
                return;
            }
            var game = new Game(args);
            game.Play();
        }
    }
}
