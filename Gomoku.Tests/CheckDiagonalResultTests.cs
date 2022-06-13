namespace Gomoku.Tests;

public class CheckDiagonalResultTests
{
    private Board _board;

    [SetUp]
    public void Setup()
    {
        _board = new Board(15, 15, 5);
    }

    [Test]
    public void CheckDiagonalForWin_FiveInARowTopLeft_ReturnWinResult()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black,0, 0));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 1));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 1));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,2, 2));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 2));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,3, 3));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 3));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 4, 4));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 4));

        Assert.That(_board.CheckDiagonalResult(new Piece(Piece.PieceColour.Black, 2, 2)), Is.EqualTo(Board.Result.Win));
    }

    [Test]
    public void CheckDiagonalForWin_FiveInARowBottomRight_ReturnWinResult()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black,10, 10));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,11, 11));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 1));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,12, 12));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 2));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,13, 13));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 3));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 14, 14));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 4));

        Assert.That(_board.CheckDiagonalResult(new Piece(Piece.PieceColour.Black, 12, 12)), Is.EqualTo(Board.Result.Win));
    }

    [Test]
    public void CheckDiagonalForWin_FiveInARowTopRight_ReturnWinResult()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black,0, 14));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 13));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 1));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,2, 12));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 2));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,3, 11));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 3));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 4, 10));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 4));

        Assert.That(_board.CheckDiagonalResult(new Piece(Piece.PieceColour.Black,2, 12)), Is.EqualTo(Board.Result.Win));
    }

    [Test]
    public void CheckDiagonalForWin_FiveInARowBottomLeft_ReturnWinResult()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black,14, 0));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,13, 1));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 1));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,12, 2));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 2));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,11, 3));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 3));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 10, 4));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 4));

        Assert.That(_board.CheckDiagonalResult(new Piece(Piece.PieceColour.Black, 12, 2)), Is.EqualTo(Board.Result.Win));
    }

    [Test]
    public void CheckDiagonalForWin_FiveInARow_ReturnWinResult()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black,7, 2));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,8, 3));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 1));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 9, 4));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 2));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 10, 5));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 3));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,11, 6));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 4));

        Assert.That(_board.CheckDiagonalResult(new Piece(Piece.PieceColour.Black, 9, 4)), Is.EqualTo(Board.Result.Win));
    }
}