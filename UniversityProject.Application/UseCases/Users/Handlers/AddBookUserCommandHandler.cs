using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using UniversityProject.Application.UseCases.Users.Commands;
using UniversityProject.Domain.Entities.Auth;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Users.Handlers;

public class AddBookUserCommandHandler(
    DataContext context, IWebHostEnvironment env)
: IRequestHandler<AddBookUserCommand, ApplicationUser>
{
    public async Task<ApplicationUser> Handle(
        AddBookUserCommand request, CancellationToken cancellationToken)
    {
        var response = new ApplicationUser();
        
        var user = await context.Users
            .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
        
        var book = await context.Books
            .FirstOrDefaultAsync(x => x.Id == request.BookId, cancellationToken);
        
        if (user == null || book == null)
            throw new Exception("Not found!");
        
        // book.ApplicationUser = user.;
        user.Books.Add(book);
        
        await context.SaveChangesAsync(cancellationToken);

        return response;
    }
}