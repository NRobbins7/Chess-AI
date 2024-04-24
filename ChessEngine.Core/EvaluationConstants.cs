using Chess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngine.Core
{
    internal static class EvaluationConstants
    {
        public static Dictionary<PieceType, int> PieceValue { get; } = new()
        {
            { PieceType.Pawn, 10 },
            { PieceType.Knight, 30 },
            { PieceType.Bishop, 30 },
            { PieceType.Rook, 50 },
            { PieceType.Queen, 90 },
            { PieceType.King, 900 }
        };

        public static double[,] PawnPositionWeightsWhite { get; } = new double[,]
        {
            { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
            { 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0, 5.0 },
            { 1.0, 1.0, 2.0, 3.0, 3.0, 2.0, 1.0, 1.0 },
            { 0.5, 0.5, 1.0, 2.5, 2.5, 1.0, 0.5, 0.5 },
            { 0.0, 0.0, 0.0, 2.0, 2.0, 0.0, 0.0, 0.0 },
            { 0.5, -0.5, -1.0, 0.0, 0.0, -1.0, -0.5, 0.5 },
            { 0.5, 1.0, 1.0, -2.0, -2.0, 1.0, 1.0, 0.5 },
            { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 }
        };

        public static double[,] KnightPositionWeights { get; } = new double[,]
        {
            { -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0 },
            { -4.0, -2.0, 0.0, 0.0, 0.0, 0.0, -2.0, -4.0 },
            { -3.0, 0.0, 1.0, 1.5, 1.5, 1.0, 0.0, -3.0 },
            { -3.0, 0.5, 1.5, 2.0, 2.0, 1.5, 0.5, -3.0 },
            { -3.0, 0.0, 1.5, 2.0, 2.0, 1.5, 0.0, -3.0 },
            { -3.0, 0.5, 1.0, 1.5, 1.5, 1.0, 0.5, -3.0 },
            { -4.0, -2.0, 0.0, 0.5, 0.5, 0.0, -2.0, -4.0 },
            { -5.0, -4.0, -3.0, -3.0, -3.0, -3.0, -4.0, -5.0 }
        };

        public static double[,] BishopPositionWeightsWhite { get; } = new double[,]
        {
            { -2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0 },
            { -1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0 },
            { -1.0, 0.0, 0.5, 1.0, 1.0, 0.5, 0.0, -1.0 },
            { -1.0, 0.5, 0.5, 1.0, 1.0, 0.5, 0.5, -1.0 },
            { -1.0, 0.0, 1.0, 1.0, 1.0, 1.0, 0.0, -1.0 },
            { -1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, -1.0 },
            { -1.0, 0.5, 0.0, 0.0, 0.0, 0.0, 0.5, -1.0 },
            { -2.0, -1.0, -1.0, -1.0, -1.0, -1.0, -1.0, -2.0 }
        };

        public static double[,] RookPositionWeightsWhite { get; } = new double[,]
        {
            { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
            { 0.5, 1.0, 1.0, 1.0, 1.0, 1.0, 1.0, 0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { -0.5, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -0.5 },
            { 0.0, 0.0, 0.0, 0.5, 0.5, 0.0, 0.0, 0.0 }
        };

        public static double[,] QueenPositionWeights { get; } = new double[,]
        {
            { -2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0 },
            { -1.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, -1.0 },
            { -1.0, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -1.0 },
            { -0.5, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -0.5 },
            { 0.0, 0.0, 0.5, 0.5, 0.5, 0.5, 0.0, -0.5 },
            { -1.0, 0.5, 0.5, 0.5, 0.5, 0.5, 0.0, -1.0 },
            { -1.0, 0.0, 0.5, 0.0, 0.0, 0.0, 0.0, -1.0 },
            { -2.0, -1.0, -1.0, -0.5, -0.5, -1.0, -1.0, -2.0 }
        };

        public static double[,] KingPositionWeightsWhite { get; } = new double[,]
        {
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -3.0, -4.0, -4.0, -5.0, -5.0, -4.0, -4.0, -3.0 },
            { -2.0, -3.0, -3.0, -4.0, -4.0, -3.0, -3.0, -2.0 },
            { -1.0, -2.0, -2.0, -2.0, -2.0, -2.0, -2.0, -1.0 },
            { 2.0, 2.0, 0.0, 0.0, 0.0, 0.0, 2.0, 2.0 },
            { 2.0, 3.0, 1.0, 0.0, 0.0, 1.0, 3.0, 2.0 }
        };

        public static double[,] PawnPositionWeightsBlack { get; } = ReverseArray(PawnPositionWeightsWhite);
        public static double[,] BishopPositionWeightsBlack { get; } = ReverseArray(BishopPositionWeightsWhite);
        public static double[,] RookPositionWeightsBlack { get; } = ReverseArray(RookPositionWeightsWhite);
        public static double[,] KingPositionWeightsBlack { get; } = ReverseArray(KingPositionWeightsWhite);

        public static Dictionary<PieceType, Dictionary<PieceColor, double[,]>> PositionWeights { get; } = new() 
        { 
            { 
                PieceType.Pawn, new() 
                { 
                    { PieceColor.White, PawnPositionWeightsWhite }, 
                    { PieceColor.Black, PawnPositionWeightsBlack } 
                } 
            }, 
            { 
                PieceType.Rook, new() 
                { 
                    { PieceColor.White, RookPositionWeightsWhite }, 
                    { PieceColor.Black, RookPositionWeightsBlack } 
                }
            },
            {
                PieceType.Knight, new()
                {
                    { PieceColor.White, KnightPositionWeights },
                    { PieceColor.Black, KnightPositionWeights }
                }
            },
            {
                PieceType.Bishop, new()
                {
                    { PieceColor.White, BishopPositionWeightsWhite },
                    { PieceColor.Black, BishopPositionWeightsBlack }
                }
            },
            {
                PieceType.Queen, new()
                {
                    { PieceColor.White, QueenPositionWeights },
                    { PieceColor.Black, QueenPositionWeights }
                }
            },
            {
                PieceType.King, new()
                {
                    { PieceColor.White, KingPositionWeightsWhite },
                    { PieceColor.Black, KingPositionWeightsBlack }
                }
            },
        };

        private static double[,] ReverseArray(double[,] array)
        {
            var outputArray = new double[8, 8]; 
            array.CopyTo(outputArray, 0);
            Array.Reverse(outputArray);
            return outputArray;
        }
    }
}
