using System;
using SolverCore;

namespace TicTacToe
{
    public class TicTacToeMove : Move
    {
        Player player;
        int row;
        int column;

        public Player Player { get => player; set => player = value; }
        public int Row { get => row; set => row = value; }
        public int Column { get => column; set => column = value; }
    }
}
