using HolidayPlanner.Common;
using HolidayPlanner.Constants;
using HolidayPlanner.Services;

namespace HolidayPlanner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var holidayPlanner = new HolidayPlanner(new HolidayService());

            DateTime startDate = DateUtility.ReadDateInSpecifiedFormat(StringConstants.StartDateInputMessage);
            DateTime endDate = DateUtility.ReadDateInSpecifiedFormat(StringConstants.EndDateInputMessage);

            var output = holidayPlanner.GetHolidayDays(startDate, endDate);

            Console.WriteLine(output.ResponseMessage);
        }
    }
}