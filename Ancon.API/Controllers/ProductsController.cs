using Ancon.API.Models.Product.Command.Delete;
using Ancon.API.Models.Product.Command.Update;
using Ancon.API.Models.Product.Queries.Get;
using Ancon.API.Models.Product.Queries.GetById;
using Ancon.Domain.Interfaces.Product;
using AutoMapper;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var applicationQuery = _mapper.Map<Application.Handlers.Product.Queries.Get.GetProductQuery>(new GetProductQuery());

            var products = await _mediator.Send(applicationQuery);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var applicationQuery = _mapper.Map<Application.Handlers.Product.Queries.GetById.GetByIdProductQuery>
                                   (new GetByIdProductQuery() { Id = id });

            var product = await _mediator.Send(applicationQuery);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Application.Handlers.Product.Commands.Add.AddProductCommand command)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.Product.Commands.Add.AddProductCommand>(command);

            var id = await _mediator.Send(applicationCommand);

            return CreatedAtAction(nameof(GetProductById), new { id = id, controller = "products" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.Product.Commands.Update.UpdateProductCommand>
                                     (new UpdateProductCommand() { Id = id, document = document });

            await _mediator.Send(applicationCommand);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.Product.Commands.Delete.DeleteProductCommand>
                                     (new DeleteProductCommand() { Id = id });

            await _mediator.Send(applicationCommand);

            return Ok();
        }
    }
}
