using EdenTravels.Api.Data;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetFeedbackForTourAsync(int tourId)
        {
            return await _context.Feedbacks
                                 .Include(f => f.Tour)
                                 .Include(f => f.User)
                                 .Where(f => f.TourID == tourId)
                                 .ToListAsync();
        }

        public async Task SubmitFeedbackAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }
    }

}
