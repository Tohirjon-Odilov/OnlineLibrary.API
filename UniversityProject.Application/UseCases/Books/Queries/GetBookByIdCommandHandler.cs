using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Queries
{
    public class GetBookByIdCommandHandler(DataContext context)
        : IRequestHandler<GetBookByIdCommand, Book>
    {
        public async Task<Book> Handle(GetBookByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Books
                .FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken: cancellationToken);
            
            if (data == null)
            {
                throw new Exception("Book not found");
            }
            
            return data;
        }
    }
}
