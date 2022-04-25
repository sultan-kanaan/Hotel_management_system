using Hotel_management_system.Data;
using Hotel_management_system.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.Services
{
    public class AmenityRepository : IAmenity
    {
        private AsyncInnDbContext _context;

        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }
        public async Task<Amenity> CreateAmenity(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return amenity;
        }

        public async Task DeleteAmenity(int Id)
        {
            Amenity amenity = await GetAmenity(Id);
            _context.Entry(amenity).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenity = await _context.Amenities.Include(a => a.RoomAmenities).ToListAsync();
            return amenity ;
        }

        public async Task<Amenity> GetAmenity(int Id)
        {
            Amenity amenity = await _context.Amenities.FindAsync(Id);
            var roomAmenities = await _context.RoomAmenities
                .Where(r => r.RoomID == Id)
                .Include(a => a.Amenities)
                .ThenInclude(a => a.RoomAmenities)
                .ToListAsync();
            amenity.RoomAmenities = roomAmenities;
            return amenity;
        }

        public async Task<Amenity> UpdateAmenity(int Id, Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
