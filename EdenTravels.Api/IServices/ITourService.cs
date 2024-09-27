using EdenTravels.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface ITourService
    {
        Task<IEnumerable<TourDto>> GetAllToursAsync();
        Task<TourDto> GetTourByIdAsync(int id);
        Task<TourDto> CreateTourAsync(TourDto tourDto);
        Task<TourDto> UpdateTourAsync(int id, TourDto tourDto);
        Task<bool> DeleteTourAsync(int id);
        Task<decimal> GetDynamicPricingForTourAsync(int id);
    }
}