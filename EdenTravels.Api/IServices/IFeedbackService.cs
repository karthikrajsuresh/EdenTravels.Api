using EdenTravels.Api.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDto>> GetFeedbackForTourAsync(int tourId);
        Task SubmitFeedbackAsync(FeedbackDto feedbackDto);
    }

}
