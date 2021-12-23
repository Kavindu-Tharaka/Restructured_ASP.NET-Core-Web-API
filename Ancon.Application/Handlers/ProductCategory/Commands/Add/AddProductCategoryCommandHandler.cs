using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Commands.Add
{
    public class AddProductCategoryCommandHandler : IRequestHandler<AddProductCategoryCommand, int>
    {
        private readonly IProductCategoryRepository productCategoryRepository;

        public AddProductCategoryCommandHandler(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public async Task<int> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = new Domain.Entities.ProductCategory()
            {
                CategoryName = request.CategoryName,
            };

            return await productCategoryRepository.AddProductCategory(productCategory);

        }
    }
}
