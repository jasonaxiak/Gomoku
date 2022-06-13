using Gomoku.Exceptions;
using Gomoku.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gomoku.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;

        public BoardController(IMemoryCache memoryCache, IConfiguration configuration)
        {
            _memoryCache = memoryCache;
            _configuration = configuration;
        }

        /// <summary>
        /// Generates a new game board to play against
        /// </summary>
        /// <returns>Returns a GUID, to identify the board when making moves</returns>
        // GET: api/<BoardController>
        [HttpGet]
        public IActionResult Get()
        {
            var board = new Board(Constants.BoardLength(_configuration), 
                Constants.BoardWidth(_configuration),
                Constants.ChainLengthToWin(_configuration));

            _memoryCache.Set(board.Id, board);

            return Ok(board.Id);
        }

        // PUT api/<BoardController>/5
        /// <summary>
        /// Place a piece/stone onto the board.
        /// </summary>
        /// <param name="id">Id of the game board to place the piece/stone onto.</param>
        /// <param name="piece">The piece to be place on the game board</param>
        /// <returns>A response indicating if the move resulted in a win or no-result</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Piece piece)
        {
            var board = _memoryCache.Get<Board>(id);

            if (board == null)
                return NotFound("Board not found");

            try
            {
                board.PlacePiece(piece);
            }
            catch (InvalidMoveException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(board.DetermineMoveResult(piece));
        }
    }
}
