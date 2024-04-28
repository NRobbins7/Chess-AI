using ChessEngine.Core;
using ChessEngine.Core.Abstractions;

namespace ChessEngine.Uci
{
    public class UciGame
    {
        private IChessEngine _chessEngine = null!;

        public void StartGame()
        {
            var stopEngine = false;

            do
            {
                var input = Console.ReadLine();
                var splitInput = new Stack<string>(input!.Split(" ").Reverse());

                switch (splitInput.Pop())
                {
                    case "uci":
                        Console.WriteLine("uciok");
                        break;
                    case "isready":
                        Console.WriteLine("readyok");
                        break;
                    case "position":
                        SetupBoard(splitInput);
                        break;
                    case "go":
                        if (_chessEngine != null) Console.WriteLine("bestmove {0}", _chessEngine.CalculateNextMove(5));
                        break;
                    case "quit":
                        stopEngine = false;
                        break;
                };
            } while (!stopEngine);
        }

        private void SetupBoard(Stack<string> splitInput)
        {
            var fen = splitInput.Pop() switch
            {
                "startpos" => "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1",
                "fen" => splitInput.Pop(),
                _ => throw new ArgumentException("Invalid Command Format")
            };

            var moves = splitInput.TryPop(out var input) && input == "moves" ? splitInput : null;
            _chessEngine = new MinimaxEngine(fen, moves!);
        }
    }
}
