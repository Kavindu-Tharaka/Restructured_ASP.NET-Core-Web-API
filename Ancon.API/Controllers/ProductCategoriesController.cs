using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ancon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductCategoriesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProductCategories()
        {
            //var productCategories = await productCategoriesRepository.GetAllProductCategories();

            var productCategories = await mediator.Send(new Application.Handlers.ProductCategory.Queries.Get.GetProductCategoryQuery());
            return Ok(productCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductCategoryById([FromRoute] int id)
        {
            //var productCategory = await productCategoriesRepository.GetProductCategoryById(id);

            var productCategory = await mediator.Send(new Application.Handlers.ProductCategory.Queries.GetById.GetByIdProductCategoryQuery() { Id = id });

            if (productCategory == null)
            {
                return NotFound();
            }

            return Ok(productCategory);
        }

        [HttpPost]
        public async Task<IActionResult> AddProductCategory([FromBody] Application.Handlers.ProductCategory.Commands.Add.AddProductCategoryCommand command)
        {
            //var id = await productCategoriesRepository.AddProductCategory(productCategorymodel);

            var id = await mediator.Send(command);

            return CreatedAtAction(nameof(GetProductCategoryById), new { id = id, controller = "ProductCategories" }, id);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProductCategory([FromBody] JsonPatchDocument document, [FromRoute] int id)
        {
            //await productCategoriesRepository.UpdateProductCategory(id, document);

            await mediator.Send(new Application.Handlers.ProductCategory.Commands.Update.UpdateProductCategoryCommand { Id = id, document = document });
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductCategory(int id)
        {
            //await productCategoriesRepository.DeleteProductCategory(id);

            await mediator.Send(new Application.Handlers.ProductCategory.Commands.Delete.DeleteProductCategoryCommand() { Id = id });

            return Ok();
        }
    }
}
