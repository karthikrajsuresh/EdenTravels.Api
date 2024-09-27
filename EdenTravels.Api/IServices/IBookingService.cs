using EdenTravels.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDto>> GetAllBookingsAsync();
        Task<BookingDto> GetBookingByIdAsync(int id);
        Task<BookingDto> CreateBookingAsync(BookingDto bookingDto);
        Task<BookingDto> UpdateBookingAsync(int id, BookingDto bookingDto);
        Task<bool> DeleteBookingAsync(int id);
        Task<List<ParticipantDto>> GetBookingParticipantsAsync(int bookingId);
        Task<PassportVisaStatusDto> GetPassportVisaStatusAsync(int bookingId);
    }
}