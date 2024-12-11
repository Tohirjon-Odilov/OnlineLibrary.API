using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Queries
{
    public class GetUserByIdCommandHandler(DataContext context)
        : IRequestHandler<GetUserByIdCommand, UserDto>
    {
        public Task<UserDto> Handle
            (GetUserByIdCommand request, CancellationToken cancellationToken)
        {
            var user = context.Users
                .Include(u => u.UserBooks)!
                .ThenInclude(ub => ub.Book).ThenInclude(book => book!.Author)
                .Include(applicationUser => applicationUser.UserBooks)!
                .ThenInclude(userBook => userBook.Book)
                .ThenInclude(book => book!.Category)
                .Include(a => a.Report)
                .Include(a => a.Country)
                .FirstOrDefault(a=> a.Id == request.Id);
            
            if (user == null)
                throw new Exception("Not found!");

            if (user.UserBooks != null)
            {
                List<BookDto> books =
                    user.UserBooks.Select(ub => new BookDto
                    {
                        Name = ub.Book!.Name,
                        PictureUrl = ub.Book.PictureUrl,
                        Id = ub.Book.Id,
                        AuthorName = ub.Book.Author!.FullName,
                        CategoryName = ub.Book.Category!.Name,
                        CreatedAt = ub.Book.CreatedAt,
                        Description = ub.Book.Description,
                        Type = ub.Book.Type,
                        Count = ub.Book.Count,
                        Length = ub.Book.Length,
                        Year = ub.Book.Year,
                        UpdatedAt = ub.Book.UpdatedAt
                    }).ToList();

                var newData = new UserDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    PhoneNumber = user.PhoneNumber,
                    PictureUrl = user.PictureUrl,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    Report = user.Report,
                    CountryName = user.Country.Name,
                    UserBooks = books
                };

                return Task.FromResult(newData);
            }

            return Task.FromResult(new UserDto());
        }
    }
}
