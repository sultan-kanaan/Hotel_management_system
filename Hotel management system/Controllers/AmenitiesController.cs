using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_management_system.Data;
using Hotel_management_system.Models;
using Hotel_management_system.Models.Interfaces;
using Hotel_management_system.Models.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Hotel_management_system.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {
        private readonly IAmenity _amenity;

        public AmenitiesController(IAmenity amenity)
        {
            _amenity = amenity;
        }

        // GET: api/Amenities
        [HttpGet]
       [Authorize(Policy = "See Amenities")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AmenityDTO>>> GetAmenities()
        {
            return Ok( await _amenity.GetAmenities());
        }

        // GET: api/Amenities/5
        [HttpGet("{id}")]
        [Authorize(Roles = "See_Amenities")]
        [AllowAnonymous]
        public async Task<ActionResult<AmenityDTO>> GetAmenity(int id)
        {
            var amenity = await _amenity.GetAmenity(id);
           
            if (amenity == null)
            {
                return NotFound();
            }

            return Ok(amenity);
        }

        // PUT: api/Amenities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "Update Amenity")]
        public async Task<IActionResult> PutAmenity(int id, AmenityDTO amenity)
        {
            if (id != amenity.ID)
            {
                return BadRequest();
            }
            var updatedAmenity = await _amenity.UpdateAmenity(id, amenity);
            return Ok(updatedAmenity);
        }

        // POST: api/Amenities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "Create Amenity")]
        public async Task<ActionResult<AmenityDTO>> PostAmenity(AmenityDTO amenity)
        {
            await _amenity.CreateAmenity(amenity);
            return CreatedAtAction("GetAmenity", new { id = amenity.ID }, amenity);
        }

        // DELETE: api/Amenities/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Delete Amenity")]
        public async Task<IActionResult> DeleteAmenity(int id)
        {
            await _amenity.DeleteAmenity(id);
            return NoContent();
        }
    }
}
