﻿namespace Scanner
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    using System.Linq;

    public class Site
    {
        private const string backingStore = "scanner";
        private readonly BackingStore persister = new BackingStore(backingStore);

        public Site()
        {
            persister.GetInitialChildren = GetDefaultInitialChildren;
        }

        public void Initialize()
        {
            persister.RemoveBackingStore();
            Scan();
        }

        public void Scan()
        {
            var config = new PageConfig();

            var calendarListPage = new CalendarListPage(config.CalendarListUrl);
            var fixtures = calendarListPage.GetFixtures();

            var children = UpdatedChildren(fixtures);

            persister.SaveAll(children);
        }

        private IEnumerable<Child> UpdatedChildren(IEnumerable<Fixture> fixtures)
        {
            var fixtureList = fixtures.ToList();

            foreach (var child in persister.GetAll())
            {
                var updatedChild = child.UpdateFixtureList(fixtureList);

                if (updatedChild.ParentShouldBeInformed())
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

        private IEnumerable<Child> GetDefaultInitialChildren()
        {
            yield return new Child { Name = "Julian McGee", ParentEmail = "jeremy.mcgee@bassettdata.com" };
            yield return new Child { Name = "Virginia McGee", ParentEmail = "jeremy.mcgee@bassettdata.com" };
        }
    }
}
