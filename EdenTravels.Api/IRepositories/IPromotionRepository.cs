using EdenTravels.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IRepositories
{
    public interface IPromotionRepository
    {
        Task<IEnumerable<Promotion>> GetPromotionsForTourAsync(int tourId);
        Task<Promotion> GetPromotionByIdAsync(int promotionId);
        Task CreatePromotionAsync(Promotion promotion);
        Task DeletePromotionAsync(Promotion promotion);
    }

}
