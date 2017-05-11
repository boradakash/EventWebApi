using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventApplication.Models;
using EventApplication.Repository;
using EventApplication.ViewModels;
using System.IO;


namespace EventApplication.Controllers
{
    [Produces("application/json")]
    [Route("api/Event")]
    public class EventController : Controller
    {
        private readonly IEventRepository _IEventRepository;

        public EventController(IEventRepository IEventRepository)
        {
            _IEventRepository = IEventRepository;
        }
        [HttpGet]
        public List<EventModel> GetAll()
       {
            var allEvents= _IEventRepository.GetAll();
            List<EventModel> allEventList = new List<EventModel>();
            foreach(var e in allEvents)
            {
                EventModel model = new EventModel();
                model.EventId = e.EventId;
                model.EventName = e.Name;
               // string path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\EventImages\"}";
                model.ImageName = e.EventImages.FirstOrDefault().ImagePath;
                model.StartDate = e.EventDates.FirstOrDefault().StartDate;
                model.EndDate = e.EventDates.LastOrDefault().EndDate;
                model.TotalParticipant = e.EventDates.Select(p=>p.EventDateParticipants).Count();
                allEventList.Add(model);
            }
            return allEventList.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _IEventRepository.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}