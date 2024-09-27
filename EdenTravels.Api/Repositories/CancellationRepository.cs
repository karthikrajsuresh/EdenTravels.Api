using EdenTravels.Api.Data;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EdenTravels.Api.Repositories
{
    public class CancellationRepository : ICancellationRepository
    {
        private readonly ApplicationDbContext _context;

        public CancellationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get cancellation details by Booking ID
        public async Task<Cancellation> GetCancellationByBookingIdAsync(int bookingId)
        {
            return await _context.Cancellations
                                 .Include(c => c.Booking)
                                 .FirstOrDefaultAsync(c => c.BookingID == bookingId);
        }

        // Get cancellation by ID
        public async Task<Cancellation> GetCancellationByIdAsync(int cancellationId)
        {
            return await _context.Cancellations.FindAsync(cancellationId);
        }

        // Create a new cancellation
        public async Task CreateCancellationAsync(Cancellation cancellation)
        {
            await _context.Cancellations.AddAsync(cancellation);
            await _context.SaveChangesAsync();
        }

        // Update cancellation
        public async Task UpdateCancellationAsync(Cancellation cancellation)
        {
            _context.Cancellations.Update(cancellation);
            await _context.SaveChangesAsync();
        }
    }

}
