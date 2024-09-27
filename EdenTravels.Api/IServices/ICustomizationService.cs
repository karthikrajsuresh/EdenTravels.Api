using EdenTravels.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface ICustomizationService
    {
        Task<IEnumerable<CustomizationDto>> GetCustomizationsForTourAsync(int tourId);
        Task<CustomizationDto> CreateCustomizationAsync(CustomizationDto customizationDto);
    }

}
