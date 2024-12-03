using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Eventies.Queries
{
    public class GetEventByIdCommandHandler(DataContext context)
        : IRequestHandler<GetEventByIdCommand, Event>
    {
        public async Task<Event> Handle(GetEventByIdCommand request, CancellationToken cancellationToken)
        {
           var data = await context.Events.FirstOrDefaultAsync(x => x.Id == request.EventId, cancellationToken);
           
            if (data == null)
            {
                throw new Exception("Event not found");
            }
           
            return data;
        }
    }
}
