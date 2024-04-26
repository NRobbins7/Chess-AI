﻿using Rudzoft.ChessLib;
using Rudzoft.ChessLib.Factories;
using Rudzoft.ChessLib.MoveGeneration;
using Rudzoft.ChessLib.Types;

namespace ChessEngine.Core
{
    public class MinimaxEngine
    {
        private readonly IGame _game;
        private static int _moveCount = 0;

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

            _moveCount = 0;
            var possibleMoves = _game.Pos.GenerateMoves();
            bool maximumPlayer = _game.CurrentPlayer() == Player.White;
            var moveEvals = new Dictionary<Move, double>();

            foreach (Move move in possibleMoves)
            {
                double val = PerformMinimax(move, depth - 1, double.NegativeInfinity, double.PositiveInfinity, maximumPlayer);
                moveEvals[move] = val;
            }

            var bestMove = moveEvals.OrderBy(x => x.Value).First().Key;
            Console.WriteLine("MoveCount: {0}", _moveCount);
            return bestMove;
        }

        private double PerformMinimax(Move evaluationMove, int depth, double alpha, double beta, bool isMaximizingPlayer)
        {
            _game.Pos.MakeMove(evaluationMove, new State());
            _moveCount++;

            var possibleMoves = _game.Pos.GenerateMoves();

            if (depth == 0 || _game.Pos.IsMate)
            {
                var value = EvaluateBoardPositions();
                _game.Pos.TakeMove(evaluationMove);

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
                _game.Pos.TakeMove(evaluationMove);
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
                _game.Pos.TakeMove(evaluationMove);
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