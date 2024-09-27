using EdenTravels.Api.DTOs;
using EdenTravels.Api.IRepositories;
using EdenTravels.Api.IServices;
using AutoMapper;
using System.Threading.Tasks;


namespace EdenTravels.Api.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IMapper _mapper;

        public ReportService(IReportRepository reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public async Task<ReportDto> GetBookingsSummaryReportAsync()
        {
            var reportData = await _reportRepository.GetBookingsSummaryReportAsync();
            return _mapper.Map<ReportDto>(reportData);
        }

        public async Task<ReportDto> GetRevenueSummaryReportAsync()
        {
            var reportData = await _reportRepository.GetRevenueSummaryReportAsync();
            return _mapper.Map<ReportDto>(reportData);
        }
    }

}
