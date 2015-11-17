namespace Scanner
{
    using System;
    using System.Collections.Generic;
    
    public class Fixture
    {
        public string School { get; set; }

        public DateTime? Kickoff { get; set; }

        public string Team { get; set; }

        public string Sport { get; set; }

        public string Venue { get; set; }

        public string HomeAway { get; set; }

        public string Link { get; set; }

        public Fixture()
        {
            Players = new List<string>();
        }

        public List<string> Players { get; private set; }

        public bool CanBeConsideredSameAs(Fixture other)
        {
            return (other.School == this.School)
                   && (other.Kickoff.Value.Date == this.Kickoff.Value.Date)
                   && (other.Team == this.Team)
                   && (other.Sport == this.Sport);
        }

        public override string ToString()
        {
            return string.Format("Fixture: {0}, {1}, {2}, {3}, {4}, {5}, {6}", Sport, School, Team, HomeAway, Venue, Kickoff, Link);
        }
    }
}