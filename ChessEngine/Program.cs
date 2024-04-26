// See https://aka.ms/new-console-template for more information
using ChessEngine.Core;

Console.WriteLine("Hello, World!");
var engine = new MinimaxEngine();

var move = engine.CalculateNextMove(6);
Console.WriteLine(move.ToString());