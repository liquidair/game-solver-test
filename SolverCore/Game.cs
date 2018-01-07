using System.Collections.Generic;

namespace SolverCore
{
    public enum Player
    {
        First,
        Second
    }

    public enum Result
    {
        None,
        FirstWins,
        SecondWins,
        Draw
    }

    public interface Move
    {
    }

    public interface Position
    {
        Player ToMove { get; }

        List<Move> GetMoves();

        Position Move(Move move);

        Result Result();
    }

    public interface Game
    {
        Position Start { get; }
    }
}
