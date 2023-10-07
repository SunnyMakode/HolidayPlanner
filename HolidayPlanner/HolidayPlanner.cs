using HolidayPlanner.Common;
using HolidayPlanner.Interfaces;

namespace HolidayPlanner
{
    public class HolidayPlanner
    {
        private readonly IHolidayService _holidayService;

        public HolidayPlanner(IHolidayService holidayService)
        {
            _holidayService = holidayService;
        }

        public OutputResponse GetHolidayDays(DateTime startDate, DateTime endDate)
        {
            return _holidayService.CalculateHolidayDays(startDate, endDate);
        }
    }
}
