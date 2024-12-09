namespace UniversityProject.Domain.Entities.DTOs;

public class UserBookDto
{
    public virtual ICollection<BookDto>? Books { get; set; }
}