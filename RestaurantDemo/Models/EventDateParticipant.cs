using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EventApplication.Models
{
    public class EventDateParticipant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EventDateParticipantId { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [Required]
        public int EventDateId { get; set; }

        public EventDate EventDate { get; set; }

        public Participant Participant { get; set; }
    }
}
