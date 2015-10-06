using System;
using System.Collections.Generic;

namespace Scanner
{
    public class CalendarListPage
    {
        private string url;

        public CalendarListPage(string url)
        {
            this.url = url;
        }

        public IEnumerable<Fixture> GetFixtures()
        {
            throw new NotImplementedException();
        }
    }
}