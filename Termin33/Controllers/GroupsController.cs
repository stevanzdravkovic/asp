using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Termin33.DataAccess;
using Termin33.DataAccess.Entities;
using Group = Termin33.DataAccess.Entities.Group;

namespace Termin33.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly Termin33Context _context;

        public GroupsController() //konstruktor
        {
            _context = new Termin33Context();
        }


        // GET: api/Groups
        [HttpGet]
        public IActionResult Get()
        {

            var groups = _context.Groups.ToList();

            return Ok(groups);    
        }

        // GET: api/Groups/5
        [HttpGet("{id}", Name = "Get1")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Groups
        [HttpPost]
        public void Post([FromBody] GroupDto dto)
        {
            var group = new Group
            {
               
                Name = dto.Name
            };

            _context.Groups.Add(group); //EntityState.added
            _context.SaveChanges();
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] GroupDto dto)
        {
            var group = _context.Groups.Find(id);

            if(group == null)
            {
                return NotFound();
            }
            group.Name = dto.Name;

            try
            {
                _context.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var group = _context.Groups.Find(id);

            if(group == null)
            {
                return NotFound();
            }

            try
            {
                group.IsDeleted = true;
                group.DeletedAt = DateTime.Now;

                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }

    public class GroupDto
    {
        public string Name { get; set; }
    }
}
