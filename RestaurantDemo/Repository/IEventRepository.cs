using EventApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventApplication.Repository
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAll();
        Event Find(int eventId);
    }
}
