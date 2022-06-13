
namespace Gomoku.Tests
{
    public class CheckHorizontalResultTests
    {
        private Board _board;
        
        [SetUp]
        public void Setup()
        {
            _board = new Board(15, 15, 5);
        }

        [Test]
        public void CheckHorizontalForWin_FiveInARowToTheRightEnd_ReturnWinResult()
        {
            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 10));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 0));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 11));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 1));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 12));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 2));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 13));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 3));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black, 1, 14));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 4));

            Assert.That(_board.CheckHorizontalResult(new Piece(Piece.PieceColour.Black, 1, 12)),Is.EqualTo(Board.Result.Win));
        }

        [Test]
        public void CheckHorizontalForWin_FiveInARowToTheLeftEnd_ReturnWinResult()
        {
            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 0));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 0));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 1));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 1));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 2));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 2));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black,1, 3));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 3));

            _board.PlacePiece(new Piece(Piece.PieceColour.Black, 1, 4));
            _board.PlacePiece(new Piece(Piece.PieceColour.Red, 14, 4));

            Assert.That(_board.CheckHorizontalResult(new Piece(Piece.PieceColour.Black, 1, 2)), Is.EqualTo(Board.Result.Win));
        }
    }
}