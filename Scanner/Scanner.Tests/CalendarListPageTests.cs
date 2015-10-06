namespace Scanner.Tests
{
    using System.Linq;
    using NUnit.Framework;

    [TestFixture]
    public class CalendarListPageTests
    {
        [Test]
        public void CanReadFixtures()
        {
            var config = new PageConfig();
            var calendarListPage = new CalendarListPage(config.CalendarListUrl);

            var fixtures = calendarListPage.GetFixtures();
            Assert.That(fixtures.Count(), Is.GreaterThan(0));
        }
    }
}