using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Interfaces
{
    public interface IHotel
    {
        Task<Hotel> CreateHotel(Hotel hotel);
        Task<Hotel> GetHotel(int Id);
        Task<List<Hotel>> GetHotels();
        Task<Hotel> UpdateHotel(int Id, Hotel hotel);
        Task DeleteHotel(int Id);
    }
}
