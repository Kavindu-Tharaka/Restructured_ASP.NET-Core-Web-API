using Ancon.Domain.Interfaces.Product;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ancon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await mediator.Send(new Application.Handlers.Product.Queries.Get.GetProductQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await mediator.Send(new Application.Handlers.Product.Queries.GetById.GetByIdProductQuery() { Id = id });

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Application.Handlers.Product.Commands.Add.AddProductCommand command)
        {
            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetProductById), new { id = id, controller = "products" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            await mediator.Send(new Application.Handlers.Product.Commands.Update.UpdateProductCommand() { Id = id, document = document });

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await mediator.Send(new Application.Handlers.Product.Commands.Delete.DeleteProductCommand() { Id = id });

            return Ok();
        }
    }
}
