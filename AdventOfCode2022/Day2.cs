namespace AdventOfCode2022
{
    public class Day2
    {
        private readonly string _inputFile = "Input/Day_2_Input.txt";
        private readonly List<GameMove> _moves = new();
        private readonly int _totalScore;

        public Day2()
        {
            string line;
            using StreamReader file = new(_inputFile);
            while ((line = file.ReadLine()!) is not null)
            {
                var currentMoves = line.ToCharArray();
                _moves.Add(new GameMove(currentMoves[0], currentMoves[2]));
            }
            file.Close();

            _totalScore = Part1_GetTotalScore();
            Console.WriteLine($"The total score for Player is: {_totalScore}");
        }

        private int Part1_GetTotalScore()
        {
            var score = 0;
            foreach (var move in _moves)
            {
                score += (int)move.Player + (int)GetMatchOutcome(move);
            }
            return score;
        }

        private OUTCOME GetMatchOutcome(GameMove move)
        {
            if ((move.Opponent == RPS.Rock && move.Player == RPS.Scissors)
                || (move.Opponent == RPS.Paper && move.Player == RPS.Rock)
                || (move.Opponent == RPS.Scissors && move.Player == RPS.Paper))
            {
                return OUTCOME.Lose;
            }
            else if ((move.Opponent == RPS.Rock && move.Player == RPS.Rock)
                || (move.Opponent == RPS.Paper && move.Player == RPS.Paper)
                || (move.Opponent == RPS.Scissors && move.Player == RPS.Scissors))
            {
                return OUTCOME.Draw;
            }
            else
            {
                return OUTCOME.Win;
            }
        }

        public class GameMove
        {
            public RPS Opponent { get; private set; }
            public RPS Player { get; private set; }

            public GameMove(char opponentMove, char playerMove)
            {
                // Set Opponent move
                switch (opponentMove)
                {
                    case 'A':
                        Opponent = RPS.Rock;
                        break;
                    case 'B':
                        Opponent = RPS.Paper;
                        break;
                    case 'C':
                        Opponent = RPS.Scissors;
                        break;
                }

                // Set Player move
                switch (playerMove)
                {
                    case 'X':
                        Player = RPS.Rock;
                        break;
                    case 'Y':
                        Player = RPS.Paper;
                        break;
                    case 'Z':
                        Player = RPS.Scissors;
                        break;
                }
            }
        }

        public enum RPS
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }

        public enum OUTCOME
        {
            Win = 6,
            Draw = 3,
            Lose = 0
        }
    }
}