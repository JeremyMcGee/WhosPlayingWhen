using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class School
    {
        public School()
        {
            Fixtures = new List<Fixture>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Fixture> Fixtures { get; set; }
    }
}