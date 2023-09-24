using System;

namespace TickTacToe
{
    internal class TicTacToeGame
    {
        // Member variables to store the game board and player information.
        private Board newBoard;
        private Player player1;
        private Player player2;
        private Player currentPlayer;

        public void StartGame()
        {
            do
            {
                // Display welcome message at the beginning of each game.
                DisplayWelcomeMessage();

                // Setup players based on user choice.
                InitializePlayers();

                // Initialize a new board for the game.
                newBoard = new Board();
                Display.ShowBoard(newBoard);

                while (true)
                {
                    // Current player makes their move.
                    TakeTurn(currentPlayer);

                    // Refresh the board display after each move.
                    Display.ClearPreviousBoard();
                    Display.ShowBoard(newBoard);

                    // If game has concluded (win or draw), exit the game loop.
                    if (CheckGameStatus()) break;

                    // Switch to the other player for the next turn.
                    SwitchPlayer();
                }

                // Ask players if they want to play another game.
                Console.WriteLine("Would you like to play again? (Y/N)");
            } while (Console.ReadLine().ToUpper() == "Y"); // If "Y", game restarts.
        }

        // A method to display a welcome message for players.
        private void DisplayWelcomeMessage()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Tic Tac Toe!");
        }

        // This method initializes the players based on user input.
        private void InitializePlayers()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            // A decorative header for the game's menu.
            Console.WriteLine("-----------------------------");
            Console.WriteLine("| -*-*-*- TicTacToe -*-*-*- |");
            Console.WriteLine("-----------------------------");
            Console.ResetColor();

            // Player can choose to play against the AI or another human.
            Console.WriteLine("|                           |");
            Console.WriteLine("|    1. 1 Player vs AI      |");
            Console.WriteLine("|    2. 2 Players           |");
            Console.WriteLine("|                           |");
            Console.WriteLine("|    Choose an option:      |");

            // Input loop to ensure valid choice is made by user.
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice != 1 && choice != 2))
            {
                Console.WriteLine("Invalid choice. Please select 1 or 2.");
            }

            // Initialize player objects based on the user's choice.
            player1 = new HumanPlayer(1, 'X'); // Player 1 is always human and plays with 'X'.
            // Player 2 can be AI or human based on the choice.
            player2 = choice == 1 ? (Player)new AIPlayer(2, 'O') : new HumanPlayer(2, 'O');
            currentPlayer = player1; // Game starts with Player 1's turn.
        }

        // This method facilitates a player's turn.
        private void TakeTurn(Player player)
        {
            Console.WriteLine($"\nPlayer {player.Number}'s turn ({player.Icon}):");

            int move;
            do
            {
                // Get the desired cell number where player wants to make a move.
                move = player.MakeMove(newBoard);

                // Check if the chosen cell is empty. If not, ask for input again.
                if (!newBoard.IsCellEmpty(move))
                {
                    Console.WriteLine("The cell is already occupied! Try again.");
                }
            } while (!newBoard.IsCellEmpty(move));

            // Set the chosen cell's value to the player's icon ('X' or 'O').
            newBoard.SetCellValue(player.Icon, move);
        }

        // This method checks if the game has concluded (either win or draw).
        private bool CheckGameStatus()
        {
            // Check if the current player has won.
            if (newBoard.IsWinner(currentPlayer.Icon))
            {
                // Display appropriate win message.
                if (currentPlayer is AIPlayer)
                {
                    Console.WriteLine("AI wins! Try again.");
                }
                else
                {
                    Console.WriteLine(player2 is AIPlayer ? "Congratulations! You beat the AI!" : $"Player {currentPlayer.Number} wins!");
                }
                return true; // Game has ended.
            }

            // Check if the game has ended in a draw.
            if (newBoard.IsGameDraw())
            {
                Console.WriteLine("The game is a draw!");
                return true; // Game has ended.
            }

            return false; // Game is still ongoing.
        }

        // This method switches the turn to the other player.
        private void SwitchPlayer()
        {
            currentPlayer = currentPlayer == player1 ? player2 : player1;
        }
    }
}
