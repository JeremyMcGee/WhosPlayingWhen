using System;
using System.Collections.Generic;

namespace Scanner
{
    public class Fixture
    {
        public string School { get; set; }

        public DateTime? Kickoff { get; set; }

        public string Team { get; set; }

        public string Sport { get; set; }

        public Fixture()
        {
            Players = new List<string>();
        }

        public List<string> Players { get; private set; }

        public bool CanBeConsideredSameAs(Fixture other)
        {
            return (other.School == this.School)
                   && (other.Kickoff == this.Kickoff)
                   && (other.Team == this.Team)
                   && (other.Sport == this.Sport);
        }
    }
}