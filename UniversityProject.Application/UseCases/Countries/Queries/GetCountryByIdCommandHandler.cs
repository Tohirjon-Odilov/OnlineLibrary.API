using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Countries.Queries
{
    public class GetCountryByIdCommandHandler(DataContext context)
        : IRequestHandler<GetCountryByIdCommand, Country>
    {
        public async Task<Country> 
            Handle(GetCountryByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Countries
                .FirstOrDefaultAsync(x => x.Id == request.CountryId, cancellationToken);
            
            if (data == null)
            {
                throw new Exception("Country not found");
            }
            
            return data;
        }
    }
}
