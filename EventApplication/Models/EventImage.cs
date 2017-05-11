using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventApplication.Models
{
    public class EventImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventImageId { get; set; }
        [Required]
        public string ImagePath { get; set; }
        [Required]
        public int EventId { get; set; }

        public Event Event { get; set; }
    }
}
