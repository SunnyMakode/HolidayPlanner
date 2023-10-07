namespace HolidayPlanner.Constants
{
    public class StringConstants
    {
        public static readonly string StartDateInputMessage = 
            "Kindly enter your start date for holiday in dd.MM.yyyy format: ";

        public static readonly string EndDateInputMessage = 
            "Kindly enter your end date for holiday in dd.MM.yyyy format: ";

        public static readonly string DateFormatValidationMessage = 
            "Kindly enter a date in the format dd.MM.yyyy like for example 01.12.2021";

        public static readonly string ValidationMessageForChronology =
            "The dates for the time span must be in chronological order";

        public static readonly string ValidationMessageForTimespan =
            "The maximum length of the time span is 50 days";

        public static readonly string ValidationMessageForHolidayPeriod =
            "The whole time span has to be within the same holiday period that " +
            "begins on the 1st of April and ends on the 31st of March";
    }
}
