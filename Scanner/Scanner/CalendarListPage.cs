using System;
using System.Collections.Generic;
using System.Net;
using HtmlAgilityPack;

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
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(ReadHtml());

            var calHolder = doc.GetElementbyId("CalendarHolder");

            var rows = calHolder.ChildNodes;

            foreach (var row in rows)
            {
                foreach (var column in row.ChildNodes)
                {
                    Console.WriteLine(column.InnerHtml);
                }
            }

            yield break;
        }

        private string ReadHtml()
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(this.url);
            }
        }
    }
}