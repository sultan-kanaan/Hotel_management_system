using System;
using Xunit;
using Hotel_management_system;
using Hotel_management_system.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Hotel_management_system.Models;
using Hotel_management_system.Models.Services;

using System.Threading.Tasks;

namespace HotelManagementSystemTest
{
    public abstract class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        protected readonly AsyncInnDbContext _db;

        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new AsyncInnDbContext(
                new DbContextOptionsBuilder<AsyncInnDbContext>()
                    .UseSqlite(_connection)
                    .Options);

            _db.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
        protected async Task<Amenity> CreateAndSaveTestAmenity()
        {
            var amenity = new Amenity { ID = 5, Name = "sawna"};
            _db.Amenities.Add(amenity);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, amenity.ID); 
            return amenity;
        }

        protected async Task<Room> CreateAndSaveTestRoom()
        {
            var room = new Room { ID = 5, Name = "cozy studio", Layout = 0 };
            _db.Rooms.Add(room);
            await _db.SaveChangesAsync();
            Assert.NotEqual(0, room.ID);
            return room;
        }
    }
}
