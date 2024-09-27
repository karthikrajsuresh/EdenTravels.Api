using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using EdenTravels.Api.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Services
{
    public class PromotionService : IPromotionService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly IMapper _mapper;

        public PromotionService(IPromotionRepository promotionRepository, IMapper mapper)
        {
            _promotionRepository = promotionRepository;
            _mapper = mapper;
        }

        // Get promotions for a specific tour
        public async Task<IEnumerable<PromotionDto>> GetPromotionsForTourAsync(int tourId)
        {
            var promotions = await _promotionRepository.GetPromotionsForTourAsync(tourId);
            return _mapper.Map<IEnumerable<PromotionDto>>(promotions);
        }

        // Create a new promotion
        public async Task<PromotionDto> CreatePromotionAsync(PromotionDto promotionDto)
        {
            var promotion = _mapper.Map<Promotion>(promotionDto);
            await _promotionRepository.CreatePromotionAsync(promotion);
            return _mapper.Map<PromotionDto>(promotion);
        }

        // Delete a promotion by ID
        public async Task<bool> DeletePromotionAsync(int promotionId)
        {
            var promotion = await _promotionRepository.GetPromotionByIdAsync(promotionId);
            if (promotion == null) return false;

            await _promotionRepository.DeletePromotionAsync(promotion);
            return true;
        }
    }
}
