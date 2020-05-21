using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Termin33.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        //pristupamo u postmanu ovako:   localhost:5000/api/test    na GET  naravno
        // GET: api/Test
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            { 
                Naziv = "vrednost"
            });  // vraca    http OK response - 200 u zagradi definisemo sta ce da pise
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "GetTest")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
