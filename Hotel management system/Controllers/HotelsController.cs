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
    public class HotelsController : ControllerBase
    {
        private readonly IHotel _hotel;

        public HotelsController(IHotel hotel)
        {
            _hotel = hotel;
        }

        // GET: api/Hotels
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotels()
        {
            var hotel = await _hotel.GetHotels();
            return Ok(hotel);
        }

        // GET: api/Hotels/5
        [Authorize(Policy = "See Hotels")]
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
                var hotel = await _hotel.GetHotel(id);

            return Ok(hotel);

        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Policy = "Update Hotel")]
        public async Task<IActionResult> PutHotel(int id, HotelDTO hotel)
        {
            if (id != hotel.ID)
            {
                return BadRequest();
            }
            var updatedHotel = await _hotel.UpdateHotel(id, hotel);
            return Ok(updatedHotel);
        }

        // POST: api/Hotels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "Create Hotel")]
        public async Task<ActionResult<Hotel>> PostHotel(HotelDTO hotel)
        {
            await _hotel.CreateHotel(hotel);
            return CreatedAtAction("GetHotel", new { id = hotel.ID }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Delete Hotel")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            await _hotel.DeleteHotel(id);
            return NoContent();
        }

       
    }
}
