using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using UniversityProject.Application.UseCases.Categories.Commands;
using UniversityProject.Application.UseCases.Categories.Queries;

namespace UniversityProject.API.Controllers
{
    [Route("api")]
    [ApiExplorerSettings(GroupName = "Main")]
    [Produces("application/json")]
    [SwaggerTag("Kategoriyalar uchun API")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        ///  Kategoriya qo'shish
        /// </summary>
        /// <param name="categoryName"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPost("category/{categoryName}")]
        [SwaggerOperation(
            Summary = "Kategoriya qo'shish",
            Description = "Kategoriya ma'lumotlarini JSON ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateCategory(string categoryName, CancellationToken cancellation)
        {
            var result = await mediator.Send(categoryName, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Kategoriya yangilash
        /// </summary>
        /// <param name="commad"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpPut("category")]
        [SwaggerOperation(
            Summary = "Kategoriya yangilash",
            Description = "Kategoriya ma'lumotlarini JSON ko'rinishida yuboring.")
        ]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand commad, CancellationToken cancellation)
        {
            var result = await mediator.Send(commad, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Kategoriya o'chirish
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns>O'chirilgan data qaytadi</returns>
        [HttpDelete("category/{id}")]
        [SwaggerOperation(Summary = "Kategoriyani o'chirish", Description = "Kategoriya o'chirish uchun id param sifatida jo'nating.")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteCategory(int id, CancellationToken cancellation)
        {
            var data = new DeleteCategoryCommand
            {
                CategoryId = (id)
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }

        /// <summary>
        /// Barcha kategoriyalarni olish
        /// </summary>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("categories")]
        [SwaggerOperation(Summary = "Kategoriyalarni olish", Description = "Kategoriyalarni olish uchun hech nima talab qilinmaydi.")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetALlCategory(CancellationToken cancellation)
        {
            var data = new GetAllCategoryCommand();
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
        
        /// <summary>
        /// Kategoriyani id orqali olish
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellation"></param>
        /// <returns></returns>
        [HttpGet("category/{id}")]
        [SwaggerOperation(Summary = "Kategoriyani olish", Description = "Kategoriyani olish uchun id param sifatida jo'nating.")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCategoryById(int id, CancellationToken cancellation)
        {
            var data = new GetCategoryByIdCommand
            {
                CategoryId = id
            };
            
            var result = await mediator.Send(data, cancellation);
            return Ok(result);
        }
    }
}
