using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTacToe
{
    // Display is a static class. This means you don't need to create an instance of it to use its methods.
    // This class is responsible for all display related functionalities in the Tic Tac Toe game.
    internal static class Display
    {
        // Shows the game board on the console.
        public static void ShowBoard(Board board)
        {
            // Fetch the current state of the board.
            char[,] boardValues = board.GetGameBoard();

            // Clear the console.
            Console.Clear();

            // Set the text color to Cyan.
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Display the game header.
            Console.WriteLine("-----------------------------");
            Console.WriteLine("| -*-*-*- TicTacToe -*-*-*- |");
            Console.WriteLine("-----------------------------");

            // Reset text color to default.
            Console.ResetColor();

            // Display the game board with its current state.
            // Here, GetColoredSymbol is used to fetch the colored representation (either red X or blue O) of the cell value.
            // If the cell is neither 'X' nor 'O', it just displays the number.
            Console.WriteLine("|                           |");
            Console.WriteLine("|                           |");
            Console.WriteLine("|           |   |           |");
            Console.WriteLine("|         {0} | {1} | {2}         |", GetColoredSymbol(boardValues[0, 0]), GetColoredSymbol(boardValues[0, 1]), GetColoredSymbol(boardValues[0, 2]));
            Console.WriteLine("|       ----|---|----       |");
            Console.WriteLine("|         {0} | {1} | {2}         |", GetColoredSymbol(boardValues[1, 0]), GetColoredSymbol(boardValues[1, 1]), GetColoredSymbol(boardValues[1, 2]));
            Console.WriteLine("|       ----|---|----       |");
            Console.WriteLine("|         {0} | {1} | {2}         |", GetColoredSymbol(boardValues[2, 0]), GetColoredSymbol(boardValues[2, 1]), GetColoredSymbol(boardValues[2, 2]));
            Console.WriteLine("|           |   |           |");
            Console.WriteLine("|                           |");
            Console.WriteLine("|                           |");
            Console.WriteLine("|---------------------------|");
        }

        // A helper function that returns the colored representation of a Tic Tac Toe cell value.
        private static string GetColoredSymbol(char symbol)
        {
            switch (symbol)
            {
                case 'X':
                    return "\u001b[31mX\u001b[0m"; // ANSI escape code for Red X.
                case 'O':
                    return "\u001b[34mO\u001b[0m"; // ANSI escape code for Blue O.
                default:
                    return symbol.ToString();     // If it's neither 'X' nor 'O', return the symbol as-is.
            }
        }

        // Clears the board display from the console.
        // This is useful if you want to refresh the console without clearing everything.
        public static void ClearPreviousBoard()
        {
            // Clears the previous 5 lines.
            for (int i = 0; i < 5; i++)
            {
                if (Console.CursorTop > 0)  // Ensure the cursor isn't at the topmost row.
                {
                    // Go to the start of the current line.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);

                    // Clear the entire line by writing spaces.
                    Console.Write(new string(' ', Console.WindowWidth));

                    // Move the cursor back to the start of the line.
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }
            }
        }

        // Display a message on the console.
        public static void ShowMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
