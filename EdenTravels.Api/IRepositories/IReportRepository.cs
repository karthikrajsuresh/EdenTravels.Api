using EdenTravels.Api.DTOs;
using EdenTravels.Api.Models;
using System.Threading.Tasks;

namespace EdenTravels.Api.IRepositories
{
    public interface IReportRepository
    {
        Task<ReportData> GetBookingsSummaryReportAsync();
        Task<ReportData> GetRevenueSummaryReportAsync();
    }
}
