using Ancon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Domain.Interfaces.Resturant
{
    public interface IResturantQuery
    {
        Task<List<ResturantQueryModel>> GetAllResturants();
        Task<IEnumerable<ResturantQueryModel>> GetResturantById(int id);
    }
}
