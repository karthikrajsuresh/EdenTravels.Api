using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using EdenTravels.Api.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Services
{
    public class CustomizationService : ICustomizationService
    {
        private readonly ICustomizationRepository _customizationRepository;
        private readonly IMapper _mapper;

        public CustomizationService(ICustomizationRepository customizationRepository, IMapper mapper)
        {
            _customizationRepository = customizationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomizationDto>> GetCustomizationsForTourAsync(int tourId)
        {
            var customizations = await _customizationRepository.GetCustomizationsForTourAsync(tourId);
            return _mapper.Map<IEnumerable<CustomizationDto>>(customizations);
        }

        public async Task<CustomizationDto> CreateCustomizationAsync(CustomizationDto customizationDto)
        {
            var customization = _mapper.Map<Customization>(customizationDto);
            await _customizationRepository.CreateCustomizationAsync(customization);
            return _mapper.Map<CustomizationDto>(customization);
        }
    }

}
