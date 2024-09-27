using EdenTravels.Api.Models;
using System.Threading.Tasks;

namespace EdenTravels.Api.IRepositories
{
    public interface ICancellationRepository
    {
        Task<Cancellation> GetCancellationByBookingIdAsync(int bookingId);
        Task<Cancellation> GetCancellationByIdAsync(int cancellationId);
        Task CreateCancellationAsync(Cancellation cancellation);
        Task UpdateCancellationAsync(Cancellation cancellation);
    }
}
