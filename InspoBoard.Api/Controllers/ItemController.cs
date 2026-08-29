using InspoBoard.Api.Data;
using InspoBoard.Api.Dtos;
using InspoBoard.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InspoBoard.Api.Controllers
{
    [ApiController]
    [Route("api/boards/{boardId}/items")]
    public class ItemController(InspoBoardContext dbContext) : ControllerBase
    {
        private readonly InspoBoardContext _dbContext = dbContext;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ItemDto>>> GetItems(int boardId)
        {
            var board = await _dbContext.Boards.FindAsync(boardId);
            if (board is null)
                return NotFound();

            var items = await _dbContext.Items
                .Where(item => item.BoardId == boardId)
                .Select(item => new ItemDto(
                    item.Id,
                    item.Description ?? string.Empty,
                    item.ImageUrl ?? string.Empty
                ))
                .ToListAsync();

            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItem(int boardId, int id)
        {
            var board = await _dbContext.Boards.FindAsync(boardId);
            if (board is null)
                return NotFound();

            var item = await _dbContext.Items.FindAsync(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItem(int boardId, CreateItemDto dto)
        {
            var board = await _dbContext.Boards.FindAsync(boardId);
            if (board is null)
                return NotFound();

            Item newItem = new()
            {
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                BoardId = boardId
            };

            _dbContext.Items.Add(newItem);
            await _dbContext.SaveChangesAsync();

            ItemDto result = new(
                newItem.Id, 
                newItem.Description ?? string.Empty, 
                newItem.ImageUrl ?? string.Empty
                );

            return CreatedAtAction(nameof(GetItem), new { boardId, id = newItem.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int boardId, int id, UpdateItemDto dto)
        {
            var board = await _dbContext.Boards.FindAsync(boardId);
            if (board is null)
                return NotFound();

            var item = await _dbContext.Items.FindAsync(id);
            if (item == null)
                return NotFound();

            item.Description = dto.Description;
            item.ImageUrl = dto.ImageUrl;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int boardId, int id)
        {
            var board = await _dbContext.Boards.FindAsync(boardId);
            if (board is null)
                return NotFound();

            var item = await _dbContext.Items.FindAsync(id);

            if (item == null)
                return NotFound();

            _dbContext.Items.Remove(item);

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
