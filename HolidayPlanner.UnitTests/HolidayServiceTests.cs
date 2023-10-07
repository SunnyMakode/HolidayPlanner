using HolidayPlanner.Constants;
using HolidayPlanner.Interfaces;
using HolidayPlanner.Services;
using NUnit.Framework;

namespace HolidayPlanner.UnitTests
{
    [TestFixture]
    public class HolidayServiceTests
    {
        private IHolidayService holidayService;
        private HolidayPlanner holidayPlanner;

        [SetUp]
        public void Setup()
        {
            holidayService = new HolidayService();
            holidayPlanner = new HolidayPlanner(holidayService);
        }

        [Test]
        public void GetHolidayDays_WithValidDates_ExpectingHolidayDaysWithMessage()
        {
            // Arrange
            var validStartDate = new DateTime(day: 1, month: 12, year: 2021);
            var validEndDate = new DateTime(day: 2, month: 1, year: 2022);

            // Act
            var response = holidayPlanner.GetHolidayDays(validStartDate, validEndDate);

            // Assert
            Assert.IsNotNull(response);
            Assert.That(response.HolidayDays, Is.EqualTo(25));
        }

        [Test]
        public void GetHolidayDays_WithSaturday_ExpectingFourHolidayDaysWithMessage()
        {
            // Arrange
            var validStartDate = new DateTime(day: 1, month: 12, year: 2021);
            var validEndDate = new DateTime(day: 6, month: 12, year: 2021);

            // Act
            var response = holidayPlanner.GetHolidayDays(validStartDate, validEndDate);

            // Assert
            Assert.IsNotNull(response);
            Assert.That(response.HolidayDays, Is.EqualTo(4));
        }

        [Test]
        public void GetHolidayDays_WithGreaterTimespanThan50_ExpectingZeroHolidayDaysWithMessage()
        {
            // Arrange
            var startDate = new DateTime(day: 1, month: 1, year: 2021);
            var endDate = new DateTime(day: 1, month: 5, year: 2021);

            // Act
            var response = holidayPlanner.GetHolidayDays(startDate, endDate);

            // Assert
            Assert.IsNotNull(response);
            Assert.That(response.HolidayDays, Is.EqualTo(0));
            Assert.That(response.ResponseMessage, Is.EqualTo(StringConstants.ValidationMessageForTimespan));
        }

        [Test]
        public void GetHolidayDays_WithDatesMissingChronology_ExpectingZeroHolidayDaysWithMessage()
        {
            // Arrange
            var greaterStartDate = new DateTime(day: 1, month: 3, year: 2022);
            var smallerEndDate = new DateTime(day: 1, month: 4, year: 2021);

            // Act
            var response = holidayPlanner.GetHolidayDays(greaterStartDate, smallerEndDate);

            // Assert
            Assert.IsNotNull(response);
            Assert.That(response.HolidayDays, Is.EqualTo(0));
            Assert.That(response.ResponseMessage, Is.EqualTo(StringConstants.ValidationMessageForChronology));
        }

        [Test]
        public void GetHolidayDays_WithInValidDatesBeyondAprilMarchPeriod_ExpectingZeroHolidayDaysWithMessage()
        {
            // Arrange
            var invalidStartDate = new DateTime(day: 1, month: 3, year: 2021);
            var invalidEndDate = new DateTime(day: 1, month: 4, year: 2021);

            // Act
            var response = holidayPlanner.GetHolidayDays(invalidStartDate, invalidEndDate);

            // Assert
            Assert.IsNotNull(response);
            Assert.That(response.HolidayDays, Is.EqualTo(0));
            Assert.That(response.ResponseMessage, Is.EqualTo(StringConstants.ValidationMessageForHolidayPeriod));
        }
    }
}