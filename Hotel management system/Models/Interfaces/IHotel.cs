using Hotel_management_system.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Interfaces
{
    public interface IHotel
    {
        Task<HotelDTO> CreateHotel(HotelDTO hotel);
        Task<HotelDTO> GetHotel(int Id);
        Task<List<HotelDTO>> GetHotels();
        Task<HotelDTO> UpdateHotel(int Id, HotelDTO hotel);
        Task DeleteHotel(int Id);
    }
}
