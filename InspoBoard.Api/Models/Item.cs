namespace InspoBoard.Api.Models
{
    public class Item
    {
        public int Id { get; set;  }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
    }
}
