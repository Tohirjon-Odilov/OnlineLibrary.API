using MediatR;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.UserBook.Commands;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.UserBook.Handlers
{
    public class RemoveBookUserCommandHandler(DataContext context)
        : IRequestHandler<RemoveBookUserCommand, ApplicationUser>
    {
        public async Task<ApplicationUser> Handle(
            RemoveBookUserCommand request, CancellationToken cancellationToken)
        {
            var userBooks = await context.UserBooks
                .FirstOrDefaultAsync(a => a.ApplicationUserId 
                    == request.UserId && a.BookId == request.BookId, cancellationToken);
            
            if(userBooks is null)
            {
                throw new Exception("Not found!");
            }
            
            // // Foydalanuvchi va kitobni yaratish    
            // var user = await context.Users
            //     .FirstOrDefaultAsync(a => a.Id == request.UserId, cancellationToken);
            // var book = await context.Books
            //     .FirstOrDefaultAsync(b => b.Id == request.BookId,cancellationToken);
            //
            // if (user == null || book == null)
            // {
            //     throw new Exception("User or book not found");
            // }

            // // UserBook bog‘lanishini yaratish
            // var userBook = new Domain.Entities.UserBook()
            // {
            //     BookId = book.Id,
            //     ApplicationUserId =  user.Id
            // };
            

            context.UserBooks.Remove(userBooks);
            await context.SaveChangesAsync(cancellationToken);

            return new ApplicationUser();
        }
    }
}