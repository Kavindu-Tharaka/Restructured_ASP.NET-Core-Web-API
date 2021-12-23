using Ancon.API.Models.ProductCategory.Command.Add;
using Ancon.API.Models.ProductCategory.Command.Delete;
using Ancon.API.Models.ProductCategory.Command.Update;
using Ancon.API.Models.ProductCategory.Queries.Get;
using Ancon.API.Models.ProductCategory.Queries.GetById;
using AutoMapper;

namespace Ancon.API.Models.ProductCategory
{
    public class ProductCategoryAutoMapperProfile : Profile
    {
        public ProductCategoryAutoMapperProfile()
        {
            CreateMap<AddProductCategoryCommand, Application.Handlers.ProductCategory.Commands.Add.AddProductCategoryCommand>();

            CreateMap<DeleteProductCategoryCommand, Application.Handlers.ProductCategory.Commands.Delete.DeleteProductCategoryCommand>();

            CreateMap<UpdateProductCategoryCommand, Application.Handlers.ProductCategory.Commands.Update.UpdateProductCategoryCommand>();

            CreateMap<GetProductCategoryQuery, Application.Handlers.ProductCategory.Queries.Get.GetProductCategoryQuery>();

            CreateMap<GetByIdProductCategoryQuery, Application.Handlers.ProductCategory.Queries.GetById.GetByIdProductCategoryQuery>();
        }
    }
}
