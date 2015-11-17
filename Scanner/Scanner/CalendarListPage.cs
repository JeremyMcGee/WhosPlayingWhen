namespace Scanner
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using HtmlAgilityPack;

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
                    string currentHtml = column.InnerHtml;

                    while (currentHtml.Contains("a href"))
                                        {
                        yield return GetFixture(currentHtml);
                        int href = currentHtml.IndexOf("a href");
                        currentHtml = currentHtml.Substring(href + 1);
                    }
                }
            }

            yield break;
        }

        private string ReadHtml()
        {
            return ReadHtml(this.url);
        }

        private string ReadHtml(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        internal Fixture GetFixture(string innerHtml)
        {
            int href = innerHtml.IndexOf("a href=\"");
            string linkWithTrail = innerHtml.Substring(href + 8);
            int endHref = linkWithTrail.IndexOf("\"");
            string link = linkWithTrail.Substring(0, endHref);

            var doc = new HtmlDocument();
            doc.LoadHtml(ReadHtml(link));

            var fixture = new Fixture
            {
                Sport = GetSport(doc),
                Team = GetTeam(doc),
                School = GetOpponent(doc),
                Kickoff = GetKickoff(doc),
                HomeAway = GetHomeAway(doc),
                Venue = GetVenue(doc),
                Link = link
            };

            Logger.Debug("   {0}", fixture);

            fixture.Players.AddRange(GetPlayers(link));
            return fixture;
        }

        private IEnumerable<string> GetPlayers(string sourceLink)
        {
            string targetLink = sourceLink.Replace("iframefixturedetails.asp", "pu_MatchTeamSheet.asp");

            var doc = new HtmlDocument();
            doc.LoadHtml(ReadHtml(targetLink));

            return GetPlayers(doc);
        }

        private IEnumerable<string> GetPlayers(HtmlDocument doc)
        {
            var htmlNode = doc.DocumentNode.SelectSingleNode("//table/tr[2]/td[2]/ol");

            if (htmlNode == null || htmlNode.FirstChild == null)
            {
                yield break;    
            }

            htmlNode = htmlNode.FirstChild;

            do
            {
                int caret = htmlNode.InnerHtml.IndexOf("<");
                string result = caret > 0 ? htmlNode.InnerHtml.Substring(0, caret) : htmlNode.InnerText;

                htmlNode = htmlNode.NextSibling;

                yield return result;
                
            } while (htmlNode != null);
        }

        internal string GetSport(HtmlDocument doc)
        {
            var htmlToParse = doc.DocumentNode.SelectSingleNode("//table/tr/td/p").InnerHtml;

            int startTagPos = htmlToParse.IndexOf("<br>");
            return htmlToParse.Substring(0, startTagPos);
        }

        internal string GetOpponent(HtmlDocument doc)
        {
            var htmlToParse = doc.DocumentNode.SelectSingleNode("//table/tr/td/p").InnerHtml;

            int startTagPos = htmlToParse.IndexOf("<br>");
            var teamAndOpponents = htmlToParse
                .Substring(startTagPos + 4)
                .Replace("<b>", "")
                .Replace("</b>", "");

            return teamAndOpponents.Substring(teamAndOpponents.IndexOf(" v ") + 3);
        }

        internal string GetTeam(HtmlDocument doc)
        {
            var htmlToParse = doc.DocumentNode.SelectSingleNode("//table/tr/td/p").InnerHtml;

            int startTagPos = htmlToParse.IndexOf("<br>");
            var teamAndOpponents = htmlToParse
                .Substring(startTagPos + 4)
                .Replace("<b>", "")
                .Replace("</b>", "");

            return teamAndOpponents.Substring(0, teamAndOpponents.IndexOf(" v "));
        }

        internal string GetHomeAway(HtmlDocument doc)
        {
            var tagContents = doc.DocumentNode.SelectSingleNode("//table/tr/td/table/tr[2]/td/table/tr[3]/td/a");

            if (tagContents != null)
            {
                return tagContents.InnerText.Split('|')[0].Trim();
            }

            return string.Empty;
        }

        internal string GetVenue(HtmlDocument doc)
        {
            var tagContents = doc.DocumentNode.SelectSingleNode("//table/tr/td/table/tr[2]/td/table/tr[3]/td/a");

            if (tagContents != null)
            {
                string[] homeAwayVenue = tagContents.InnerText.Split('|');
                if (homeAwayVenue.Length > 1)
                {
                    return homeAwayVenue[1].Trim();
                }
            }

            return "(unknown)";
        }

        internal DateTime? GetKickoff(HtmlDocument doc)
        {
            var dateHtmlToParse = doc.DocumentNode.SelectSingleNode("//table/tr/td/table/tr[2]/td/table/tr/td").InnerHtml;
            DateTime date = DateTime.Parse(dateHtmlToParse);

            var timeHtmlToParse = doc.DocumentNode.SelectSingleNode("//table/tr/td/table/tr[2]/td/table/tr[2]/td").InnerHtml;
            if (timeHtmlToParse != string.Empty)
            {
                var time = TimeSpan.Parse(timeHtmlToParse);
                date = date.Add(time);
            }

            return date;
        }
    }
}
