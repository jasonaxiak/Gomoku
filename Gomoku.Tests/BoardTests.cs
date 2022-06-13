
namespace Gomoku.Tests;

[TestFixture]
public class BoardTests
{
    private Board _board;

    [SetUp]
    public void Setup()
    {
        _board = new Board(15, 15, 5);
    }


    [Test]
    public void PlacePiece_OutsideOfBoard_ThrowsInvalidMoveException()
    {
        var piece = new Piece(Piece.PieceColour.Black, 15, 15);

        var ex = Assert.Throws<InvalidMoveException>(() =>_board.PlacePiece(piece));
        Assert.That(ex?.InvalidMoveType, Is.EqualTo(InvalidMoveException.InvalidMoveTypes.OutsideOfBoard));
    }

    [Test]
    public void PlacePiece_OnAlreadyOccupiedPosition_ThrowsInvalidMoveException()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 0));

        var ex = Assert.Throws<InvalidMoveException>(() => _board.PlacePiece(new Piece(Piece.PieceColour.Red, 0, 0)));
        Assert.That(ex?.InvalidMoveType, Is.EqualTo(InvalidMoveException.InvalidMoveTypes.PlaceOccupied));
    }

    [Test]
    public void PlacePiece_WhenOutOfTurn_ThrowsInvalidMoveException()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 0));

        var ex = Assert.Throws<InvalidMoveException>(() => _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 1)));
        Assert.That(ex?.InvalidMoveType, Is.EqualTo(InvalidMoveException.InvalidMoveTypes.OutOfTurn));
    }

    [Test]
    public void PlacePiece_WhenFiveInARow_ReturnWin()
    {
        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 1));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 1, 5));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 2));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 1, 4));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 3));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 1, 2));

        _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 4));
        _board.PlacePiece(new Piece(Piece.PieceColour.Red, 1, 1));

        var result = _board.PlacePiece(new Piece(Piece.PieceColour.Black, 0, 5));

        Assert.That(result, Is.EqualTo(Board.Result.Win));
    }
}