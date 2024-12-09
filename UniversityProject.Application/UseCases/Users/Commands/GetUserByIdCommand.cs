using MediatR;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Domain.Entities.DTOs;

namespace UniversityProject.Application.UseCases.Users.Commands;

public class GetUserByIdCommand : IRequest<UserDto>
{
    public int Id { get; set; }
}