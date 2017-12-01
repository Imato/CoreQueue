using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class QueueController : Controller
    {
        IQueueRepository _repositiry;

        public QueueController(IQueueRepository _r)
        {
            _repositiry = _r;
        }

        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return _repositiry.GetQueue();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var r = _repositiry.GetTicket(id);
            if (r == null)
                return NotFound();

            return new ObjectResult(r);
        }

        [HttpPost]
        public IActionResult AddTicket([FromBody] Category c)
        {
            if (c == null ||
                    _repositiry.GetCategories().FirstOrDefault(x => x.Id == c.Id) == null)
                return BadRequest();

            var t = new Ticket()
            {
                Id = _repositiry.GetLastTicketId() + 1,
                Category = c.Id,
                CreateDate = DateTime.UtcNow,
                IsClosed = false
            };

            _repositiry.AddTicket(t);

            return CreatedAtRoute(new { id = t.Id }, t);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTicket(int id, [FromBody] Ticket t)
        {
            if (t == null || t.Id != id)
                return BadRequest();

            var f = _repositiry.GetTickets().FirstOrDefault(x => x.Id == id);
            if (f == null)
                return NotFound();

            _repositiry.AddTicket(t);

            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTicket(int id)
        {
            var f = _repositiry.GetTickets().FirstOrDefault(x => x.Id == id);
            if (f == null)
                return NotFound();
            f.IsClosed = true;
            _repositiry.AddTicket(f);

            return new NoContentResult();
        }
    }
}