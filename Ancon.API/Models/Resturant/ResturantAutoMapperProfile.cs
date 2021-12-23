using Ancon.API.Models.Resturant.Command.Add;
using Ancon.API.Models.Resturant.Command.Delete;
using Ancon.API.Models.Resturant.Command.Update;
using Ancon.API.Models.Resturant.Queries.Get;
using Ancon.API.Models.Resturant.Queries.GetById;
using AutoMapper;

namespace Ancon.API.Models.Resturant
{
    public class ProductCategoryAutoMapperProfile : Profile
    {
        public ProductCategoryAutoMapperProfile()
        {
            CreateMap<AddResturantCommand, Application.Handlers.Resturant.Commands.Add.AddResturantCommand>();

            CreateMap<DeleteResturantCommand, Application.Handlers.Resturant.Commands.Delete.DeleteResturantCommand>();

            CreateMap<UpdateResturantCommand, Application.Handlers.Resturant.Commands.Update.UpdateResturantCommand>();

            CreateMap<GetResturantQuery, Application.Handlers.Resturant.Queries.Get.GetResturantQuery>();

            CreateMap<GetByIdResturantQuery, Application.Handlers.Resturant.Queries.GetById.GetByIdResturantQuery>();
        }
    }
}
