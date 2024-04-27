using Rudzoft.ChessLib.Types;

namespace ChessEngine.Core
{
    internal static class EvaluationConstants
    {
        public static Dictionary<PieceTypes, int> PieceValue { get; } = new()
        {
            { PieceTypes.Pawn, 10 },
            { PieceTypes.Knight, 30 },
            { PieceTypes.Bishop, 30 },
            { PieceTypes.Rook, 50 },
            { PieceTypes.Queen, 90 },
            { PieceTypes.King, 900 }
        };

        public static double[,] PawnPositionWeightsWhite { get; } =
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

        public static double[,] KnightPositionWeights { get; } =
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

        public static double[,] BishopPositionWeightsWhite { get; } =
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

        public static double[,] RookPositionWeightsWhite { get; } =
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

        public static double[,] QueenPositionWeights { get; } =
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

        public static double[,] KingPositionWeightsWhite { get; } =
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

        public static Dictionary<PieceTypes, Dictionary<Player, double[,]>> PositionWeights { get; } = new() 
        { 
            {
                PieceTypes.Pawn, new() 
                { 
                    { Player.White, PawnPositionWeightsWhite }, 
                    { Player.Black, PawnPositionWeightsBlack } 
                } 
            }, 
            {
                PieceTypes.Rook, new() 
                { 
                    { Player.White, RookPositionWeightsWhite }, 
                    { Player.Black, RookPositionWeightsBlack } 
                }
            },
            {
                PieceTypes.Knight, new()
                {
                    { Player.White, KnightPositionWeights },
                    { Player.Black, KnightPositionWeights }
                }
            },
            {
                PieceTypes.Bishop, new()
                {
                    { Player.White, BishopPositionWeightsWhite },
                    { Player.Black, BishopPositionWeightsBlack }
                }
            },
            {
                PieceTypes.Queen, new()
                {
                    { Player.White, QueenPositionWeights },
                    { Player.Black, QueenPositionWeights }
                }
            },
            {
                PieceTypes.King, new()
                {
                    { Player.White, KingPositionWeightsWhite },
                    { Player.Black, KingPositionWeightsBlack }
                }
            },
        };

        private static double[,] ReverseArray(double[,] array)
        {
            var outputArray = array.Clone() as double[,];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var temp = outputArray![i, j];
                    outputArray[i, j] = outputArray[outputArray.Length / 8 - i - 1, j];
                    outputArray[outputArray.Length / 8 - i - 1, j] = temp;
                }
            }
            return outputArray;
        }
    }
}
