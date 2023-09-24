using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTacToe
{
    // The Player class represents a player in the Tic Tac Toe game.
    internal class Player
    {
        // Properties for the Player class. Each player will have a unique number (like 1 or 2) and an icon (either 'X' or 'O').
        public int Number { get; set; }
        public char Icon { get; set; }

        // Constructor for the Player class. It initializes the Number and Icon properties based on the given arguments.
        public Player(int number, char icon)
        {
            Number = number;
            Icon = icon;
        }

        // A virtual method called MakeMove that can be overridden by derived classes.
        // This method captures the cell choice of the player on the Tic Tac Toe board.
        public virtual int MakeMove(Board board)
        {
            int playerInput; // To store the cell choice of the player.
            bool isValidInput; // To determine if the input provided by the user is valid.

            do
            {
                // Prompt the player for their move.
                Console.Write("\nChoose your move Player {0} (or type 'exit' to quit): ", Number);
                string inputString = Console.ReadLine();

                // If the player types 'exit', the program will terminate.
                if (inputString?.ToLower() == "exit")
                {
                    Environment.Exit(0);
                }

                // Try parsing the input to an integer. If successful and the number is between 1 and 9, check if the chosen cell is empty.
                if (int.TryParse(inputString, out playerInput) && playerInput >= 1 && playerInput <= 9)
                {
                    if (board.IsCellEmpty(playerInput))
                    {
                        isValidInput = true; // The input is valid if the cell is empty.
                    }
                    else
                    {
                        // If the cell is not empty, show an error message and let the player choose again.
                        Console.WriteLine("\nCell is already occupied! Choose another cell!");
                        isValidInput = false;
                    }
                }
                else
                {
                    // If the input is not a number between 1 and 9, show an error message and let the player choose again.
                    Console.WriteLine("\nIncorrect input! Please choose a number between 1 and 9!");
                    isValidInput = false;
                }
            } while (!isValidInput); // This loop will continue until a valid input is received.

            // Return the valid cell choice.
            return playerInput;
        }
    }
}
