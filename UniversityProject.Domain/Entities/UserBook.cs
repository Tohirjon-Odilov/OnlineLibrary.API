using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Domain.Entities;

public class UserBook
{
    public int ApplicationUserId { get; set; }
    public ApplicationUser? User { get; set; }

    public int BookId { get; set; }
    public Book? Book { get; set; }
}