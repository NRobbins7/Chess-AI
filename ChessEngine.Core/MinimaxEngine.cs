using Chess;
using System.Drawing;

namespace ChessEngine.Core
{
    public class MinimaxEngine
    {
        private readonly ChessBoard _board;

        public MinimaxEngine()
        {
            _board = new();
        }

        public Move CalculateMove(Move opponentMove)
        {
            _board.Move(opponentMove);
            var possibleMoves = _board.Moves();
            bool maximumPlayer = _board.Turn == PieceColor.White;
            Dictionary<Move, double> moveEvals = new Dictionary<Move, double>();

            foreach (Move move in possibleMoves)
            {
                double val = PerformMinimax(move, 5, double.NegativeInfinity, double.PositiveInfinity, maximumPlayer);
                moveEvals[move] = val;
            }

            Move bestMove = moveEvals.OrderBy(x => x.Value).First().Key;
            return bestMove;
        }

        private double PerformMinimax(Move evaluationMove, int depth, double alpha, double beta, bool isMaximizingPlayer)
        {
            _board.Move(evaluationMove);
            var possibleMoves = _board.Moves();
            if(depth == 0 || _board.IsEndGame)
            {
                var value = EvaluateBoardPositions();
                _board.Cancel();
                return value;
            }

            if (isMaximizingPlayer)
            {
                double maxEval = double.NegativeInfinity;
                foreach (var move in possibleMoves)
                {
                    double eval = PerformMinimax(move, depth - 1, alpha, beta, false);
                    maxEval = Math.Max(maxEval, eval);
                    alpha = Math.Max(alpha, eval);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
                _board.Cancel();
                return maxEval;
            }
            else
            {
                double minEval = double.PositiveInfinity;
                foreach (var move in possibleMoves)
                {
                    double eval = PerformMinimax(move, depth - 1, alpha, beta, true);
                    minEval = Math.Min(minEval, eval);
                    beta = Math.Min(beta, eval);
                    if (beta <= alpha)
                    {
                        break;
                    }
                }
                _board.Cancel();
                return minEval;
            }


        }

        private double EvaluateBoardPositions()
        {
            var score = 0d;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var piece = _board[i, j];
                    if(piece != null)
                    {
                        var positionWeights = EvaluationConstants.PositionWeights[piece.Type][piece.Color];
                        score += positionWeights[i, j];
                        score += EvaluationConstants.PieceValue[piece.Type] * (piece.Color == PieceColor.Black ? -1 : 1);
                    }
                }
            }
            return score;
        }
    }
}