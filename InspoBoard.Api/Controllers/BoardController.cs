using InspoBoard.Api.Data;
using InspoBoard.Api.Dtos;
using InspoBoard.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspoBoard.Api.Controllers
{
    [ApiController]
    [Route("api/boards")]
    public class BoardController(InspoBoardContext dbContext) : ControllerBase
    {
        private readonly InspoBoardContext _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardDto>>> GetBoards()
        {
            var boards = await _dbContext.Boards.ToListAsync();
            return Ok(boards);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardDto>> GetBoard(int id)
        {
            var board = await _dbContext.Boards.FindAsync(id);

            if (board == null)
                return NotFound();

            return Ok(board);
        }

        [HttpPost]
        public async Task<ActionResult<BoardDto>> CreateBoard(CreateBoardDto dto)
        {
            Board newBoard = new()
            {
                Name = dto.Name,
            };

            _dbContext.Boards.Add(newBoard);
            await _dbContext.SaveChangesAsync();

            BoardDto result = new(newBoard.Id, newBoard.Name);

            return CreatedAtAction(nameof(GetBoard), new { id = newBoard.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBoard(int id, UpdateBoardDto dto)
        {
            var board = await _dbContext.Boards.FindAsync(id);

            if (board == null)
                return NotFound();

            board.Name = dto.Name;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var board = await _dbContext.Boards.FindAsync(id);

            if (board == null)
                return NotFound();

            _dbContext.Boards.Remove(board);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
