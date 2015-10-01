using System;
using System.Collections.Generic;
using System.Linq;

namespace Scanner
{
    public class Child
    {
        public Child()
        {
            previousFixturesPlayingIn = new List<Fixture>();
            fixturesPlayingIn = new List<Fixture>();
        }

        public string Name { get; set; }

        public string ParentName { get; set; }

        public string ParentEmail { get; set; }

        private List<Fixture> fixturesPlayingIn;

        private List<Fixture> previousFixturesPlayingIn;

        public Child UpdateFixtureList(List<Fixture> fixtures)
        {
            previousFixturesPlayingIn = fixturesPlayingIn;
            fixturesPlayingIn = fixtures.Where(fixture => fixture.Players.Contains(this.Name)).ToList();

            return this;
        }

        public bool ParentShouldBeInformed()
        {
            return GetMessageForParent().Count > 0;
        }

        public List<string> GetMessageForParent()
        {
            var result = new List<string>();

            foreach (var fixture in fixturesPlayingIn)
            {
                if (!previousFixturesPlayingIn.Any(previousFixture => previousFixture.CanBeConsideredSameAs(fixture)) 
                    && fixture.Kickoff > DateTime.Now)
                {
                    var resultString = string.Format("Now playing in {0} {1} at {2} on {3:f}",
                        fixture.Team,
                        fixture.Sport,
                        fixture.School,
                        fixture.Kickoff);

                    result.Add(resultString);
                }
            }

            foreach (var previousFixture in previousFixturesPlayingIn)
            {
                if (!fixturesPlayingIn.Any(fixture => fixture.CanBeConsideredSameAs(previousFixture))
                    && previousFixture.Kickoff > DateTime.Now)
                {
                    var resultString = string.Format("Now NOT playing in {0} {1} at {2} on {3:f}",
                        previousFixture.Team,
                        previousFixture.Sport,
                        previousFixture.School,
                        previousFixture.Kickoff);

                    result.Add(resultString);
                }
            }

            return result;
        }
    }
}