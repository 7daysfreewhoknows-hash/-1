using WebApplication1.DTO;

namespace WebApplication1.Services
{
    public interface IScheduleService
    {
        Task<List<ScheduleByDateDto>> GetScheduleForGroup(string groupName, DateTime
startDate, DateTime endDate);
    }
}
