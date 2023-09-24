using System;

namespace TickTacToe
{
    // This class represents the game board for Tic Tac Toe.
    internal class Board
    {
        // Initializing the game board with cells labeled from 1 to 9.
        private char[,] gameBoard =
        {
            {'7', '8', '9' },
            {'4', '5', '6' },
            {'1', '2', '3' }
        };

        // Method to return the current state of the game board.
        public char[,] GetGameBoard()
        {
            return gameBoard;
        }

        // Resetting the game board to its initial state.
        public void ResetGameBoard()
        {
            char[,] initialBoard =
            {
                {'7', '8', '9' },
                {'4', '5', '6' },
                {'1', '2', '3' }
            };

            gameBoard = initialBoard;
        }

        // Check if the specified cell (by number) is empty or not.
        public bool IsCellEmpty(int playerInput)
        {
            // Translate the input (1-9) into a row and column.
            int row = (playerInput - 1) / 3;
            int col = (playerInput - 1) % 3;
            // Check if the cell does not have either 'X' or 'O'.
            return gameBoard[2 - row, col] != 'X' && gameBoard[2 - row, col] != 'O';
        }

        // Set a cell's value to the specified player's icon ('X' or 'O').
        public void SetCellValue(char playerIcon, int playerInput)
        {
            int row = (playerInput - 1) / 3;
            int col = (playerInput - 1) % 3;
            gameBoard[2 - row, col] = playerIcon;
        }

        // Check if the provided player (through their icon) has a winning line.
        public bool IsWinner(char playerIcon)
        {
            // Check rows and columns for win condition.
            for (int i = 0; i < 3; i++)
            {
                if ((gameBoard[i, 0] == playerIcon && gameBoard[i, 1] == playerIcon && gameBoard[i, 2] == playerIcon) ||
                    (gameBoard[0, i] == playerIcon && gameBoard[1, i] == playerIcon && gameBoard[2, i] == playerIcon))
                {
                    return true;
                }
            }

            // Check diagonals for win condition.
            if ((gameBoard[0, 0] == playerIcon && gameBoard[1, 1] == playerIcon && gameBoard[2, 2] == playerIcon) ||
                (gameBoard[0, 2] == playerIcon && gameBoard[1, 1] == playerIcon && gameBoard[2, 0] == playerIcon))
            {
                return true;
            }

            return false; // No win found.
        }

        // Check if the game has ended in a draw (no empty cells).
        public bool IsGameDraw()
        {
            for (int i = 1; i <= 9; i++)
            {
                if (IsCellEmpty(i))
                {
                    return false; // Found an empty cell, so not a draw.
                }
            }
            return true; // All cells are occupied.
        }

        // Reset a specific cell (given its position) to its initial state.
        public void ResetCell(int position)
        {
            int row = (position - 1) / 3;
            int col = (position - 1) % 3;
            gameBoard[2 - row, col] = char.Parse(position.ToString());
        }

        // Check if the board still has any empty cells.
        public bool HasEmptyCells()
        {
            foreach (var cell in gameBoard)
            {
                if (cell != 'X' && cell != 'O')
                    return true; // Found an empty cell.
            }
            return false; // No empty cells found.
        }

        // Evaluate the board for game algorithms (like for AI decision making).
        // Returns +10 if 'O' has won, -10 if 'X' has won, or 0 if no win.
        public int EvaluateBoard()
        {
            if (IsWinner('O')) return 10;
            if (IsWinner('X')) return -10;
            return 0;
        }
    }
}
