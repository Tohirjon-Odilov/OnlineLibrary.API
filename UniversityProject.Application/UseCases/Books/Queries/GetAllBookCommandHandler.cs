using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Queries
{
    public class GetAllBookCommandHandler(DataContext context)
        : IRequestHandler<GetAllBooksCommand, PagedResult<Book>>
    {
        public async Task<PagedResult<Book>> Handle(GetAllBooksCommand request, CancellationToken cancellationToken)
        {
            var dataCount = await context.Books.CountAsync(cancellationToken);
            
            if (dataCount == 0)
                throw new Exception("Books not found!");
            
            var books = await context.Books
                .Skip((request.Page - 1) * request.Limit)
                .Take(request.Limit)
                .ToListAsync(cancellationToken);

            return new PagedResult<Book>
            {
                Items = books,
                TotalCount = dataCount
            };
        }
    }
}
