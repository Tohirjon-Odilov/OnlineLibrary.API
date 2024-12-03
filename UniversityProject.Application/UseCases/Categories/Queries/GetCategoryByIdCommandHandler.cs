using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Categories.Queries
{
    public class GetCategoryByIdCommandHandler(DataContext context)
        : IRequestHandler<GetCategoryByIdCommand, Category>
    {
        private readonly DataContext _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<Category> Handle(GetCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _context.Categories
                .FirstOrDefaultAsync(a => a.Id == request.CategoryId, cancellationToken);
            
            if (data == null)
            {
                throw new Exception("Category not found!");
            }

            return data;
        }
    }
}