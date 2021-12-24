using Ancon.Domain.Interfaces;
using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.ProductCategory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ancon.Application.Handlers.ProductCategory.Commands.Update
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateProductCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            await _unitOfWork.productCategoryRepository.UpdateProductCategory(request.Id, request.document);

            return Unit.Value;
        }
    }
}
