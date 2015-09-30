using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class Child
    {
        public Child()
        {
            Fixtures = new List<Fixture>();
        }

        [Key]
        public int Id { get; set; }

        public string ChildName { get; set; }

        public virtual ICollection<Fixture> Fixtures { get; set; }

        public void RecordPlayingStatus(PlayingStatus playingStatus)
        {
        }

        public void InformParentOfPlayingStatus()
        {
        }
    }
}