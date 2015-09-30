using System;
using System.Collections;
using System.Collections.Generic;

namespace Scanner
{
    using System.Linq;

    public class Site
    {
        public void Scan()
        {
            var config = new PageConfig();

            var calendarListPage = new CalendarListPage(config.CalendarListUrl);
            var fixtures = calendarListPage.GetFixtures();

            var children = UpdatedChildren(fixtures);

            Child.SaveAll(children);
        }

        private IEnumerable<Child> UpdatedChildren(IEnumerable<Fixture> fixtures)
        {
            var fixtureList = fixtures.ToList();

            foreach (var child in Child.GetAll())
            {
                var updatedChild = child.UpdateFixtureList(fixtureList);

                if (updatedChild.InformParent())
                {
                    SendMailToParent(child);
                }

                yield return updatedChild;
            }
        }

        private void SendMailToParent(Child player)
        {
            throw new NotImplementedException();
        }
    }
}
