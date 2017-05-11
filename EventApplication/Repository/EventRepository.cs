using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventApplication.Repository
{
    public class EventRepository: IEventRepository
    {
        private readonly EventContext _context;

        public EventRepository(EventContext context)
        {
            _context = context;
        }

        public IEnumerable<Event> GetAll()
        {
            return _context.Events.Include(i => i.EventImages)
                                   .Include(d => d.EventDates)
                                   .ThenInclude(p => p.EventDateParticipants);
        }
       
        public Event Find(int eventId)
        {
            return _context.Events.Include(i=>i.EventDescriptions)
                                  .Include(i=>i.EventImages)
                                  .Include(i=>i.EventDates)
                                  .ThenInclude(i=>i.EventDateParticipants)
                                  .ThenInclude(i=>i.Participant)
                                  .SingleOrDefault(i => i.EventId == eventId);
        }
    }
}
