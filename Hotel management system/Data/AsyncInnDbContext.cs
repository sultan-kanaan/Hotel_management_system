using Hotel_management_system.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Hotel_management_system.Models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Hotel_management_system.Data
{
    public class AsyncInnDbContext : IdentityDbContext<ApplicationUser>
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {

        }

        public DbSet<Amenity> Amenities { get; set; }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }
        public DbSet<UserDTO> UserDTO { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Hotel>()
                .HasData(new Hotel { ID = 1, Name = "Async Inn-Amman", Address = "Amman", State = "jordan", Phone = "00962675355" },
                         new Hotel { ID = 2, Name = "Async Inn-Aqapa", Address = "Aqapa", State = "jordan", Phone = "00962675353" },
                         new Hotel { ID = 3, Name = "Async Inn-Deadsee", Address = "Deadsee", State = "jordan", Phone = "00962675351" }
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
            modelBuilder.Entity<RoomAmenities>()
                 .HasKey(RoomAmenity => new { RoomAmenity.RoomID, RoomAmenity.AmenitiesID });

            modelBuilder.Entity<HotelRoom>()
                        .HasKey(HotelRoomNumber => new { HotelRoomNumber.HotelID, HotelRoomNumber.RoomNumber });


            SeedRole(modelBuilder, "District Manager", "Create Hotel", "See Hotels", "Update Hotel", "Delete Hotel", 
                                   "Create HotelRoom", "See HotelRooms", "Update HotelRooms", "Delete HotelRooms", 
                                   "Create Rooms", "See Rooms", "Update Rooms", "Delete Rooms", "Create Amenity", 
                                   "See Amenities", "Add Amenity to Room", "Delete Amenity From Room", "Update Amenity", "Delete Amenity", 
                                   "Create Account for District Manager", "Create Account for Agent", "Create Account for Property Manager", "Create account for Anonymous User",
                                   "Add Room to Hotel");

            SeedRole(modelBuilder, "PropertyManager", "See Hotels", "Create HotelRoom", "See HotelRooms", "Update HotelRooms", 
                                   "See Rooms", "See Amenities", "Add Amenity to Room", "Delete Amenity From Room", "Update Amenity", 
                                   "Add Room to Hotel");

            SeedRole(modelBuilder, "Agent", "See HotelRooms", "Update HotelRooms", "See Amenities",
                                   "Add Amenity to Room", "Delete Amenity From Room");

            SeedRole(modelBuilder, "Anonymous", "See Hotels", "See HotelRooms", "See Rooms", "See Amenities");
        }

             private int nextId = 1; // we need this to generate a unique id on our own
        private void SeedRole(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.Empty.ToString()
            };

            modelBuilder.Entity<IdentityRole>().HasData(role);

            // Go through the permissions list (the params) and seed a new entry for each
            var roleClaims = permissions.Select(permission =>
            new IdentityRoleClaim<string>
            {
                Id = nextId++,
                RoleId = role.Id,
                ClaimType = "permissions", // This matches what we did in Startup.cs
                ClaimValue = permission
            }).ToArray();

            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(roleClaims);
        }

    }



}
