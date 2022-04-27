using Hotel_management_system.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Interfaces
{
    public interface IAmenity
    {
        Task<AmenityDTO> CreateAmenity(AmenityDTO amenity);
        Task<AmenityDTO> GetAmenity(int Id);
        Task<List<AmenityDTO>> GetAmenities();
        Task<AmenityDTO> UpdateAmenity(int Id, AmenityDTO amenity);
        Task DeleteAmenity(int Id);
    }
}
