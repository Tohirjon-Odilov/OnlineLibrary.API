using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Domain.Entities.DTOs;

namespace UniversityProject.Application.UseCases.Authorses.Queries
{
    public class GetAllAuthorCommand : IRequest<List<Author>>, IRequest<PagedResult<Author>>
    {
        public int Page { get; set; } = 1;
        public int Limit { get; set; } = 10;
    }
}
