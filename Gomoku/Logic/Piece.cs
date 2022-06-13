using System.Data.SqlTypes;

namespace Gomoku.Logic
{
    public class Piece
    {
        public enum PieceColour
        {
            Red,
            Black
        }

        /// <summary>
        /// The colour of the Piece
        /// </summary>
        public PieceColour Colour { get; set; }

        /// <summary>
        /// The Row index where this 
        /// </summary>
        public int Row { get; set; }
        public int Column { get; set; }

        public Piece(PieceColour colour, int row, int column)
        {
            Colour = colour;
            Row = row;
            Column = column;
        }
    }
}
