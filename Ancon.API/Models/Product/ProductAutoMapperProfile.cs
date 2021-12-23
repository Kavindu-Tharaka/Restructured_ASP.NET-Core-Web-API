using Ancon.API.Models.Product.Command.Add;
using Ancon.API.Models.Product.Command.Delete;
using Ancon.API.Models.Product.Command.Update;
using Ancon.API.Models.Product.Queries.Get;
using Ancon.API.Models.Product.Queries.GetById;
using AutoMapper;

namespace Ancon.API.Models.Resturant
{
    public class ProductAutoMapperProfile : Profile
    {
        public ProductAutoMapperProfile()
        {
            CreateMap<AddProductCommand, Application.Handlers.Product.Commands.Add.AddProductCommand>();

            CreateMap<DeleteProductCommand, Application.Handlers.Product.Commands.Delete.DeleteProductCommand>();

            CreateMap<UpdateProductCommand, Application.Handlers.Product.Commands.Update.UpdateProductCommand>();

            CreateMap<GetProductQuery, Application.Handlers.Product.Queries.Get.GetProductQuery>();

            CreateMap<GetByIdProductQuery, Application.Handlers.Product.Queries.GetById.GetByIdProductQuery>();
        }
    }
}
