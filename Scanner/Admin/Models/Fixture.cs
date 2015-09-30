using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class Fixture
    {
        public Fixture()
        {
            PlayingStatuses = new List<PlayingStatus>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Kickoff { get; set; }

        public virtual School HostSchool { get; set; }

        public virtual School Opponent { get; set; }

        public virtual ICollection<PlayingStatus> PlayingStatuses { get; set; }

        public string Url { get; set; }
    }
}