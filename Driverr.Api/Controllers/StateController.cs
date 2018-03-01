using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Driverr.Api.Enums;
using Driverr.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Driverr.Api.Controllers
{
    [Route("api/[controller]")]
    public class StateController : Controller
    {
        private readonly DrivrrContext _context;

        public StateController(DrivrrContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<State> GetAll()
        {
            return _context.States.ToList();
        }

        [HttpGet("{id}", Name = "GetState")]
        public IActionResult GetById(Guid id)
        {
            var item = _context.States.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] State item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.States.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetState", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] State item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var State = _context.States.FirstOrDefault(t => t.Id == id);
            if (State == null)
            {
                return NotFound();
            }
            
            //State.Id = item.Id;
            State.Name = item.Name;
            State.Abbrev = item.Abbrev;
            State.Type = item.Type;


            _context.States.Update(State);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var State = _context.States.FirstOrDefault(t => t.Id == id);
            if (State == null)
            {
                return NotFound();
            }

            _context.States.Remove(State);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}