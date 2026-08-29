using InspoBoard.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace InspoBoard.Api.Data
{
    public class InspoBoardContext(DbContextOptions<InspoBoardContext> options) : DbContext(options)
    {
        public DbSet<Board> Boards => Set<Board>();
        public DbSet<Item> Items=> Set<Item>();
    }
}
