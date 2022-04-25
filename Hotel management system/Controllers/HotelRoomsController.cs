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

namespace Hotel_management_system.Controllers
{
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
        [HttpGet("{hotelId}")]
        [Route("Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            var hotelroom = await _HotelRoom.GetHotelRooms(hotelId);
            return Ok(hotelroom);
        }

        // GET: api/HotelRooms/5
        [HttpGet]
        [Route("Hotels/{hotelId}/Rooms/{roomNumber}")]

        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelid, int roomNumber)
        {
            var hotelroom = await _HotelRoom.GetHotelRoom(hotelid, roomNumber);

            if (hotelroom == null)
            {
                return NotFound();
            }

            return hotelroom;
        }

        // PUT: api/HotelRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(HotelRoom hotelRoom)
        {

            var updatedHotelRoom = await _HotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updatedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            await _HotelRoom.CreateHotelRoom(hotelRoom);
            return CreatedAtAction("GetHotelRoom", new { Hotelid = hotelRoom.HotelID, RoomId = hotelRoom.RoomID, RoomNumber = hotelRoom.RoomNumber, PetFriendly = hotelRoom.PetFriendly, Rate = hotelRoom.Rate, Room = hotelRoom.Room, Hotel = hotelRoom.Hotel }, hotelRoom);
        }


        // DELETE: api/HotelRooms/5
        [HttpDelete("{id}")]
        [Route("Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelid, int roomNumber)
        {
            await _HotelRoom.DeleteHotelRoom(hotelid, roomNumber);
            return NoContent();
        }

        //adds a room to a hotel
        [HttpPost]
        [Route("Hotels/{hotelId}/Rooms")]
        public async Task<IActionResult> AddRoomToHotel(int hotelId, int roomId)
        {
            await _HotelRoom.AddRoomToHotel(hotelId, roomId);
            await _HotelRoom.AddRoomToHotel(hotelId, roomId);
            return NoContent();
        }
        //removes a room from a hotel
        [HttpDelete]
        [Route("Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> DeleteRoomFromHotel(int roomNumber, int hotelId)
        {
            await _HotelRoom.RemoveRoomFromHotel(roomNumber, hotelId);
            return NoContent();
        }
    }
}
