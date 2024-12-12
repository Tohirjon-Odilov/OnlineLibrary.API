using MediatR;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.UserBook.Commands;

public class RemoveBookUserCommand:IRequest<ApplicationUser>
{
    public int BookId { get; set; }
    public int UserId { get; set; }
}