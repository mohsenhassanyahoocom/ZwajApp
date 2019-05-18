using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace ZwajApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;

        }
        // Get http://localhost:5000/api/values
        // GET api/values
        [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        public async Task<IActionResult> GetValues()
        {
            // throw new Exception("Test Exception");
            // return new string[] { "value1", "value2" };
            // return new string[] { "Amir", "Muhammad", "Ali" };
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

        // GET api/values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        public async Task<IActionResult> GetValue(int id)
        {
            // return "value";
            // return $"value {id}";
            var value = await _context.Values.FirstOrDefaultAsync(x => x.id == id);
            return Ok(value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
