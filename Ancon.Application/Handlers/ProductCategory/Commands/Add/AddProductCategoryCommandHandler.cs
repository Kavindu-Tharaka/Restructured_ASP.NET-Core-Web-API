using Ancon.Domain.Interfaces;
using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Commands.Add
{
    public class AddProductCategoryCommandHandler : IRequestHandler<AddProductCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddProductCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(AddProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = new Domain.Entities.ProductCategory()
            {
                CategoryName = request.CategoryName,
            };

            return await _unitOfWork.productCategoryRepository.AddProductCategory(productCategory);

        }
    }
}
