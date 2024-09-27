using EdenTravels.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface IPromotionService
    {
        Task<IEnumerable<PromotionDto>> GetPromotionsForTourAsync(int tourId);
        Task<PromotionDto> CreatePromotionAsync(PromotionDto promotionDto);
        Task<bool> DeletePromotionAsync(int promotionId);
    }
}
