using MediatR;
using UniversityProject.Domain.Entities;

namespace UniversityProject.Application.UseCases.Countries.Queries
{
    public class GetCountryByIdCommand : IRequest<Country>
    {
        public int CountryId { get; set; }
    }
}
