namespace InspoBoard.Api.Dtos
{
    public record class ItemDto(
        int Id,
        string Title,
        string Description,
        string ImageUrl
        );
}
