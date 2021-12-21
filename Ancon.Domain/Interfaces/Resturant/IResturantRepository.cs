using Ancon.Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Interfaces.Resturant
{
    public interface IResturantRepository
    {
        Task<int> AddResturant(ResturantAddModel resturantModel);
        Task UpdateResturant(int resturantId, JsonPatchDocument document);
        Task DeleteResturant(int resturantId);
    }
}
