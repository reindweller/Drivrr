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
    public class SuburbController : Controller
    {
        private readonly DrivrrContext _context;

        public SuburbController(DrivrrContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Suburb> GetAll()
        {
            return _context.Suburbs.ToList();
        }

        [HttpGet("{id}", Name = "GetSuburb")]
        public IActionResult GetById(Guid id)
        {
            var item = _context.Suburbs.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Suburb item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Suburbs.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetSuburb", new { id = item.Id }, item);
        }

        [HttpGet("state/{id:guid}")]
        public IEnumerable<Suburb> GetByStateId(Guid id)
        {
            return _context.Suburbs.Where(o => o.StateId == id).ToList();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] Suburb item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }

            var Suburb = _context.Suburbs.FirstOrDefault(t => t.Id == id);
            if (Suburb == null)
            {
                return NotFound();
            }

            //Suburb.Id = item.Id;
            Suburb.Name = item.Name;
            Suburb.StateId = item.StateId;
            Suburb.PostCode = item.PostCode;


            _context.Suburbs.Update(Suburb);
            _context.SaveChanges();
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var Suburb = _context.Suburbs.FirstOrDefault(t => t.Id == id);
            if (Suburb == null)
            {
                return NotFound();
            }

            _context.Suburbs.Remove(Suburb);
            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}