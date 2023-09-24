using System;

namespace TickTacToe
{
    internal class AIPlayer : Player
    {
        // These constants represent the maximum and minimum possible values used in the minimax algorithm.
        private const int MAX_VALUE = 1000;
        private const int MIN_VALUE = -1000;

        // Constructor that initializes the AIPlayer with its number and icon ('X' or 'O').
        public AIPlayer(int number, char icon) : base(number, icon)
        { }

        // Override of the MakeMove function to let the AI choose its move.
        public override int MakeMove(Board board)
        {
            int bestMove = -1;  // Initialize the best move to an invalid position.
            int bestValue = MIN_VALUE;  // Start with the lowest possible value.

            // Loop through every possible move on the board.
            for (int i = 1; i <= 9; i++)
            {
                // Only consider the cell if it's empty.
                if (board.IsCellEmpty(i))
                {
                    // Mark the board temporarily with AI's move.
                    MarkBoard(board, this.Icon, i);

                    // Calculate the value of this move using the minimax algorithm.
                    int moveValue = Minimax(board, 0, false, MIN_VALUE, MAX_VALUE);

                    // Restore the board to its previous state.
                    RestoreBoard(board, i);

                    // If the value of this move is better than the previously found best, update bestMove and bestValue.
                    if (moveValue > bestValue)
                    {
                        bestMove = i;
                        bestValue = moveValue;
                    }
                }
            }
            // Return the best move found.
            return bestMove;
        }

        // Minimax is a recursive function that computes the best possible move for the AI.
        private int Minimax(Board board, int depth, bool isMaximizingPlayer, int alpha, int beta)
        {
            // Evaluate the current state of the board.
            int boardValue = board.EvaluateBoard();

            // If the game has a winner, return the board's value adjusted for depth.
            if (boardValue != 0)
                return boardValue - depth * (boardValue / Math.Abs(boardValue));

            // If there are no empty cells, it's a tie, and return 0.
            if (!board.HasEmptyCells())
                return 0;

            // If it's AI's turn (maximizing player).
            if (isMaximizingPlayer)
            {
                int bestVal = MIN_VALUE;

                // Try every possible move.
                for (int i = 1; i <= 9; i++)
                {
                    if (board.IsCellEmpty(i))
                    {
                        MarkBoard(board, this.Icon, i);

                        // Recursively calculate the value of this move.
                        int value = Minimax(board, depth + 1, false, alpha, beta);
                        bestVal = Math.Max(bestVal, value);
                        alpha = Math.Max(alpha, bestVal);

                        RestoreBoard(board, i);

                        // Alpha-beta pruning: if alpha >= beta, break out of the loop.
                        if (beta <= alpha)
                            break;
                    }
                }
                return bestVal;
            }
            // If it's the opponent's turn (minimizing player).
            else
            {
                // Determine the opponent's icon.
                char opponentIcon = (this.Icon == 'O') ? 'X' : 'O';
                int bestVal = MAX_VALUE;

                for (int i = 1; i <= 9; i++)
                {
                    if (board.IsCellEmpty(i))
                    {
                        MarkBoard(board, opponentIcon, i);

                        int value = Minimax(board, depth + 1, true, alpha, beta);
                        bestVal = Math.Min(bestVal, value);
                        beta = Math.Min(beta, bestVal);

                        RestoreBoard(board, i);

                        // Alpha-beta pruning.
                        if (beta <= alpha)
                            break;
                    }
                }
                return bestVal;
            }
        }

        // Helper function to mark the board with a given icon at the specified position.
        private void MarkBoard(Board board, char icon, int position)
        {
            board.SetCellValue(icon, position);
        }

        // Helper function to reset a cell on the board to its original state.
        private void RestoreBoard(Board board, int position)
        {
            board.ResetCell(position);
        }
    }
}
