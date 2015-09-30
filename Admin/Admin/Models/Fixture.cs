using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class Fixture
    {
        public Fixture()
        {
            Children = new List<Child>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Kickoff { get; set; }

        public virtual School School { get; set; }

        public virtual ICollection<Child> Children { get; set; }

        public string Url { get; set; }
    }
}