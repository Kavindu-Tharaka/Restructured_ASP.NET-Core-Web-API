using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Models;
using Ancon.Persistance;
using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Querying.Product
{
    public class ProductQuery : IProductQuery
    {
        private readonly IConfiguration configuration;

        public ProductQuery(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<ProductQueryModel>> GetAllProducts()
        {
            //var records = await context.Products.Include(product => product.Resturant)
            //.Include(product => product.ProductCategory).ToListAsync();
            //return mapper.Map<List<ProductQueryModel>>(records);

            var sql = "SELECT * FROM public.\"Products\";";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("ResturantStoreDBPostgres")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductQueryModel>(sql);


                return (List<ProductQueryModel>)result;
            }
        }

        public async Task<IEnumerable<ProductQueryModel>> GetProductById(int id)
        {
            //var product = await context.Products.Include(product => product.Resturant)
            //.Include(product => product.ProductCategory).FirstOrDefaultAsync(p => p.Id.Equals(id));

            //return mapper.Map<Handlers.Product.GetProductById.ProductModel>(product);

            var sql = "SELECT * FROM public.\"Products\" WHERE \"Id\" =" + id + ";";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("ResturantStoreDBPostgres")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ProductQueryModel>(sql);

                Console.WriteLine(result);

                return result;
            }
        }
    }
}
