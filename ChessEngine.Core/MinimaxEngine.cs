using Rudzoft.ChessLib;
using Rudzoft.ChessLib.Factories;
using Rudzoft.ChessLib.MoveGeneration;
using Rudzoft.ChessLib.Types;

namespace ChessEngine.Core
{
    public class MinimaxEngine
    {
        private readonly IGame _game;

        public MinimaxEngine()
        {
            _game = GameFactory.Create("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");
        }

        public Move CalculateNextMove(int depth, Move? opponentMove = null)
        {
            if (opponentMove.HasValue)
            {
                _game.Pos.MakeMove(opponentMove.Value, new State());
            }

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