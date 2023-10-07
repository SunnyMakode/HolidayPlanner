using HolidayPlanner.Constants;

namespace HolidayPlanner.Common
{
    public class DateUtility
    {
        /// <summary>
        /// Reading date in the format dd.MM.yyyy
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static DateTime ReadDateInSpecifiedFormat(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                var inputDate = Console.ReadLine();

                if (DateTime.TryParseExact(inputDate, "d.M.yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }

                Console.WriteLine(StringConstants.DateFormatValidationMessage);
            }
        }

        /// <summary>
        /// Validating the start and end date based on business logic rules provided
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Empty string means no validation error, otherwise errors are returned</returns>
        public static string ValidateInputDates(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return StringConstants.ValidationMessageForChronology;
            }

            if ((endDate - startDate).TotalDays > 50)
            {
                return StringConstants.ValidationMessageForTimespan;
            }

            if (startDate < new DateTime(startDate.Year, 4, 1) || endDate > new DateTime(startDate.Year + 1, 3, 31))
            {
                return StringConstants.ValidationMessageForHolidayPeriod;
            }

            return string.Empty;
        }
    }
}
