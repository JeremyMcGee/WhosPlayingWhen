using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Admin.Models
{
    public partial class Child
    {
        public Child()
        {
            PlayingStatuses = new List<PlayingStatus>();
        }

        [Key]
        public int Id { get; set; }

        public string ChildName { get; set; }

        public virtual ICollection<PlayingStatus> PlayingStatuses { get; set; }
    }
}