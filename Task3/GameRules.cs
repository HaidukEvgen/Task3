namespace Task3
{
    public static class GameRules
    {
        private const string DRAW_MESSAGE = "It's a draw!";
        private const string WIN_MESSAGE = "You win!";
        private const string LOSE_MESSAGE = "You lose!";

        private const string DRAW_STATE = "Draw";
        private const string WIN_STATE = "Win";
        private const string LOSE_STATE = "Lose";

        public static GameResult GetGameResult(int userMove, int computerMove, string[] moves)
        {
            int half = moves.Length >> 1;
            int result = Math.Sign((userMove - computerMove + half + moves.Length) % moves.Length - half);
            return result switch
            {
                0 => GameResult.Draw,
                1 => GameResult.UserWin,
                -1 => GameResult.PCWin,
            }; 
        }

        public static string GetGameResultMessage(int userMove, int computerMove, string[] moves)
        {
            return GetGameResult(userMove, computerMove, moves) switch
            {
                GameResult.Draw => DRAW_MESSAGE,
                GameResult.UserWin => WIN_MESSAGE,
                GameResult.PCWin => LOSE_MESSAGE
            };
        }

        public static string GetGameResultState(int userMove, int computerMove, string[] moves)
        {
            return GetGameResult(userMove, computerMove, moves) switch
            {
                GameResult.Draw => DRAW_STATE,
                GameResult.UserWin => WIN_STATE,
                GameResult.PCWin => LOSE_STATE
            };
        }
    }
}
