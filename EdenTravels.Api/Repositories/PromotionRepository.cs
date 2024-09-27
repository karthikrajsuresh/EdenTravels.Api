using EdenTravels.Api.Data;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Repositories
{
    public class PromotionRepository : IPromotionRepository
    {
        private readonly ApplicationDbContext _context;

        public PromotionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all promotions for a specific tour
        public async Task<IEnumerable<Promotion>> GetPromotionsForTourAsync(int tourId)
        {
            return await _context.Promotions
                                 .Where(p => p.TourID == tourId)
                                 .ToListAsync();
        }

        // Get promotion by ID
        public async Task<Promotion> GetPromotionByIdAsync(int promotionId)
        {
            return await _context.Promotions.FirstOrDefaultAsync(p => p.PromotionID == promotionId);
        }

        // Create a new promotion
        public async Task CreatePromotionAsync(Promotion promotion)
        {
            await _context.Promotions.AddAsync(promotion);
            await _context.SaveChangesAsync();
        }

        // Delete a promotion
        public async Task DeletePromotionAsync(Promotion promotion)
        {
            _context.Promotions.Remove(promotion);
            await _context.SaveChangesAsync();
        }
    }

}
