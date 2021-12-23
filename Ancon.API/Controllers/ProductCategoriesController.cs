using Ancon.API.Models.ProductCategory.Command.Add;
using Ancon.API.Models.ProductCategory.Command.Delete;
using Ancon.API.Models.ProductCategory.Command.Update;
using Ancon.API.Models.ProductCategory.Queries.Get;
using Ancon.API.Models.ProductCategory.Queries.GetById;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ancon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductCategoriesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            var applicationQuery = _mapper.Map<Application.Handlers.ProductCategory.Queries.Get.GetProductCategoryQuery>
                                   (new GetProductCategoryQuery());

            var productCategories = await _mediator.Send(applicationQuery);
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategoryById([FromRoute] int id)
        {
            var applicationQuery = _mapper.Map<Application.Handlers.ProductCategory.Queries.GetById.GetByIdProductCategoryQuery>
                                   (new GetByIdProductCategoryQuery() { Id = id });

            var productCategory = await _mediator.Send(applicationQuery);

            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductCategory([FromBody] AddProductCategoryCommand command)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.ProductCategory.Commands.Add.AddProductCategoryCommand>(command);

            var id = await _mediator.Send(applicationCommand);

            return CreatedAtAction(nameof(GetProductCategoryById), new { id = id, controller = "ProductCategories" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductCategory([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.ProductCategory.Commands.Update.UpdateProductCategoryCommand>
                                     (new UpdateProductCategoryCommand() { Id = id, document = document });

            await _mediator.Send(applicationCommand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            var applicationCommand = _mapper.Map<Application.Handlers.ProductCategory.Commands.Delete.DeleteProductCategoryCommand>
                         (new DeleteProductCategoryCommand() { Id = id });

            await _mediator.Send(applicationCommand);

            return Ok();
        }
    }
}
