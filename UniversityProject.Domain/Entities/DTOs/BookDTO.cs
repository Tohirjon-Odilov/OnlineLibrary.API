namespace UniversityProject.Domain.Entities.DTOs;

public class BookDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int? Year { get; set; }
    public string? Description { get; set; }
    public int? Length { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? PictureUrl { get; set; }
    public int? Count { get; set; }
    public string? CategoryName { get; set; }
    public string? AuthorName { get; set; }
}