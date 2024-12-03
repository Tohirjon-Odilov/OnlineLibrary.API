using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Authorses.Queries;
using UniversityProject.Application.UseCases.Reports.Commands;
using UniversityProject.Application.UseCases.Reports.Queries;
using UniversityProject.Domain.Entities;

namespace UniversityProject.API.Controllers
{
    [SwaggerTag("Reportlarni boshqarish uchun endpointlar")]
    [ApiExplorerSettings(GroupName = "Main")]
    [Route("api/report")]
    [ApiController]
    public class ReportsController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Report qo'shish uchun endpoint
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        /// <returns>Report modelini o'zi qaytadi</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Report qo'shish", Description = "Report ma'lumotlarini Form data ko'rinishida yuboring.")]
        [ProducesResponseType(typeof(Report), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateReport(CreateReportsCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Reportni yangilash uchun endpoint
        /// </summary>
        /// <param name="commad"></param>
        /// <param name="cancellation"></param>
        /// <returns>Report modeli qaytadi</returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Reportni yangilash", Description = "Reportni yangilash uchun form data ko'rinishida yuboring.")]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateReport(UpdateReportsCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            return Ok(result);
        }
        
        /// <summary>
        /// Reportlarni o'chirish uchun endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns>Report model qaytadi</returns>
        [HttpDelete("id")]
        [SwaggerOperation(Summary = "Reportni o'chirish", Description = "Reportni o'chirish uchun id param sifatida jo'nating.")]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteReport(int id, CancellationToken cancellation)
        {
            var data = new DeleteReportsCommand
            {
                ReportId = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Barcha reportlarni olish
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns>Returnda List Report qaytadi</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Reportlarni olish", Description = "Reportlarni olish uchun hech nima talab qilinmaydi.")]
        [ProducesResponseType(typeof(List<Report>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetALlReport(CancellationToken cancellation)
        {
            var data = new GetAllReportsCommand();
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Reportni olish", Description = "Reportni olish uchun id param sifatida jo'nating.")]
        [ProducesResponseType(typeof(Report), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetReportById(int id, CancellationToken cancellation)
        {
            var data = new GetReportByIdCommand
            {
                ReportId = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
    }
}
