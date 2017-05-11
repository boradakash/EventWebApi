using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApplication.ViewModels
{
    public class EventModel
    {
        public int EventId { get; set; }
        public string ImageName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
        public int TotalParticipant { get; set; }
    }
}
