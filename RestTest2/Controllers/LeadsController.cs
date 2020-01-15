using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestTest2.Models;

namespace RestTest2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadController : ControllerBase
    {
        LeadsContext db;
        public LeadController(LeadsContext context)
        {
            db = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> Get()
        {
            return await db.Lead.ToListAsync();
        }

        // GET api/lead/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> Get(long id)
        {
            Lead lead = await db.Lead.FirstOrDefaultAsync(x => x.Id == id);
            if (lead == null)
                return NotFound();
            return new ObjectResult(lead);
        }

        // POST api/lead
        [HttpPost]
        public async Task<ActionResult<Lead>> Post(Lead lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }

            db.Lead.Add(lead);
            await db.SaveChangesAsync();
            return Ok(lead);
        }

        // PUT api/leads/
        [HttpPut]
        public async Task<ActionResult<Lead>> Put(Lead lead)
        {
            if (lead == null)
            {
                return BadRequest();
            }
            if (!db.Lead.Any(x => x.Id == lead.Id))
            {
                return NotFound();
            }

            db.Update(lead);
            await db.SaveChangesAsync();
            return Ok(lead);
        }

        // DELETE api/leads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Lead>> Delete(long id)
        {
            Lead lead = db.Lead.FirstOrDefault(x => x.Id == id);
            if (lead == null)
            {
                return NotFound();
            }
            db.Lead.Remove(lead);
            await db.SaveChangesAsync();
            return Ok(lead);
        }
    }
}