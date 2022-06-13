namespace Gomoku.Exceptions;

public class InvalidMoveException : Exception
{
    public enum InvalidMoveTypes
    {
        OutsideOfBoard,
        OutOfTurn,
        PlaceOccupied
    }

    public InvalidMoveTypes InvalidMoveType { get; set; }

    public InvalidMoveException() : base() { }

    public InvalidMoveException(string message, InvalidMoveTypes invalidMoveType) : base(message)
    {
        InvalidMoveType = invalidMoveType;
    }

    public InvalidMoveException(string message, Exception innerException) : base(message, innerException) { }
}