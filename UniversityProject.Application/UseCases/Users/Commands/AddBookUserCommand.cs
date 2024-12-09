using MediatR;
using UniversityProject.Domain.Entities.Auth;

namespace UniversityProject.Application.UseCases.Users.Commands;

public class AddBookUserCommand:IRequest<ApplicationUser>
{
    public int BookId { get; set; }
    public int UserId { get; set; }
}