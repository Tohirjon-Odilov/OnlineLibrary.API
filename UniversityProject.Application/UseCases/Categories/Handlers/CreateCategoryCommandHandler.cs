using MediatR;
using UniversityProject.Application.UseCases.Categories.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Categories.Handlers
{
    public class CreateCategoryCommandHandler(DataContext context)
        : IRequestHandler<CreateCategoryCommand, Category>
    {
        public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var data = new Category()
            {
                Name = request.Name!,
                CreatedAt = DateTime.UtcNow,
                IsInstituteLiterature = request.IsInstituteLecture
            };
            
            await context.Categories.AddAsync(data, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            return data;
        }
    }
}
