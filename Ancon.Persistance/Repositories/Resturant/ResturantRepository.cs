using Ancon.Domain.Interfaces.Resturant;
using Ancon.Domain.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Ancon.Persistance.Repositories.Resturant
{
    public class ResturantRepository : IResturantRepository
    {
        private readonly ResturantStoreContext context;
        private readonly IMapper mapper;

        public ResturantRepository(ResturantStoreContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<int> AddResturant(ResturantAddModel resturantModel)
        {
            var resturant = mapper.Map<Domain.Entities.Resturant>(resturantModel);   //mehema harida?  //swagger walin test karaddi add nam una

            context.Resturants.Add(resturant);
            await context.SaveChangesAsync();

            return resturant.Id;
        }

        public async Task DeleteResturant(int resturantId)
        {
            var resturant = new Domain.Entities.Resturant() { Id = resturantId };
            context.Resturants.Remove(resturant);
            await context.SaveChangesAsync();
        }


        public async Task UpdateResturant(int resturantId, JsonPatchDocument document)
        {
            var resturant = await context.Resturants.FindAsync(resturantId);
            if (resturant != null)
            {
                document.ApplyTo(resturant);
                await context.SaveChangesAsync();
            }
        }
    }
}
