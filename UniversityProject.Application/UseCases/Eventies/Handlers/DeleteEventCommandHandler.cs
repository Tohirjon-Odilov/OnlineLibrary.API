using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UniversityProject.Application.UseCases.Eventies.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Eventies.Handlers
{
    public class DeleteEventCommandHandler(DataContext context, ILogger<DeleteEventCommandHandler> logger)
        : IRequestHandler<DeleteEventCommand, Event>
    {
        public async Task<Event> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Events.SingleOrDefaultAsync(x => x.Id == request.EventId, cancellationToken);
            if (data == null)
            {
                throw new NotFoundException($"Event with ID {request.EventId} not found.");
            }

            // Soft delete
            data.DeletedAt = DateTime.UtcNow;
            await context.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Event with ID {EventId} has been deleted.", request.EventId);

            return new Event
            {
                Id = data.Id,
                Name = data.Name
            };
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException(string s)
        {
            throw new NotImplementedException();
        }
    }
}