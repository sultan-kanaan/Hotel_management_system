using Hotel_management_system.Data;
using Hotel_management_system.Models.DTOs;
using Hotel_management_system.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private readonly AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
       
        
        public async Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoom)
        {
            HotelRoom newHotelRoom = new HotelRoom
            {
                HotelID = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomID = hotelRoom.RoomID
            };
            _context.Entry(newHotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;

        }

        public async Task DeleteHotelRoom(int hotelId, int roomNumber)
        {
            HotelRoom HotelRoom = await _context.HotelRooms.FindAsync(hotelId, roomNumber);
            _context.Entry(HotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
        {
            return await _context.HotelRooms.Select(hr => new HotelRoomDTO()
            {
                HotelID = hr.HotelID,
                RoomNumber = hr.RoomNumber,
                Rate = hr.Rate,
                PetFriendly = hr.PetFriendly,
                RoomID = hr.RoomID,
                Room = new RoomDTO()
                {
                    ID = hr.Room.ID,
                    Name = hr.Room.Name,
                    Layout = hr.Room.Layout,
                    Amenities = hr.Room.RoomAmenities
                 .Select(ra => new AmenityDTO()
                 {
                     ID = ra.Amenities.ID,
                     Name = ra.Amenities.Name
                 }).ToList()
                }
            }).FirstOrDefaultAsync(x => x.HotelID == hotelId && x.RoomNumber == roomNumber);
        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            return await _context.HotelRooms.Select(hr => new HotelRoomDTO()
            {
                HotelID = hr.HotelID,
                RoomNumber = hr.RoomNumber,
                Rate = hr.Rate,
                PetFriendly = hr.PetFriendly,
                RoomID = hr.RoomID,
                Room = new RoomDTO()
                {
                    ID = hr.Room.ID,
                    Name = hr.Room.Name,
                    Layout = hr.Room.Layout,
                    Amenities = hr.Room.RoomAmenities
                 .Select(ra => new AmenityDTO()
                 {
                     ID = ra.Amenities.ID,
                     Name = ra.Amenities.Name
                 }).ToList()
                }
            }).ToListAsync();
                               
        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(HotelRoomDTO hotelRoom)
        {
            HotelRoom updateHotelRoom = new HotelRoom
            {
                HotelID = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                Rate = hotelRoom.Rate,
                PetFriendly = hotelRoom.PetFriendly,
                RoomID = hotelRoom.RoomID
            };
            _context.Entry(updateHotelRoom).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
        public async Task AddRoomToHotel(int roomId, int hotelId, int roomNumber, decimal rate, bool petFriendly)
        {
            HotelRoom HotelRoom = new HotelRoom()
            {
                RoomID = roomId,
                HotelID = hotelId,
                RoomNumber = roomNumber,
                Rate = rate,
                PetFriendly = petFriendly,
                Room = await _context.Rooms.FirstOrDefaultAsync(r => r.ID == roomId),
                Hotel = await _context.Hotels.FirstOrDefaultAsync(h => h.ID == hotelId)

            };

            _context.Entry(HotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

    }
}
