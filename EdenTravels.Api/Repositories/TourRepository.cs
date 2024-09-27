using EdenTravels.Api.Data;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Repositories
{
    public class TourRepository : ITourRepository
    {
        private readonly ApplicationDbContext _context;

        public TourRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tour>> GetAllToursAsync()
        {
            return await _context.Tours.ToListAsync();
        }

        public async Task<Tour> GetTourByIdAsync(int id)
        {
            return await _context.Tours.FindAsync(id);
        }

        public async Task CreateTourAsync(Tour tour)
        {
            await _context.Tours.AddAsync(tour);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTourAsync(Tour tour)
        {
            _context.Tours.Update(tour);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTourAsync(Tour tour)
        {
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetDynamicPricingForTourAsync(int id)
        {
            // Implement dynamic pricing logic here
            var tour = await _context.Tours.FindAsync(id);
            return tour?.DynamicPrice ?? 0;
        }
    }
}