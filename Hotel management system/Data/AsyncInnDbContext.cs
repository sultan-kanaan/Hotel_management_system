using Hotel_management_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }
        
        public DbSet<Amenity> Amenities { get; set; }
        
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //composite key associations
            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelID, x.RoomNumber });
            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.AmenitiesID, x.RoomID });


            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel { ID = 1, Name = "Async Inn-Amman", Address = "Amman",State= "jordan", Phone = "00962675355"},
                         new Hotel { ID = 2, Name = "Async Inn-Aqapa", Address = "Aqapa", State = "jordan", Phone = "00962675353"},
                         new Hotel { ID = 3, Name = "Async Inn-Deadsee",Address = "Deadsee", State = "jordan", Phone = "00962675351"}
                         );
            modelBuilder.Entity<Room>()
                .HasData(new Room { ID = 1, Name = "cozy studio", Layout = 0 },
                         new Room { ID = 2, Name = "one bedroom", Layout = 1 },
                         new Room { ID = 3, Name = "2 bedrooms", Layout = 2 }
                         );

            modelBuilder.Entity<Amenity>()
                .HasData(new Amenity { ID = 1, Name = "air conditioning" },
                         new Amenity { ID = 2, Name = "coffee maker" },
                         new Amenity { ID = 3, Name = "ocean view" },
                         new Amenity { ID = 4, Name = "mini bar" }
                         );
        }
    }
}
