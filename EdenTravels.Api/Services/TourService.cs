using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using EdenTravels.Api.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Services
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;

        public TourService(ITourRepository tourRepository, IMapper mapper)
        {
            _tourRepository = tourRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TourDto>> GetAllToursAsync()
        {
            var tours = await _tourRepository.GetAllToursAsync();
            return _mapper.Map<IEnumerable<TourDto>>(tours);
        }

        public async Task<TourDto> GetTourByIdAsync(int id)
        {
            var tour = await _tourRepository.GetTourByIdAsync(id);
            if (tour == null) return null;
            return _mapper.Map<TourDto>(tour);
        }

        public async Task<TourDto> CreateTourAsync(TourDto tourDto)
        {
            var tour = _mapper.Map<Tour>(tourDto);
            await _tourRepository.CreateTourAsync(tour);
            return _mapper.Map<TourDto>(tour);
        }

        public async Task<TourDto> UpdateTourAsync(int id, TourDto tourDto)
        {
            var tour = await _tourRepository.GetTourByIdAsync(id);
            if (tour == null) return null;

            _mapper.Map(tourDto, tour);
            await _tourRepository.UpdateTourAsync(tour);
            return _mapper.Map<TourDto>(tour);
        }

        public async Task<bool> DeleteTourAsync(int id)
        {
            var tour = await _tourRepository.GetTourByIdAsync(id);
            if (tour == null) return false;

            await _tourRepository.DeleteTourAsync(tour);
            return true;
        }

        public async Task<decimal> GetDynamicPricingForTourAsync(int id)
        {
            return await _tourRepository.GetDynamicPricingForTourAsync(id);
        }
    }
}