using TicTacToe;
using SolverCore;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameSolverTest
{
    [TestClass]
    public class TicTacToeTest
    {
        [TestMethod]
        public void TestEmptyBoardMoves()
        {
            TicTacToeBoard board = new TicTacToeBoard(3);
            Assert.AreEqual(Player.First, board.ToMove);
            Assert.AreEqual(Result.None, board.Result());
            List<Move> moves = board.GetMoves();
            Assert.AreEqual(9, moves.Count);

            foreach (Move move in moves)
            {
                Position newPosition = board.Move(move);
                Assert.AreEqual(Player.Second, newPosition.ToMove);
                Assert.AreEqual(Result.None, newPosition.Result());
                moves = newPosition.GetMoves();
                Assert.AreEqual(8, moves.Count);
            }
        }

        [TestMethod]
        public void TestWinColumn()
        {
            TicTacToeBoard board = new TicTacToeBoard(3);
            Debug.Write(board);
            Debug.WriteLine("---");

            TicTacToeMove move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 1 };
            Position position = board.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 1, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 0, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 1, Column = 2 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 2, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.FirstWins, position.Result());
            Debug.WriteLine("---");
        }

        [TestMethod]
        public void TestWinRow()
        {
            TicTacToeBoard board = new TicTacToeBoard(3);
            Debug.Write(board);
            Debug.WriteLine("---");

            TicTacToeMove move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 1 };
            Position position = board.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 0, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 2, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 2 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.FirstWins, position.Result());
            Debug.WriteLine("---");
        }

        [TestMethod]
        public void TestWinDiagonal()
        {
            TicTacToeBoard board = new TicTacToeBoard(3);
            Debug.Write(board);
            Debug.WriteLine("---");

            TicTacToeMove move = new TicTacToeMove { Player = Player.First, Row = 2, Column = 2 };
            Position position = board.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 0, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 2, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 0, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.FirstWins, position.Result());
            Debug.WriteLine("---");
        }

        [TestMethod]
        public void TestWinDiagonal2()
        {
            TicTacToeBoard board = new TicTacToeBoard(3);
            Debug.Write(board);
            Debug.WriteLine("---");

            TicTacToeMove move = new TicTacToeMove { Player = Player.First, Row = 0, Column = 2 };
            Position position = board.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 0, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 2, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 2, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.FirstWins, position.Result());
            Debug.WriteLine("---");
        }

        [TestMethod]
        public void TestSecondWins()
        {
            TicTacToeBoard board = new TicTacToeBoard(3);
            Debug.Write(board);
            Debug.WriteLine("---");

            TicTacToeMove move = new TicTacToeMove { Player = Player.First, Row = 0, Column = 2 };
            Position position = board.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 2, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 2, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 0, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 0, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 2, Column = 2 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 1, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.SecondWins, position.Result());
            Debug.WriteLine("---");
        }

        [TestMethod]
        public void TestDraw()
        {
            TicTacToeBoard board = new TicTacToeBoard(3);
            Debug.Write(board);
            Debug.WriteLine("---");

            TicTacToeMove move = new TicTacToeMove { Player = Player.First, Row = 0, Column = 2 };
            Position position = board.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 2, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 2, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 0, Column = 1 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 0, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 2, Column = 2 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.Second, Row = 1, Column = 2 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.First, position.ToMove);
            Assert.AreEqual(Result.None, position.Result());
            Debug.WriteLine("---");

            move = new TicTacToeMove { Player = Player.First, Row = 1, Column = 0 };
            position = position.Move(move);
            Debug.Write(position);
            Assert.AreEqual(Player.Second, position.ToMove);
            Assert.AreEqual(Result.Draw, position.Result());
            Debug.WriteLine("---");
        }
    }
}
