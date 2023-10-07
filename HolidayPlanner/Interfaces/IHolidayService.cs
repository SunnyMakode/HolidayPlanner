using HolidayPlanner.Common;

namespace HolidayPlanner.Interfaces
{
    public interface IHolidayService
    {
        IEnumerable<DateTime> GetNationalHolidayList(int year, string countryName);

        OutputResponse CalculateHolidayDays(DateTime startDate, DateTime endDate);
    }
}
