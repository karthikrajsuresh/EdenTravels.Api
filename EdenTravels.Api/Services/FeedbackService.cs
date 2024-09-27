using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using EdenTravels.Api.Models;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository, IMapper mapper)
        {
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeedbackDto>> GetFeedbackForTourAsync(int tourId)
        {
            var feedbacks = await _feedbackRepository.GetFeedbackForTourAsync(tourId);
            return _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        }

        public async Task SubmitFeedbackAsync(FeedbackDto feedbackDto)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDto);
            await _feedbackRepository.SubmitFeedbackAsync(feedback);
        }
    }

}
