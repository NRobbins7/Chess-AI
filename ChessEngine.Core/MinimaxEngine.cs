using ChessEngine.Core.Abstractions;
using Rudzoft.ChessLib;
using Rudzoft.ChessLib.Factories;
using Rudzoft.ChessLib.MoveGeneration;
using Rudzoft.ChessLib.Types;

namespace ChessEngine.Core
{
    public class MinimaxEngine : IChessEngine
    {
        private readonly IGame _game;

        public MinimaxEngine(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", IEnumerable<string> strMoves = null)
        {
            _game = GameFactory.Create(fen);

            if (strMoves != null)
            {
                var moves = strMoves.Select(strMove =>
                {
                    var fromSquare = new Square(Enum.Parse<Squares>(strMove.Substring(0, 2)));
                    var toSquare = new Square(Enum.Parse<Squares>(strMove.Substring(2, 2)));
                    return new Move(fromSquare, toSquare);
                });

                foreach (var move in moves)
                {
                    _game.Pos.MakeMove(move, new State());
                }
            }
        }

        public MinimaxEngine(string fen = "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", IEnumerable<Move> moves = null)
        {
            _game = GameFactory.Create(fen);
            if (moves != null)
            {
                foreach (var move in moves)
                {
                    _game.Pos.MakeMove(move, new State());
                }
            }
        }

        public Move CalculateNextMove(int depth)
        {
            var possibleMoves = _game.Pos.GenerateMoves();
            bool maximumPlayer = _game.CurrentPlayer() == Player.White;
            var moveEvals = new Dictionary<Move, double>();

            foreach (Move move in possibleMoves)
            {
                double val = PerformMinimax(move, depth - 1, double.NegativeInfinity, double.PositiveInfinity, maximumPlayer);
                moveEvals[move] = val;
            }

            var bestMove = moveEvals.OrderBy(x => x.Value).First().Key;
            return bestMove;
        }

        private double PerformMinimax(Move evaluationMove, int depth, double alpha, double beta, bool isMaximizingPlayer)
        {
            _game.Pos.MakeMove(evaluationMove, new State());
            if (depth == 0 || _game.Pos.IsMate)
            {
                var value = EvaluateBoardPositions();
                _game.Pos.TakeMove(evaluationMove);

                return value;
            }

            var possibleMoves = _game.Pos.GenerateMoves();
            double score;

            if (isMaximizingPlayer)
            {
                score = double.NegativeInfinity;
                foreach (var move in possibleMoves)
                {
                    double eval = PerformMinimax(move, depth - 1, alpha, beta, !isMaximizingPlayer);

                    score = Math.Max(score, eval);
                    alpha = Math.Max(alpha, eval);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }
            else
            {
                score = double.PositiveInfinity;
                foreach (var move in possibleMoves)
                {
                    double eval = PerformMinimax(move, depth - 1, alpha, beta, !isMaximizingPlayer);
                    score = Math.Min(score, eval);
                    beta = Math.Min(beta, eval);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
            }

            _game.Pos.TakeMove(evaluationMove);
            return score;
        }

        private double EvaluateBoardPositions()
        {
            var score = 0d;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var piece = _game.Pos.GetPiece(new Square(i, j));
                    var type = piece.Type();
                    var color = piece.ColorOf();
                    if (type != PieceTypes.NoPieceType)
                    {
                        var positionWeights = EvaluationConstants.PositionWeights[type][color];
                        score += positionWeights[i, j];
                        score += EvaluationConstants.PieceValue[type] * (color == Player.Black ? -1 : 1);
                    }
                }
            }
            return score;
        }
    }
}