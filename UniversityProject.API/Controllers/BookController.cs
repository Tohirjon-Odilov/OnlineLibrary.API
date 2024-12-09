using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Books.Commands;
using UniversityProject.Application.UseCases.Books.Queries;
using UniversityProject.Domain.Entities;

namespace UniversityProject.API.Controllers
{
    [Route("api")]
    [Produces("application/json")]
    [ApiExplorerSettings(GroupName = "Main")]
    [SwaggerTag("Kitoblar bilan ishlash uchun API")]
    [ApiController]
    public class BookController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Kitob qo'shish
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("book")]
        [SwaggerOperation
            (Summary = "Kitob qo'shish",
            Description = "Yangi kitob ma'lumotlarini form data ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateBook([FromForm]CreateBookCommand command, CancellationToken cancellation)
        {
            var result = await mediator.Send(command, cancellation);
            
            return Ok(result);
        }

        /// <summary>
        /// Kitobni yangilash
        /// </summary>
        /// <param name="commad"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut("book")]
        [SwaggerOperation
            (Summary = "Kitobni yangilash", 
            Description = "Kitobni yangilash uchun form data ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateBook([FromForm]UpdateBookCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            
            return Ok(result);
        }

        /// <summary>
        /// Kitobni o'chirish
        /// </summary>
        /// <param name="id">Kitob ID</param>
        /// <param name="cancellation"></param>
        [HttpDelete("book/{id}")]
        [SwaggerOperation
            (Summary = "Kitobni o'chirish",
            Description = "Kitobni o'chirish uchun id param sifatida jo'nating.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteBook([FromRoute]int id, CancellationToken cancellation)
        {
            var data = new DeleteBookCommand
            {
                BookId = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Barcha kitoblarni olish
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="cancellation"></param>
        /// <param name="page"></param>
        /// <returns>PagedResult</returns>
        [HttpGet("books")]
        [SwaggerOperation
            (Summary = "Kitobni olish",
            Description = "Barcha kitoblarni olish uchun hech nima talab qilinmaydi.")
        ]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetALlBook([FromQuery]int page, int limit, CancellationToken cancellation)
        {
            var data = new GetAllBooksCommand
            {
                Limit = limit,
                Page = page
            };
            
            var result = await mediator.Send(data, cancellation);
            
            return Ok(result);
        }
        
        /// <summary>
        /// Kitobni olish
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("book/{id}")]
        [SwaggerOperation
            (Summary = "Kitobni olish",
            Description = "Kitobni olish uchun id param sifatida jo'nating.")
        ]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBookById([FromRoute]int id, CancellationToken cancellation)
        {
            var data = new GetBookByIdCommand
            {
                BookId = id
            };
            
            var result = await mediator.Send(data, cancellation);
            
            return Ok(result);
        }
        
        /// <summary>
        /// Randomli kitoblarni olish
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("book/random")]
        [SwaggerOperation
            (Summary = "Randomli kitobni olish",
            Description = "Randomli kitobni olish uchun hech nima talab qilinmaydi.")
        ]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string),StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBookRandom(CancellationToken cancellation)
        {
            var data = new GetBooksRandomCommand();
            var result = await mediator.Send(data, cancellation);
            
            return Ok(result.Select(a => new
            {
                a.Id,
                a.Name,
                a.Description,
                a.PictureUrl
            }));
        }
    }
}
