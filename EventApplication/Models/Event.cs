using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventApplication.Models
{
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventId { get; set; }
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public ICollection<EventImage> EventImages{ get; set; }
        public ICollection<EventDescription> EventDescriptions { get; set; }
        public ICollection<EventDate> EventDates { get; set; }
    }
}
