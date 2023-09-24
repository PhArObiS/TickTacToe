using System;
using TickTacToe;

namespace TicTacToeNeilLopes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // Creating an instance of the TicTacToeGame class.
            TicTacToeGame game = new TicTacToeGame();

            // Calling the StartGame method of the game object, which initializes and starts the game loop for Tic Tac Toe.
            game.StartGame();
        }
    }
}
