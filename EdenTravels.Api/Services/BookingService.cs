using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using EdenTravels.Api.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository, IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookingDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return _mapper.Map<IEnumerable<BookingDto>>(bookings);
        }

        public async Task<BookingDto> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null) return null;
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> CreateBookingAsync(BookingDto bookingDto)
        {
            var booking = _mapper.Map<Booking>(bookingDto);
            await _bookingRepository.CreateBookingAsync(booking);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<BookingDto> UpdateBookingAsync(int id, BookingDto bookingDto)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null) return null;

            _mapper.Map(bookingDto, booking);
            await _bookingRepository.UpdateBookingAsync(booking);
            return _mapper.Map<BookingDto>(booking);
        }

        public async Task<bool> DeleteBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null) return false;

            await _bookingRepository.DeleteBookingAsync(booking);
            return true;
        }

        public async Task<List<ParticipantDto>> GetBookingParticipantsAsync(int bookingId)
        {
            var participants = await _bookingRepository.GetBookingParticipantsAsync(bookingId);
            return _mapper.Map<List<ParticipantDto>>(participants);
        }

        public async Task<PassportVisaStatusDto> GetPassportVisaStatusAsync(int bookingId)
        {
            var status = await _bookingRepository.GetPassportVisaStatusAsync(bookingId);
            return _mapper.Map<PassportVisaStatusDto>(status);
        }
    }
}