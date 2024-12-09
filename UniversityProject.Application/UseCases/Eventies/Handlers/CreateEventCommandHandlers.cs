using MediatR;
using Microsoft.AspNetCore.Hosting;
using UniversityProject.Application.UseCases.Eventies.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Eventies.Handlers
{
    public class CreateEventCommandHandlers(DataContext context, IWebHostEnvironment env)
        : IRequestHandler<CreateEventCommand, Event>
    {
        public async Task<Event> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var files = request.Picture;
            
            if (files == null || files.Length == 0)
                throw new ArgumentException("Rasmni yuklash majburiy.", nameof(request.Picture));
            
            var path = Path.Combine(env.WebRootPath, "EventImage");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = $"{Guid.NewGuid()}_EventImage{Path.GetExtension(files.FileName)}";
            var filePath = Path.Combine(path, fileName);
            
            try
            {
                await using var stream = new FileStream(filePath, FileMode.Create);
                await files.CopyToAsync(stream, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Faylni saqlashda xatolik yuz berdi.", ex);
            }
            
            var data = new Event
            {
                Name = request.Name,            
                CreatedAt = DateTime.UtcNow,
                Date = DateTime.UtcNow,
                DeletedAt = null,
                PictureUrl = fileName,
                Description = request.Description,
                ApplicationUserId = request.ApplicationUserId
            };

            await context.Events.AddAsync(data, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            return data;
        }
    }
}
