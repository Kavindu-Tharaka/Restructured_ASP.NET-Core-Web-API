using Ancon.Domain.Interfaces;
using Ancon.Domain.Interfaces.Resturant;
using Microsoft.AspNetCore.JsonPatch;
using System.Threading.Tasks;

namespace Ancon.Persistance.Repositories.Resturant
{
    public class ResturantRepository : IResturantRepository
    {
        private readonly ResturantStoreContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ResturantRepository(ResturantStoreContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddResturant(Domain.Entities.Resturant resturant)
        {
            _context.Resturants.Add(resturant);
            await _unitOfWork.SaveAync();

            return resturant.Id;
        }

        public async Task DeleteResturant(int resturantId)
        {
            var resturant = new Domain.Entities.Resturant() { Id = resturantId };
            _context.Resturants.Remove(resturant);
            await _unitOfWork.SaveAync();
        }


        public async Task UpdateResturant(int resturantId, JsonPatchDocument document)
        {
            var resturant = await _context.Resturants.FindAsync(resturantId);
            if (resturant != null)
            {
                document.ApplyTo(resturant);
                await _unitOfWork.SaveAync();
            }
        }
    }
}
