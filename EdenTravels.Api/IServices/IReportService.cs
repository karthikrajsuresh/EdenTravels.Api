using EdenTravels.Api.DTOs;
using System.Threading.Tasks;

namespace EdenTravels.Api.IServices
{
    public interface IReportService
    {
        Task<ReportDto> GetBookingsSummaryReportAsync();
        Task<ReportDto> GetRevenueSummaryReportAsync();
    }

}
