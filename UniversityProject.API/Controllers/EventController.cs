using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Authorses.Commands;
using UniversityProject.Application.UseCases.Authorses.Queries;
using UniversityProject.Application.UseCases.Eventies.Commands;
using UniversityProject.Application.UseCases.Eventies.Queries;
using UniversityProject.Domain.Entities;

namespace UniversityProject.API.Controllers
{
    [SwaggerTag("Eventlar uchun API")]
    [ApiExplorerSettings(GroupName = "Main")]
    [Route("api/event")]
    [ApiController]
    public class EventController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Event qo'shish uchun
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Event qo'shish", Description = "Event ma'lumotlarini Form data ko'rinishida yuboring.")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEvent(CreateEventCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Eventlarni yangilash uchun endpoint
        /// </summary>
        /// <param name="commad"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerOperation(Summary = "Eventni yangilash", Description = "Eventni yangilash uchun form data ko'rinishida yuboring.")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEvent(UpdateEventCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            return Ok(result);
        }
        /// <summary>
        /// Eventlarni o'chirish uchun endpoint
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Eventni o'chirish", Description = "Eventni o'chirish uchun id param sifatida jo'nating.")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEvent(int id, CancellationToken cancellation)
        {
            var data = new DeleteEventCommand
            {
                EventId = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Eventlarni olish uchun endpoint
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Eventlarni olish", Description = "Eventlarni olish uchun hech nima talab qilinmaydi.")]
        [ProducesResponseType(typeof(List<Event>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetALlEvent(CancellationToken cancellation)
        {
            var data = new GetAllEventsCommand();
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Eventni olish", Description = "Eventni olish uchun id param sifatida jo'nating.")]
        [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetEventById(int id, CancellationToken cancellation)
        {
            var data = new GetEventByIdCommand
            {
                EventId = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
    }
}
