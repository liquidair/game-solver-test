using SolverCore;
using System.Collections.Generic;

namespace TicTacToe
{
    public class TicTacToeBoard : Position
    {
        enum Square
        {
            Empty,
            X,
            O
        }

        List<List<Square>> board;
        Player toMove;

        public TicTacToeBoard(int size)
        {
            board = new List<List<Square>>(size);
            for (int i = 0; i < size; ++i)
            {
                var row = new List<Square>(size);
                for (int j = 0; j < size; ++j)
                {
                    row.Add(Square.Empty);
                }
                board.Add(row);
            }
            toMove = Player.First;
        }

        public Player ToMove => toMove;

        public List<Move> GetMoves()
        {
            List<Move> moves = new List<Move>();
            if (Result() == SolverCore.Result.None)
            {
                for (int i = 0; i < board.Count; ++i)
                {
                    List<Square> row = board[i];
                    for (int j = 0; j < row.Count; ++j)
                    {
                        if (row[j] == Square.Empty)
                        {
                            moves.Add(new TicTacToeMove { Row = i, Column = j, Player = toMove });
                        }
                    }
                }
            }
            return moves;
        }

        public Result Result()
        {
            Result result = SolverCore.Result.None;

            // Check the diagonals.
            int XCount = 0;
            int OCount = 0;
            for (int i = 0; i < board.Count; ++i)
            {
                switch (board[i][i])
                {
                    case Square.Empty:
                        break;
                    case Square.X:
                        ++XCount;
                        break;
                    case Square.O:
                        ++OCount;
                        break;
                }
            }
            if (XCount == board.Count)
            {
                return SolverCore.Result.FirstWins;
            }
            if (OCount == board.Count)
            {
                return SolverCore.Result.SecondWins;
            }
            XCount = 0;
            OCount = 0;
            for (int i = 0; i < board.Count; ++i)
            {
                switch (board[board.Count - i - 1][i])
                {
                    case Square.Empty:
                        break;
                    case Square.X:
                        ++XCount;
                        break;
                    case Square.O:
                        ++OCount;
                        break;
                }
            }
            if (XCount == board.Count)
            {
                return SolverCore.Result.FirstWins;
            }
            if (OCount == board.Count)
            {
                return SolverCore.Result.SecondWins;
            }

            // Check the rows.
            int emptyCount = 0;
            for (int i = 0; i < board.Count; ++i)
            {
                XCount = 0;
                OCount = 0;
                List<Square> row = board[i];
                for (int j = 0; j < row.Count; ++j)
                {
                    switch(row[j])
                    {
                        case Square.Empty:
                            ++emptyCount;
                            break;
                        case Square.X:
                            ++XCount;
                            break;
                        case Square.O:
                            ++OCount;
                            break;
                    }
                }
                if (XCount == row.Count)
                {
                    return SolverCore.Result.FirstWins;
                }
                if (OCount == row.Count)
                {
                    return SolverCore.Result.SecondWins;
                }
            }

            // Check the columns.
            emptyCount = 0;
            for (int i = 0; i < board.Count; ++i)
            {
                XCount = 0;
                OCount = 0;
                for (int j = 0; j < board.Count; ++j)
                {
                    switch (board[j][i])
                    {
                        case Square.Empty:
                            ++emptyCount;
                            break;
                        case Square.X:
                            ++XCount;
                            break;
                        case Square.O:
                            ++OCount;
                            break;
                    }
                }
                if (XCount == board.Count)
                {
                    return SolverCore.Result.FirstWins;
                }
                if (OCount == board.Count)
                {
                    return SolverCore.Result.SecondWins;
                }
            }
            if (emptyCount == 0)
            {
                result = SolverCore.Result.Draw;
            }
            return result;
        }

        public Position Move(Move move)
        {
            TicTacToeMove ticTacToeMove = (TicTacToeMove)move;
            return new TicTacToeBoard(this, ticTacToeMove);
        }

        override public string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (List<Square> row in board)
            {
                foreach(Square square in row)
                {
                    switch (square)
                    {
                        case Square.Empty:
                            builder.Append('.');
                            break;
                        case Square.X:
                            builder.Append('X');
                            break;
                        case Square.O:
                            builder.Append('O');
                            break;
                    }
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        TicTacToeBoard(TicTacToeBoard position, TicTacToeMove move)
        {
            if (move.Player != position.ToMove)
            {
                throw new System.ArgumentException("Wrong player");
            }
            if (move.Row >= position.board.Count || move.Column >= position.board.Count)
            {
                throw new System.ArgumentException("Wrong Board Size");
            }
            if (position.board[move.Row][move.Column] != Square.Empty)
            {
                throw new System.ArgumentException("Illegal Move");
            }

            switch (position.toMove)
            {
                case Player.First:
                    toMove = Player.Second;
                    break;
                case Player.Second:
                    toMove = Player.First;
                    break;
            }

            List<Square> newRow = new List<Square>(position.board[move.Row]);
            newRow[move.Column] = move.Player == Player.First ? Square.X : Square.O;
            board = new List<List<Square>>(position.board);
            board[move.Row] = newRow;
        }
    }
}
