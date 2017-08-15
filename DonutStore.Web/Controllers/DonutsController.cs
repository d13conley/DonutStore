using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DonutStore.Data.Models;

namespace DonutStore.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Donuts")]
    public class DonutsController : Controller
    {
        private readonly DonutStoreContext _context;

        public DonutsController(DonutStoreContext context)
        {
            _context = context;
        }

        // GET: api/Donuts
        [HttpGet]
        public IEnumerable<Donuts> GetDonuts()
        {
            return _context.Donuts;
        }

        // GET: api/Donuts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDonuts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donuts = await _context.Donuts.SingleOrDefaultAsync(m => m.DonutId == id);

            if (donuts == null)
            {
                return NotFound();
            }

            return Ok(donuts);
        }

        // PUT: api/Donuts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonuts([FromRoute] int id, [FromBody] Donuts donuts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donuts.DonutId)
            {
                return BadRequest();
            }

            _context.Entry(donuts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonutsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Donuts
        [HttpPost]
        public async Task<IActionResult> PostDonuts([FromBody] Donuts donuts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Donuts.Add(donuts);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonuts", new { id = donuts.DonutId }, donuts);
        }

        // DELETE: api/Donuts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonuts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var donuts = await _context.Donuts.SingleOrDefaultAsync(m => m.DonutId == id);
            if (donuts == null)
            {
                return NotFound();
            }

            _context.Donuts.Remove(donuts);
            await _context.SaveChangesAsync();

            return Ok(donuts);
        }

        private bool DonutsExists(int id)
        {
            return _context.Donuts.Any(e => e.DonutId == id);
        }
    }
}