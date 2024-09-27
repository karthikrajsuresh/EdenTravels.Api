using EdenTravels.Api.Data;
using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EdenTravels.Api.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ReportData> GetBookingsSummaryReportAsync()
        {
            var totalBookings = await _context.Bookings.CountAsync();
            var totalTours = await _context.Tours.CountAsync();
            return new ReportData
            {
                TotalBookings = totalBookings,
                TotalTours = totalTours,
                ReportGeneratedOn = DateTime.Now
            };
        }

        public async Task<ReportData> GetRevenueSummaryReportAsync()
        {
            var totalRevenue = await _context.Payments.SumAsync(p => p.Amount);
            return new ReportData
            {
                TotalRevenue = totalRevenue,
                ReportGeneratedOn = DateTime.Now
            };
        }
    }

}
