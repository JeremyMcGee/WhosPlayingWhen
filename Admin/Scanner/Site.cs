using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner
{
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

    public class PlayingStatus
    {
        public PlayingStatus(Fixture fixture, Child child)
        {
        }
    }

    public class Child
    {
        public void RecordPlayingStatus(PlayingStatus playingStatus)
        {
        }

        public void InformParentOfPlayingStatus()
        {
        }
    }

    public class Fixture
    {
    }

    public class CalendarListPage
    {
        private string url;

        public CalendarListPage(string url)
        {
            this.url = url;
        }

        public IEnumerable<Fixture> GetFixtures()
        {
            yield break;
        }
    }
}
