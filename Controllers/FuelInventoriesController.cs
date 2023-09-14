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
    public class FuelInventoriesController : ControllerBase
    {
        private readonly FuelManagementSystemContext _context;

        public FuelInventoriesController(FuelManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/FuelInventories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuelInventory>>> GetFuelInventories()
        {
          if (_context.FuelInventories == null)
          {
              return NotFound();
          }
            return await _context.FuelInventories.ToListAsync();
        }

        // GET: api/FuelInventories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FuelInventory>> GetFuelInventory(int id)
        {
          if (_context.FuelInventories == null)
          {
              return NotFound();
          }
            var fuelInventory = await _context.FuelInventories.FindAsync(id);

            if (fuelInventory == null)
            {
                return NotFound();
            }

            return fuelInventory;
        }

        // PUT: api/FuelInventories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFuelInventory(int id, FuelInventory fuelInventory)
        {
            if (id != fuelInventory.Fuelid)
            {
                return BadRequest();
            }

            _context.Entry(fuelInventory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FuelInventoryExists(id))
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

        // POST: api/FuelInventories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FuelInventory>> PostFuelInventory(FuelInventory fuelInventory)
        {
          if (_context.FuelInventories == null)
          {
              return Problem("Entity set 'FuelManagementSystemContext.FuelInventories'  is null.");
          }
            _context.FuelInventories.Add(fuelInventory);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FuelInventoryExists(fuelInventory.Fuelid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFuelInventory", new { id = fuelInventory.Fuelid }, fuelInventory);
        }

        // DELETE: api/FuelInventories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFuelInventory(int id)
        {
            if (_context.FuelInventories == null)
            {
                return NotFound();
            }
            var fuelInventory = await _context.FuelInventories.FindAsync(id);
            if (fuelInventory == null)
            {
                return NotFound();
            }

            _context.FuelInventories.Remove(fuelInventory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FuelInventoryExists(int id)
        {
            return (_context.FuelInventories?.Any(e => e.Fuelid == id)).GetValueOrDefault();
        }
    }
}
