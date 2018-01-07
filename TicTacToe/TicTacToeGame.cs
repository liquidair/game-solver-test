using SolverCore;

namespace TicTacToe
{
    class TicTacToeGame : Game
    {
        TicTacToeBoard start;

        public TicTacToeGame(int size)
        {
            start = new TicTacToeBoard(size);
        }

        public Position Start => start;
    }
}
