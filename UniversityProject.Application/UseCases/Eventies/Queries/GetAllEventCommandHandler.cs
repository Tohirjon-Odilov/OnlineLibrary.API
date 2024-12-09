using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Eventies.Queries
{
    public class GetAllEventCommandHandler(DataContext context)
        : IRequestHandler<GetAllEventsCommand, List<Event>>
    {
        public async Task<List<Event>> Handle(GetAllEventsCommand request, CancellationToken cancellationToken)
        {
           var data = await context.Events
               .Where(a=>a.DeletedAt == null)
               .ToListAsync(cancellationToken);
           
            return data;
        }
    }
}
