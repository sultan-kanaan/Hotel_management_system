using Hotel_management_system.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoomDTO> CreateHotelRoom(HotelRoomDTO hotelRoom);
        Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber);
        Task<List<HotelRoomDTO>> GetHotelRooms();
        Task<HotelRoomDTO> UpdateHotelRoom(HotelRoomDTO hotelRoom);
        Task DeleteHotelRoom(int hotelId, int roomNumber);
        Task AddRoomToHotel(int roomId, int hotelId, int roomNumber, decimal rate, bool petFriendly);



    }
}
