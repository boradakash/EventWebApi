using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace EventApplication.Models
{
    public class EventContext:DbContext
    {
        public EventContext(DbContextOptions<EventContext> options) : base(options)
        {

        }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        public DbSet<EventDate> EventDates { get; set; }
        public DbSet<EventDateParticipant> EventDateParticipants { get; set; }
        public DbSet<EventDescription> EventDescriptions { get; set; }
        public DbSet<Participant> Participants{ get; set; }
    }
}
