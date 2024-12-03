using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityProject.Domain.Entities;
using UniversityProject.Infrastructure.Persistance;

namespace UniversityProject.Application.UseCases.Reports.Queries
{
    public class GetReportByIdCommandHandler(DataContext context)
        : IRequestHandler<GetReportByIdCommand, Report>
    {
        public async Task<Report> Handle(GetReportByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await context.Reports.
                FirstOrDefaultAsync(x => x.Id == request.ReportId, cancellationToken);
            
            if (data == null)
            {
                throw new Exception("Report not found");
            }
            
            return data;
        }
    }
}
