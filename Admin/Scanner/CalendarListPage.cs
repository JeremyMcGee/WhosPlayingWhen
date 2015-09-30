using System.Collections.Generic;
using Admin.Models;

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
            yield break;
        }
    }
}