using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TickTacToe
{
    // The HumanPlayer class represents a human player in the Tic Tac Toe game.
    // It inherits from the Player class, implying that it would have all the properties and methods of the Player class.
    internal class HumanPlayer : Player
    {
        // Constructor for the HumanPlayer class.
        // It takes in a playerNumber (like Player 1 or Player 2) and an icon (either 'X' or 'O') for the player.
        // This constructor calls the base (Player) class constructor with the provided playerNumber and icon.
        public HumanPlayer(int playerNumber, char icon) : base(playerNumber, icon)
        { }

        // This method is used to capture and return the move made by a human player.
        // The method is an override, meaning that it's replacing the functionality of the MakeMove method from the Player class.
        public override int MakeMove(Board board)
        {
            return base.MakeMove(board);
        }
    }
}
