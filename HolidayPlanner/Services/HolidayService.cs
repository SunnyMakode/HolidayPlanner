using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HolidayPlanner.Common;
using HolidayPlanner.Data;
using HolidayPlanner.Interfaces;

namespace HolidayPlanner.Services
{
    public class HolidayService : IHolidayService
    {
        /// <summary>
        /// The first version needs to handle Finnish national holidays for 2021 and 2022
        /// </summary>
        /// <param name="year"></param>
        /// <param name="countryName"></param>
        /// <returns>Return the national holidays list wrt country and year </returns>
        public IEnumerable<DateTime> GetNationalHolidayList(int year, string countryName)
        {
            return FinnishNationalHoliday.GetFinnishNationalHolidays;
        }

        /// <summary>
        /// Returns the holiday days a person can take between valid timespan
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns> 0 if the validation fails else send number of holiday days </returns>
        public OutputResponse CalculateHolidayDays(DateTime startDate, DateTime endDate)
        {
            string validationError = DateUtility.ValidateInputDates(startDate, endDate);

            if (!string.IsNullOrEmpty(validationError))
            {
                return new OutputResponse
                {
                    HolidayDays = 0,
                    ResponseMessage = validationError
                };
            }

            var nationalHolidays = GetNationalHolidayList(2021, RegionInfo.CurrentRegion.Name);

            int holidayDays = 0;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Sunday && !nationalHolidays.Contains(date))
                {
                    holidayDays++;
                }
            }

            return new OutputResponse
            {
                HolidayDays = holidayDays,
                ResponseMessage = $"\nYou've {holidayDays} holiday days"
            };
        }
    }
}
