using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.DTOs;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Authorses.Queries
{
    public class GetAllAuthorCommandHandler(DataContext context)
        : IRequestHandler<GetAllAuthorCommand, PagedResult<Author>>
    {
        public async Task<PagedResult<Author>> Handle(
            GetAllAuthorCommand request, CancellationToken cancellationToken)
        {
            var dataCount = await context.Authors.CountAsync(cancellationToken);
            
            if (dataCount == 0)
                throw new Exception("Authors not found!");
            
            var data = await context.Authors
                .Skip((request.Page - 1) * request.Limit)
                .Take(request.Limit)
                .ToListAsync(cancellationToken);
            
            return new PagedResult<Author>
            {
                Items = data,
                TotalCount = dataCount
            };
        }
    }
}
