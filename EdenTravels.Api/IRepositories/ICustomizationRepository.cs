using EdenTravels.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IRepositories
{
    public interface ICustomizationRepository
    {
        Task<IEnumerable<Customization>> GetCustomizationsForTourAsync(int tourId);
        Task CreateCustomizationAsync(Customization customization);
    }
}
