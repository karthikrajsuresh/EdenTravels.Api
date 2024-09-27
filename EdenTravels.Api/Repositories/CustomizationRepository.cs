using EdenTravels.Api.Data;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Repositories
{
    public class CustomizationRepository : ICustomizationRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomizationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customization>> GetCustomizationsForTourAsync(int tourId)
        {
            return await _context.Customizations.Where(c => c.TourID == tourId).ToListAsync();
        }

        public async Task CreateCustomizationAsync(Customization customization)
        {
            await _context.Customizations.AddAsync(customization);
            await _context.SaveChangesAsync();
        }
    }
}
