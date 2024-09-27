using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using EdenTravels.Api.Models;
using AutoMapper;
using System.Threading.Tasks;

namespace EdenTravels.Api.Services
{
    public class CancellationService : ICancellationService
    {
        private readonly ICancellationRepository _cancellationRepository;
        private readonly IMapper _mapper;

        public CancellationService(ICancellationRepository cancellationRepository, IMapper mapper)
        {
            _cancellationRepository = cancellationRepository;
            _mapper = mapper;
        }

        public async Task<CancellationDto> GetCancellationByBookingIdAsync(int bookingId)
        {
            var cancellation = await _cancellationRepository.GetCancellationByBookingIdAsync(bookingId);
            if (cancellation == null) return null;
            return _mapper.Map<CancellationDto>(cancellation);
        }

        public async Task<CancellationDto> CreateCancellationAsync(CancellationDto cancellationDto)
        {
            var cancellation = _mapper.Map<Cancellation>(cancellationDto);
            await _cancellationRepository.CreateCancellationAsync(cancellation);
            return _mapper.Map<CancellationDto>(cancellation);
        }

        public async Task<CancellationDto> UpdateCancellationStatusAsync(int cancellationId, CancellationDto cancellationDto)
        {
            var cancellation = await _cancellationRepository.GetCancellationByIdAsync(cancellationId);
            if (cancellation == null) return null;

            cancellation.Status = cancellationDto.Status;  // Update the status
            await _cancellationRepository.UpdateCancellationAsync(cancellation);
            return _mapper.Map<CancellationDto>(cancellation);
        }
    }

}
