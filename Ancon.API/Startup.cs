using Ancon.API.Models.Resturant.Command.Add;
using Ancon.Application.Handlers.Resturant.Queries.Get;
using Ancon.Domain.Interfaces.Product;
using Ancon.Domain.Interfaces.ProductCategory;
using Ancon.Domain.Interfaces.Resturant;
using Ancon.Persistance;
using Ancon.Persistance.Repositories.Product;
using Ancon.Persistance.Repositories.ProductCategory;
using Ancon.Persistance.Repositories.Resturant;
using Ancon.Querying.Product;
using Ancon.Querying.ProductCategory;
using Ancon.Querying.Resturant;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Ancon.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMediatR(Assembly.GetExecutingAssembly());






            // meka witharak dala thiyeddi anith ewa wada karanne kohomada?

            services.AddMediatR(typeof(GetResturantQueryHandler).GetTypeInfo().Assembly);
            //services.AddMediatR(typeof(AddResturantCommand).GetTypeInfo().Assembly);











            services.AddControllers().AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ancon.API", Version = "v1" });
            });

            services.AddScoped<IProductQuery, ProductQuery>();  //singleton, scoped dala wenasa balanna
            services.AddScoped<IProductCategoryQuery, ProductCategoryQuery>();  //singleton, scoped dala wenasa balanna
            services.AddScoped<IResturantQuery, ResturantQuery>();  //singleton, scoped dala wenasa balanna


            services.AddScoped<IProductRepository, ProductRepository>();  //singleton, scoped dala wenasa balanna
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();  //singleton, scoped dala wenasa balanna
            services.AddScoped<IResturantRepository, ResturantRepository>();  //singleton, scoped dala wenasa balanna

            //services.AddDbContext<ResturantStoreContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ResturantStoreDB")));

            services.AddDbContext<ResturantStoreContext>(options => options.UseNpgsql(Configuration.GetConnectionString("ResturantStoreDBPostgres")));

            services.AddAutoMapper(typeof(Startup), typeof(ApplicationMapper));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ancon.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
