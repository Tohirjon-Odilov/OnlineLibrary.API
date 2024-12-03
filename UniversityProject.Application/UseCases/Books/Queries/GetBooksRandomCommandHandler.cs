using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Queries
{
    public class GetBooksRandomCommandHandler(DataContext context)
        : IRequestHandler<GetBooksRandomCommand, List<Book>>
    {
        public async Task<List<Book>> Handle(GetBooksRandomCommand request, CancellationToken cancellationToken)
        {
            // only name id and description
            var data = await context.Books
                .OrderBy(x => EF.Functions.Random())
                .ToListAsync(cancellationToken);
            
            if (data == null)
            {
                throw new Exception("Book not found");
            }
            
            return data;
        }
    }
}
