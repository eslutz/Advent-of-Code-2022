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
            Console.WriteLine($"Part 1 - The total score for Player is: {_totalScore}");
            _totalScore = Part2_GetTotalScore();
            Console.WriteLine($"Part 2 - The total score for Player is: {_totalScore}");

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

        private int Part2_GetTotalScore()
        {
            var score = 0;
            foreach (var move in _moves)
            {
                score += (int)GetPlayerMove(move) + (int)move.Outcome;
            }
            return score;
        }

        private static OUTCOME GetMatchOutcome(GameMove move)
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

        private static RPS GetPlayerMove(GameMove move)
        {
            if(move.Outcome == OUTCOME.Win)
            {
                if (move.Opponent == RPS.Rock) { return RPS.Paper; }
                else if (move.Opponent == RPS.Paper) { return RPS.Scissors; }
                else { return RPS.Rock; }
            }
            else if (move.Outcome == OUTCOME.Lose)
            {
                if (move.Opponent == RPS.Rock) { return RPS.Scissors; }
                else if (move.Opponent == RPS.Paper) { return RPS.Rock; }
                else { return RPS.Paper; }
            }
            else
            {
                return move.Opponent;
            }
        }

        public class GameMove
        {
            public RPS Opponent { get; private set; }
            public RPS Player { get; private set; }
            public OUTCOME Outcome { get; set; }

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

                // Part 1 - Set Player move
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

                // Part 2 - Set match outcome
                switch (playerMove)
                {
                    case 'X':
                        Outcome = OUTCOME.Lose;
                        break;
                    case 'Y':
                        Outcome = OUTCOME.Draw;
                        break;
                    case 'Z':
                        Outcome = OUTCOME.Win;
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