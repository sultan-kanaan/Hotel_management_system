using Hotel_management_system.Models;
using Hotel_management_system.Models.DTOs;
using Hotel_management_system.Models.Services;
using Room_management_system.Models.Services;
using System.Threading.Tasks;
using Xunit;

namespace HotelManagementSystemTest
{
    public class HotelTest : Mock
    {
        [Fact]
        public async Task Can_enroll_and_drop_a_Hotel()
        {
            // Arrange
            var room = await CreateAndSaveTestRoom();
            var amenity = await CreateAndSaveTestAmenity();

            var Repository = new RoomRepository(_db);

            // Act
            await Repository.AddAmenityToRoom(room.ID,amenity.ID);

            // Assert
            var actualRoom = await Repository.GetRoom(room.ID);

            Assert.Contains(actualRoom.Amenities, a => a.ID == amenity.ID);

            // Act
            await Repository.RemoveAmentityFromRoom(room.ID, amenity.ID);

            // Assert
            actualRoom = await Repository.GetRoom(room.ID);

            Assert.DoesNotContain(actualRoom.Amenities, a => a.ID == amenity.ID);
        }
    }
}
