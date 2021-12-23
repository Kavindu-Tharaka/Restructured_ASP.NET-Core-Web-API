using Ancon.Domain.Entities;
using Ancon.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Persistance
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {

            CreateMap<Product, ProductQueryModel>().ReverseMap();

            CreateMap<ProductCategory, ProductCategoryQueryModel>().ReverseMap();

            CreateMap<Resturant, ResturantQueryModel>().ReverseMap();


        }
    }
}
