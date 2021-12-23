using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Querying.ProductCategory
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly IConfiguration configuration;

        public ProductCategoryQuery(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<ProductCategoryQueryModel>> GetAllProductCategories()
        {
            //var records = await context.ProductCategories.Include(productCategory => productCategory.Products).ToListAsync();
            //return mapper.Map<List<Handlers.ProductCategory.GetAllProductCategories.ProductCategoryModel>>(records);

            var sql = "SELECT * FROM public.\"ProductCategories\";";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("ResturantStoreDBPostgres")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductCategoryQueryModel>(sql);


                return (List<ProductCategoryQueryModel>)result;
            }
        }

        public async Task<ProductCategoryQueryModel> GetProductCategoryById(int id)
        {
            //var productCategory = await context.ProductCategories.Include(productCategory => productCategory.Products).FirstOrDefaultAsync(pc => pc.Id.Equals(id));
            //return mapper.Map<Handlers.ProductCategory.GetProductCategoryById.ProductCategoryModel>(productCategory);

            var sql = "SELECT * FROM public.\"ProductCategories\" WHERE \"Id\" =" + id + ";";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("ResturantStoreDBPostgres")))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<ProductCategoryQueryModel>(sql);

                return result;
            }
        }
    }
}
