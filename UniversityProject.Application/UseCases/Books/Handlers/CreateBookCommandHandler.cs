using MediatR;
using Microsoft.AspNetCore.Hosting;
using UniversityProject.Application.UseCases.Books.Commands;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Books.Handlers
{
    public class CreateBookCommandHandler(DataContext context, IWebHostEnvironment env)
        : IRequestHandler<CreateBookCommand, Book>
    {
        public async Task<Book> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var files = request.Picture;

            if (files == null || files.Length == 0)
                throw new Exception("No file uploaded.");

            var allowedExtensions = new[] 
            { 
                ".jpg", ".jpeg", ".png", ".gif",  // Ommabop rasm formatlari
                ".bmp", ".svg", ".webp",          // Qo'shimcha rasm formatlari
                ".tiff", ".tif",                  // Professional rasm formatlari
                ".ico", ".heic", ".heif",         // Maxsus rasm formatlari
                ".raw", ".cr2", ".nef", ".orf", ".sr2" // RAW kamera formatlari
            };

            var fileExtension = Path.GetExtension(files.FileName).ToLower();

            if (!allowedExtensions.Contains(fileExtension))
                throw new Exception("Invalid file type. Allowed types are .jpg, .jpeg, .png, .gif.");

            var path = Path.Combine(env.WebRootPath, "BookImage");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = $"{Guid.NewGuid()}{fileExtension}";
            var filePath = Path.Combine(path, fileName);

            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await files.CopyToAsync(stream, cancellationToken);
            }
            
            //
            var pdfFile = request.Pdf;

            if (pdfFile == null || pdfFile.Length == 0)
                throw new Exception("No file uploaded.");

            var allowedPdfExtensions = new[] 
            { 
                ".pdf"
            };

            var pdfExtension = Path.GetExtension(pdfFile.FileName).ToLower();

            if (!allowedPdfExtensions.Contains(pdfExtension))
                throw new Exception("Invalid file type. Allowed type is pdf.");

            var pdfFolder = Path.Combine(env.WebRootPath, "BookFile");

            if (!Directory.Exists(pdfFolder))
                Directory.CreateDirectory(pdfFolder);

            var pdfName = $"{Guid.NewGuid()}{pdfExtension}";
            var pdfPath = Path.Combine(pdfFolder, pdfName);

            await using (var stream = new FileStream(pdfPath, FileMode.Create))
            {
                await pdfFile.CopyToAsync(stream, cancellationToken);
            }

            var data = new Book
            {
                Name = request.Name,
                Type = request.Type,
                CategoryId = request.CategoryId,
                AuthorId = request.AuthorId,
                CountryId = request.CountryId,
                Year = request.Year,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Description = request.Description,
                Length = request.Length,
                PictureUrl = "BookImage/"+fileName,
                PdfUrl = "BookFile/"+pdfName,
                Count = request.Count,
                Author = null,
                Country = null
            };

            await context.Books.AddAsync(data, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            
            return data;
        }
    }
}
