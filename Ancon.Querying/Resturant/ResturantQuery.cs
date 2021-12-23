using Ancon.Domain.Interfaces.Resturant;
using Ancon.Domain.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ancon.Querying.Resturant
{
    public class ResturantQuery : IResturantQuery
    {
        private readonly IConfiguration configuration;

        public ResturantQuery(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<List<ResturantQueryModel>> GetAllResturants()
        {
            //var records = await context.Resturants.Include(resturant => resturant.Products).ToListAsync();
            //return mapper.Map<List<Handlers.Resturant.GetAllResturants.ResturantModel>>(records);

            var sql = "SELECT * FROM public.\"Resturants\";";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("ResturantStoreDBPostgres")))
            {
                connection.Open();
                var result = await connection.QueryAsync<ResturantQueryModel>(sql);


                return (List<ResturantQueryModel>)result;
            }
        }

        public async Task<ResturantQueryModel> GetResturantById(int id)
        {
            //var resturant = await context.Resturants.Include(resturant => resturant.Products).FirstOrDefaultAsync(pc => pc.Id.Equals(id));
            //return mapper.Map<Handlers.Resturant.GetResturantById.ResturantModel>(resturant);

            var sql = "SELECT * FROM public.\"Resturants\" WHERE \"Id\" =" + id + ";";
            using (var connection = new NpgsqlConnection(configuration.GetConnectionString("ResturantStoreDBPostgres")))
            {
                connection.Open();
                var result = await connection.QueryFirstAsync<ResturantQueryModel>(sql);

                Console.WriteLine(result);

                return result;
            }
        }
    }
}
