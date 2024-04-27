using Rudzoft.ChessLib.Types;

namespace ChessEngine.Core.Abstractions
{
    public interface IChessEngine
    {
        Move CalculateNextMove(int depth);
    }
}