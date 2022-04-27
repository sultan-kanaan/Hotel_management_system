using Hotel_management_system.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> CreateRoom(RoomDTO room);
        Task<RoomDTO> GetRoom(int Id);
        Task<List<RoomDTO>> GetRooms();
        Task<RoomDTO> UpdateRoom(int ID, RoomDTO room);
        Task DeleteRoom(int Id);
        Task AddAmenityToRoom(int roomId, int amenityId);
        Task RemoveAmentityFromRoom(int roomId, int amenityId);

    }
}
