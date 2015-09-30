namespace Scanner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Admin.Models;

    public class Site
    {
        public void Scan()
        {
            var config = new PageConfig();

            var calendarListPage = new CalendarListPage(config.CalendarListUrl);
            var fixtures = new List<Fixture>(calendarListPage.GetFixtures());

            foreach (var fixture in fixtures)
            {
                foreach (var child in GetChildren())
                {
                    var playingStatus = new PlayingStatus(fixture, child);
                    child.RecordPlayingStatus(playingStatus);
                    child.InformParentOfPlayingStatus();
                }
            }
        }

        public IEnumerable<Child> GetChildren()
        {
            yield break;
        }
    }
}
