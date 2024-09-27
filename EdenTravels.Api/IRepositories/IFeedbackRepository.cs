using EdenTravels.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EdenTravels.Api.IRepositories
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetFeedbackForTourAsync(int tourId);
        Task SubmitFeedbackAsync(Feedback feedback);
    }

}
