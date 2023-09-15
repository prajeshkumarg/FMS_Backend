using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FMS_Backend.FMSModels;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

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
        [Authorize(Roles ="Admin")]
        public async Task<ActionResult<IEnumerable<TripDetail>>> GetTripDetails()
        {
          if (_context.TripDetails == null)
          {
              return NotFound();
          }
            return await _context.TripDetails.ToListAsync();
        }

        // GET: api/TripDetails/5
        [HttpGet("{token}")]
        //[Route("tripDetails/{token}")]
        public async Task<ActionResult<List<TripDetail>>> ShowTripDetail(string token)
        {
          if (_context.TripDetails == null)
          {
              return NotFound();
          }
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadJwtToken(token);

            var claims = jwtToken.Claims;
            var uid = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")?.Value;
            int id = int.Parse(uid);
            //var vehicle = await _context.Vehicles.FindAsync(id);
            var tripDetail = _context.TripDetails.FirstOrDefault(x => x.Userid == id);
            List<TripDetail> tdL = _context.TripDetails.Where(x => x.Userid == id).ToList();

            if (tripDetail == null)
            {
                return NotFound();
            }

            return tdL;
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
        [Route("addTripDetail")]
        public async Task<ActionResult<TripDetail>> AddTripDetail(TripDetail tripDetail)
        {
          if (_context.TripDetails == null)
          {
              return Problem("Entity set 'FuelManagementSystemContext.TripDetails'  is null.");
          }
            tripDetail.Tripmileage = (tripDetail.Odometerend - tripDetail.Odometerstart) / (tripDetail.Fuelstart - tripDetail.Fuelend);
            _context.TripDetails.Add(tripDetail);
            try
            {
                //_context.TripDetails.ExecuteUpdate(s => s.SetProperty(e => e.Tripmileage, e => (e.Odometerend - e.Odometerstart)/(e.Fuelend-e.Fuelstart)));
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {

            }

            return Ok("Successfully Added");
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
