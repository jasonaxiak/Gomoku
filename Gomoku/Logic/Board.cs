using Gomoku.Exceptions;

namespace Gomoku.Logic
{
    public class Board
    {
        public Guid Id { get; }

        private readonly Piece[,] _board;
        private readonly int _requiredChainLength;
        private readonly Stack<Piece> _turnHistory = new();

        public enum Result
        {
            Win,
            NoResult
        }

        /// <summary>
        /// Creates a new game board and assigns a guid to identify the board
        /// </summary>
        /// <param name="numberOfRows">The number of rows down the board</param>
        /// <param name="numberOfColumns">The number of columns across the board</param>
        /// <param name="requiredChainLengthToWin">The number of sequential pieces (size of chain), required to win</param>
        public Board(int numberOfRows, int numberOfColumns, int requiredChainLengthToWin)
        {
            Id = Guid.NewGuid();

            _board = new Piece[numberOfRows, numberOfColumns];
            _requiredChainLength = requiredChainLengthToWin;
        }

        /// <summary>
        /// Checks to see a piece exists at the provided co-ordinates
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="column">The column index</param>
        /// <returns>True if the space is unoccupied, otherwise false</returns>
        private bool IsPositionEmpty(int row, int column)
        {
            return _board[row, column] == null;
        }

        /// <summary>
        /// Determines if the current piece and the piece next to, are the matching colour
        /// </summary>
        /// <param name="currentPiece">The current piece to compare with</param>
        /// <param name="nextPiece">The piece next to, to compare to</param>
        /// <returns>True if the two pieces match, otherwise false</returns>
        private bool IsMatch(Piece currentPiece, Piece nextPiece)
        {
            return nextPiece != null && nextPiece.Colour == currentPiece.Colour;
        }

        /// <summary>
        /// Determines if the winning condition has been meet
        /// </summary>
        /// <param name="currentChainCount">The current number of sequential pieces, of the same colour, are in the chain</param>
        /// <returns>True if the winning condition is met, otherwise false</returns>
        private bool IsWin(int currentChainCount)
        {
            return currentChainCount >= _requiredChainLength;
        }

        /// <summary>
        /// Places a piece on the board
        /// </summary>
        /// <param name="piece">The piece to place on the board</param>
        /// <returns>A result determining the outcome of placing the piece on the board</returns>
        /// <exception cref="InvalidMoveException">Thrown when placing a piece on the board, results in an illegal move</exception>
        public Result PlacePiece(Piece piece)
        {
            var row = piece.Row;
            var column = piece.Column;

            //check if row and column are valid position on the board
            if (row >= _board.GetLength(0) || column >= _board.GetLength(1))
                throw new InvalidMoveException($"Row {row}, column {column}, is not a valid position on the board", InvalidMoveException.InvalidMoveTypes.OutsideOfBoard);

            //Check if position does not have a piece already
            if (!IsPositionEmpty(row, column))
                throw new InvalidMoveException($"There is already a piece at row {row}, column {column}", InvalidMoveException.InvalidMoveTypes.PlaceOccupied);

            //Check for correct turn
            if (_turnHistory.Count > 0 &&_turnHistory.Peek().Colour == piece.Colour)
                throw new InvalidMoveException($"A {piece.Colour} piece was previously placed", InvalidMoveException.InvalidMoveTypes.OutOfTurn);
            _turnHistory.Push(piece);

            //Add piece to the board
            _board[row, column] = piece;

            return DetermineMoveResult(piece);
        }

        /// <summary>
        /// Combines all the possible winning combinations, to determine if a winning outcome or no outcome has been reached
        /// </summary>
        /// <param name="currentPiece">The last piece to be placed on the board</param>
        /// <returns>Result.Win, when at least one winning combination has been met, otherwise Result.NoResult</returns>
        public Result DetermineMoveResult(Piece currentPiece)
        {
            if (CheckVerticalResult(currentPiece) == Result.Win)
                return Result.Win;
            
            if(CheckHorizontalResult(currentPiece) == Result.Win)
                return Result.Win;

            return CheckDiagonalResult(currentPiece) == Result.Win ? Result.Win : Result.NoResult;
        }

        /// <summary>
        /// Checks for a winning condition in a possible vertical chain
        /// </summary>
        /// <param name="currentPiece">The current piece, to check for a chain from</param>
        /// <returns>Result to indicate if the vertical chain results in a </returns>
        public Result CheckVerticalResult(Piece currentPiece)
        {
            var currentChainCount = 1;
            var row = currentPiece.Row;
            var column = currentPiece.Column;

            //traverse up
            for (var i = row - 1; i >= 0; i--)
            {
                if (IsMatch(currentPiece, _board[i, column]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }

            //No need to continue if we can determine the result
            if(IsWin(currentChainCount))
                return Result.Win;

            //Traverse down
            for (var i = row + 1; i < _board.GetLength(0); i++)
            {
                if (IsMatch(currentPiece, _board[i, column]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }

            return currentChainCount >= _requiredChainLength ? Result.Win : Result.NoResult;
        }

        /// <summary>
        /// Checks for a winning condition in a possible horizontal chain
        /// </summary>
        /// <param name="currentPiece">The current piece, to check for a chain from</param>
        /// <returns>Result to indicate if the vertical chain results in a </returns>
        public Result CheckHorizontalResult(Piece currentPiece)
        {
            var currentChainCount = 1;
            var row = currentPiece.Row;
            var column = currentPiece.Column;

            //traverse to the left
            for (var i = column - 1; i >= 0; i--)
            {
                if (IsMatch(currentPiece, _board[row, i]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }

            //No need to continue if we can determine the result
            if (IsWin(currentChainCount))
                return Result.Win;

            //Traverse to the right
            for (var i = column + 1; i < _board.GetLength(1); i++)
            {
                if (IsMatch(currentPiece, _board[row, i]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }
            
            return currentChainCount >= _requiredChainLength ? Result.Win : Result.NoResult;
        }

        /// <summary>
        /// Checks for a winning condition in a possible diagonal chain
        /// </summary>
        /// <param name="currentPiece">The current piece, to check for a chain from</param>
        /// <returns>Result to indicate if the vertical chain results in a </returns>
        public Result CheckDiagonalResult(Piece currentPiece)
        {
            var currentChainCount = 1;
            var row = currentPiece.Row;
            var column = currentPiece.Column;

            //traverse left and up 
            for (int i = row - 1, j = column-1; i >= 0 && j >= 0; i--, j--)
            {
                if (IsMatch(currentPiece, _board[i, j]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }

            //No need to continue if we can determine the result
            if (IsWin(currentChainCount))
                return Result.Win;

            //traverse right and up
            for (int i = row - 1, j = column + 1; i >= 0 && j < _board.GetLength(1); i--, j++)
            {
                if (IsMatch(currentPiece, _board[i, j]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }

            //No need to continue if we can determine the result
            if (IsWin(currentChainCount))
                return Result.Win;

            //Traverse right and down
            for (int i = row + 1, j = column + 1; i < _board.GetLength(0) && j < _board.GetLength(1); i++, j++)
            {
                if (IsMatch(currentPiece, _board[i, j]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }

            //No need to continue if we can determine the result
            if (IsWin(currentChainCount))
                return Result.Win;

            //Traverse left and down
            for (int i = row + 1, j = column - 1; i < _board.GetLength(0) && j >= 0; i++, j--)
            {
                if (IsMatch(currentPiece, _board[i, j]) && currentChainCount < _requiredChainLength)
                    currentChainCount++;
                else
                    break; //Chain broken stop traversing
            }

            return currentChainCount >= _requiredChainLength ? Result.Win : Result.NoResult;
        }
    }
}
