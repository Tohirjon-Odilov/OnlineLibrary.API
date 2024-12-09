namespace UniversityProject.Domain.Entities.DTOs;

public class UserDto
{
    public int Id {  get; set; }
    public string? FullName { get; set; }    
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public DateTime CreatedAt {  get; set; }
    public string? PictureUrl { get; set; }
        
    public ICollection<Report>? Report { get; set; }
    public string? CountryName { get; set; }
    public List<BookDto>? UserBooks { get; set; }
}