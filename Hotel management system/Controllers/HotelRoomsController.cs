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

namespace Hotel_management_system.Controllers
{
    [Produces("application/json")]
    //[Route("api/[controller]")]
    [Route("/api/Hotels/{hotelId}/Rooms")]
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
        public async Task<ActionResult<HotelRoomDTO>> GetHotelRoom()
        {
            return Ok(await _HotelRoom.GetHotelRooms());

           
        }

        // GET: api/HotelRooms/5
        [HttpGet("{roomNumber}")]
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
        public async Task<IActionResult> PutHotelRoom(HotelRoomDTO hotelRoom)
        {

            var updatedHotelRoom = await _HotelRoom.UpdateHotelRoom(hotelRoom);
            return Ok(updatedHotelRoom);
        }

        // POST: api/HotelRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelRoomDTO>> PostHotelRoom(HotelRoomDTO hotelRoom)
        {
            return Ok(await _HotelRoom.CreateHotelRoom(hotelRoom));
        }


        // DELETE: api/HotelRooms/5
        [HttpDelete("{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelid, int roomNumber)
        {
            await _HotelRoom.DeleteHotelRoom(hotelid, roomNumber);
            return NoContent();
        }

      
    }
}
