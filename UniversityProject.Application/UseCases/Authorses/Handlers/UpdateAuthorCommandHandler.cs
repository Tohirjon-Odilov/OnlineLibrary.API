using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Authorses.Handlers
{
    public class UpdateAuthorCommandHandler(DataContext context, IWebHostEnvironment env)
        : IRequestHandler<UpdateAuthorCommand, Author>
    {
        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var email = await context.Authors
                .FirstOrDefaultAsync(x => x.Id == request.AuthorId, cancellationToken);
            
            var files = request.Picture;
            var path = Path.Combine(env.WebRootPath, "AuthorImage");
            var fileName = "";

            if (files != null)
            {
                if (!string.IsNullOrEmpty(email?.PictureUrl))
                {
                    var oldFilePath = Path.Combine(path , email.PictureUrl);
                    if(File.Exists(oldFilePath))
                    {
                        File.Delete(oldFilePath);
                    }
                }
                
                fileName = Guid.NewGuid() + Path.GetExtension(files.FileName);
                var filePath = Path.Combine(path, fileName);
                await using var stream =new FileStream(filePath , FileMode.Create);
                await stream.CopyToAsync(stream, cancellationToken);
            }

            var data = new Author()
            {
                FullName = request.FullName,
                BirthDate = request.Year,
                BioWikipediya = request.BioWikipediya,
                CreatedAt = DateTime.UtcNow,
                DeletedAt = null,
                PictureUrl = fileName,
                CountryId = request.CountryId
            };
            
            context.Authors.Update(data);
            await context.SaveChangesAsync(cancellationToken);

            if (email != null) return data;
            return data;
        }
    }
}
