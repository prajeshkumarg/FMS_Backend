using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMS_Backend.FMSModels;

namespace FMS_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelLocationsController : ControllerBase
    {
        private readonly FuelManagementSystemContext _context;

        public FuelLocationsController(FuelManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/FuelLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelLocation>>> GetFuelLocations()
        {
          if (_context.FuelLocations == null)
          {
              return NotFound();
          }
            return await _context.FuelLocations.ToListAsync();
        }

        // GET: api/FuelLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuelLocation>> GetFuelLocation(int id)
        {
          if (_context.FuelLocations == null)
          {
              return NotFound();
          }
            var fuelLocation = await _context.FuelLocations.FindAsync(id);

            if (fuelLocation == null)
            {
                return NotFound();
            }

            return fuelLocation;
        }

        // PUT: api/FuelLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuelLocation(int id, FuelLocation fuelLocation)
        {
            if (id != fuelLocation.Locid)
            {
                return BadRequest();
            }

            _context.Entry(fuelLocation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelLocationExists(id))
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

        // POST: api/FuelLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FuelLocation>> PostFuelLocation(FuelLocation fuelLocation)
        {
          if (_context.FuelLocations == null)
          {
              return Problem("Entity set 'FuelManagementSystemContext.FuelLocations'  is null.");
          }
            _context.FuelLocations.Add(fuelLocation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFuelLocation", new { id = fuelLocation.Locid }, fuelLocation);
        }

        // DELETE: api/FuelLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuelLocation(int id)
        {
            if (_context.FuelLocations == null)
            {
                return NotFound();
            }
            var fuelLocation = await _context.FuelLocations.FindAsync(id);
            if (fuelLocation == null)
            {
                return NotFound();
            }

            _context.FuelLocations.Remove(fuelLocation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuelLocationExists(int id)
        {
            return (_context.FuelLocations?.Any(e => e.Locid == id)).GetValueOrDefault();
        }
    }
}
