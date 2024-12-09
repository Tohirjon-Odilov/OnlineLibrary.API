using MediatR;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.DTOs;

namespace UniversityProject.Application.UseCases.Books.Queries
{
    public class GetAllBooksCommand : IRequest<PagedResult<Book>>
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}
