namespace Gomoku.Tests;

public class CheckVerticalResultTests
{
    private Board _board;

    [SetUp]
    public void Setup()
    {
        _board = new Board(15, 15, 5);
    }

    [Test]
    public void CheckVerticalForWin_FiveInARowToTheRightEnd_ReturnWinResult()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 10, 0));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red,11, 1));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,12, 0));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 13, 1));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 14, 0));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 10, 2));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 11, 0));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 12, 3));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 13, 0));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 4));

        Assert.That(_board.CheckVerticalResult(new Piece(Piece.PieceColour.Black,12, 0)), Is.EqualTo(Board.Result.Win));
    }

    [Test]
    public void CheckVerticalForWin_FiveInARowToTheLeftEnd_ReturnWinResult()
    {

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 7));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 1, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 2, 7));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 3, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 4, 7));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 7));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 2, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,3, 7));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 4, 0));

        Assert.That(_board.CheckVerticalResult(new Piece(Piece.PieceColour.Black, 2, 7)), Is.EqualTo(Board.Result.Win));
    }

    [Test]
    public void CheckVerticalForWin_FiveInARowInTheMiddle_ReturnWinResult()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black,5, 14));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red,6, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black,7, 14));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 8, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 9, 14));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 5, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 6, 14));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 7, 0));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 8, 14));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 9, 0));

        Assert.That(_board.CheckVerticalResult(new Piece(Piece.PieceColour.Black, 7, 14)), Is.EqualTo(Board.Result.Win));
    }
}