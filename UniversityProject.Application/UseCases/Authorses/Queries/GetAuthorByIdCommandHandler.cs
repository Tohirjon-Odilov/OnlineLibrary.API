using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Authorses.Queries
{
    public class GetAuthorByIdCommandHandler(DataContext context)
        : IRequestHandler<GetAuthorByIdCommand, Author>
    {
        public async Task<Author> Handle(GetAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Authors
                .FirstOrDefaultAsync(a => a.Id == request.AuthorId, cancellationToken);
            
            if (data is null)
            {
                throw new Exception("Author not found");
            }
            
            return data;
        }
    }
}
