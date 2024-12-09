using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.UserBook.Commands;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.UserBook.Handlers
{
    public class AddBookUserCommandHandler(DataContext context)
        : IRequestHandler<AddBookUserCommand, ApplicationUser>
    {
        public async Task<ApplicationUser> Handle(
            AddBookUserCommand request, CancellationToken cancellationToken)
        {
            var userBooks = await context.UserBooks
                .FirstOrDefaultAsync(a => a.ApplicationUserId 
                    == request.UserId && a.BookId == request.BookId, cancellationToken);
            
            if(userBooks != null)
            {
                throw new Exception("User already has this book");
            }
            
            // Foydalanuvchi va kitobni yaratish    
            var user = await context.Users
                .FirstOrDefaultAsync(a => a.Id == request.UserId, cancellationToken);
            var book = await context.Books
                .FirstOrDefaultAsync(b => b.Id == request.BookId,cancellationToken);

            if (user == null || book == null)
            {
                throw new Exception("User or book not found");
            }

            // UserBook bog‘lanishini yaratish
            var userBook = new Domain.Entities.UserBook()
            {
                BookId = book.Id,
                ApplicationUserId =  user.Id
            };

            context.UserBooks.Add(userBook);
            await context.SaveChangesAsync(cancellationToken);

            return new ApplicationUser();
        }
    }
}