namespace Gomoku.Exceptions;

public class PieceException : Exception
{
    public PieceException(string message) : base(message) { }

    public PieceException(string message, Exception innerException) : base(message, innerException) { }
}