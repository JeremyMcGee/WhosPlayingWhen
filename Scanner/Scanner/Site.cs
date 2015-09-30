namespace Scanner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Site
    {
        public void Scan()
        {
            var config = new PageConfig();

            var calendarListPage = new CalendarListPage(config.CalendarListUrl);
            var fixtures = calendarListPage.GetFixtures().ToList();
            var children = Child.GetAll().ToList();

            var updatedChildren = PlayingStatus.UpdatePlayers(fixtures, children);

            Child.SaveAll(updatedChildren);
        }
    }

    public class Child
    {
        public string Name { get; set; }

        public string ParentName { get; set; }

        public string ParentEmail { get; set; }

        public static IEnumerable<Child> GetAll()
        {
            yield break;
        }

        public static void SaveAll(IEnumerable<Child> children)
        {
            
        }

        internal void SetPlayingStatus(PlayingStatus playingStatus)
        {
            throw new NotImplementedException();
        }

        internal void InformParent()
        {
            throw new NotImplementedException();
        }
    }

    public class Fixture
    {
        
    }
}
