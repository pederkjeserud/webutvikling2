using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FindMusicianAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FindMusicianAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]

    public class EventController : ControllerBase
    {

        private readonly FindMusicianContext _context;

        public EventController(FindMusicianContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            List<Event> eventList = await _context.Event.ToListAsync();
            return eventList;
        }

        [HttpGet("{id}")]
        public async Task<Event> Get(int id)
        {
            Event selectedEvent = await _context.Event.FirstOrDefaultAsync(Event => Event.Id == id);
            return selectedEvent;
        }

        [HttpGet]
        [Route("[action]/{description}")]
        public async Task<IEnumerable<Event>> GetByDescription(string description)
        {
            List<Event> jobList = await _context.Event
                .Where(jobs => jobs.Description.ToLower()
                .Contains(description.ToLower()))
                .ToListAsync();
            return jobList;
        }

        [HttpPost]
        public async Task<Event> Post(Event newEvent){
            _context.Event.Add( newEvent );
            await _context.SaveChangesAsync();
            return newEvent;
        }

        // Metode for å redigere eksisterende oppdrag

        [HttpPut]
        public async Task<Event> Put(Event updatedEvent) {
            _context.Update( updatedEvent );
            await _context.SaveChangesAsync();
            return updatedEvent;
        }

        [HttpDelete("{id}")]
        public async Task<Event> Delete(int id)
        {
            Event jobToDelete = await _context.Event.FirstAsync(job => job.Id == id);
            _context.Event.Remove(jobToDelete);
            await _context.SaveChangesAsync();
            return jobToDelete;
        }

    }

}