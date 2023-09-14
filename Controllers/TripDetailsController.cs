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
    public class TripDetailsController : ControllerBase
    {
        private readonly FuelManagementSystemContext _context;

        public TripDetailsController(FuelManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/TripDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripDetail>>> GetTripDetails()
        {
          if (_context.TripDetails == null)
          {
              return NotFound();
          }
            return await _context.TripDetails.ToListAsync();
        }

        // GET: api/TripDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TripDetail>> GetTripDetail(int id)
        {
          if (_context.TripDetails == null)
          {
              return NotFound();
          }
            var tripDetail = await _context.TripDetails.FindAsync(id);

            if (tripDetail == null)
            {
                return NotFound();
            }

            return tripDetail;
        }

        // PUT: api/TripDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTripDetail(int id, TripDetail tripDetail)
        {
            if (id != tripDetail.Tripid)
            {
                return BadRequest();
            }

            _context.Entry(tripDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripDetailExists(id))
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

        // POST: api/TripDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TripDetail>> PostTripDetail(TripDetail tripDetail)
        {
          if (_context.TripDetails == null)
          {
              return Problem("Entity set 'FuelManagementSystemContext.TripDetails'  is null.");
          }
            _context.TripDetails.Add(tripDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TripDetailExists(tripDetail.Tripid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTripDetail", new { id = tripDetail.Tripid }, tripDetail);
        }

        // DELETE: api/TripDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTripDetail(int id)
        {
            if (_context.TripDetails == null)
            {
                return NotFound();
            }
            var tripDetail = await _context.TripDetails.FindAsync(id);
            if (tripDetail == null)
            {
                return NotFound();
            }

            _context.TripDetails.Remove(tripDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripDetailExists(int id)
        {
            return (_context.TripDetails?.Any(e => e.Tripid == id)).GetValueOrDefault();
        }
    }
}
