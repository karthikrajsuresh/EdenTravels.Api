using EdenTravels.Api.DTOs;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface ICancellationService
    {
        Task<CancellationDto> GetCancellationByBookingIdAsync(int bookingId);
        Task<CancellationDto> CreateCancellationAsync(CancellationDto cancellationDto);
        Task<CancellationDto> UpdateCancellationStatusAsync(int cancellationId, CancellationDto cancellationDto);
    }
}
