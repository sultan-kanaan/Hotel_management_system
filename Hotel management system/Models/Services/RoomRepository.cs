using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel_management_system.Models;
using Hotel_management_system.Data;
using Hotel_management_system.Models.Interfaces;

namespace Room_management_system.Models.Services
{
    public class RoomRepository :IRoom 
    {
        private readonly AsyncInnDbContext _context;

        public RoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Room> CreateRoom(Room room)
        {
            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task DeleteRoom(int Id)
        {
            Room room = await GetRoom(Id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


        public async Task<Room> GetRoom(int Id)
        {
            Room room = await _context.Rooms.FindAsync(Id);

            var roomAmenities = await _context.RoomAmenities
                .Where(r => r.RoomID == Id)
                .Include(a => a.Amenities)
                .ToListAsync();

            room.RoomAmenities = roomAmenities;

            return room;
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;

        }

       
        public async Task<Room> UpdateRoom(int ID,Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        //logic to add and remove amenities from rooms

        public async Task<Room> AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomID = roomId,
                AmenitiesID = amenityId
            };

            _context.Entry(roomAmenity).State = EntityState.Added;

            await _context.SaveChangesAsync();

            var AddAmenity = await GetRoom(roomId);

            return AddAmenity;

        }

        public async Task RemoveAmentityFromRoom(int roomId, int amenityId)
        {
            RoomAmenities roomAmenities = await _context.RoomAmenities.Where(x => x.AmenitiesID == amenityId).FirstOrDefaultAsync();

            _context.Entry(roomAmenities).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
