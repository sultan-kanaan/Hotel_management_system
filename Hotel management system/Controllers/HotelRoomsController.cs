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
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _HotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _HotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom()
        {
            return Ok(await _HotelRoom.GetHotelRooms());

           
        }

        // GET: api/HotelRooms/5
        [HttpGet("{roomNumber}")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetHotelRooms(int hotelId, int roomNumber)
        {
            var hotelroom = await _HotelRoom.GetHotelRoom(hotelId, roomNumber);

            if (hotelroom == null)
            {
                return NotFound();
            }

            return Ok(hotelroom);
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{roomNumber}")]
        [Authorize(Policy = "Update HotelRooms")]
        public async Task<IActionResult> PutHotelRoom(HotelRoomDTO hotelRoom)
        {

            var updatedHotelRoom = await _HotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updatedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Policy = "Create HotelRooms")]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom)
        {
            return Ok(await _HotelRoom.CreateHotelRoom(hotelRoom));
        }


        // DELETE: api/HotelRooms/5
        [HttpDelete("{roomNumber}")]
        [Authorize(Policy = "Delete HotelRooms")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelid, int roomNumber)
        {
            await _HotelRoom.DeleteHotelRoom(hotelid, roomNumber);
            return NoContent();
        }
        [HttpPost("{roomNumber}")]
        [Authorize(Policy = "Add Room To Hotel")]
        public async Task<IActionResult> AddRoomToHotel(int hotelId, int roomId, int roomNumber, decimal rate, bool petFriendly)
        {
            await _HotelRoom.AddRoomToHotel(hotelId, roomId, roomNumber, rate, petFriendly);
            return NoContent();
        }
        [HttpDelete]
        [Route("Hotels/{hotelId}/Rooms/{roomNumber}")]
        [Authorize(Policy = "removes a room from a hotel")]
        public async Task<IActionResult> DeleteRoomFromHotel(int roomNumber, int hotelId)
        {
            await _HotelRoom.RemoveRoomFromHotel(roomNumber, hotelId);
            return NoContent();
        }

    }
}
