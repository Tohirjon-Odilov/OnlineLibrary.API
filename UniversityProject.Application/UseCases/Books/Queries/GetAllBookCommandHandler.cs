using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Queries
{
    public class GetAllBookCommandHandler(DataContext context)
        : IRequestHandler<GetAllBooksCommand, PagedResult<BookDto>>
    {
        public async Task<PagedResult<BookDto>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            var dataCount = await context.Books.CountAsync(cancellationToken);
            
            if (dataCount == 0)
                throw new Exception("Books not found!");
            
            var books = await context.Books
                .Skip((request.Page - 1) * request.Limit)
                .Take(request.Limit)
                .Select(ub => new BookDto
                {
                    Name = ub.Name,
                    PictureUrl = ub.PictureUrl,
                    PdfUrl = ub.PdfUrl,
                    Id = ub.Id,
                    AuthorName = ub.Author!.FullName,
                    CategoryName = ub.Category!.Name,
                    CreatedAt = ub.CreatedAt,
                    Description = ub.Description,
                    Type = ub.Type,
                    Count = ub.Count,
                    Length = ub.Length,
                    Year = ub.Year,
                    UpdatedAt = ub.UpdatedAt,
                    UserIds = ub.BookUsers!.Select(e => e.User!.Id).ToList()
                }).ToListAsync(cancellationToken);
            

            return new PagedResult<BookDto>
            {
                Items = books,
                TotalCount = dataCount
            };
        }
    }
}
