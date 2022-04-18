using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models
{
    public class RoomAmenities
    {
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }

        //Navigation Properties

        public Amenity Amenities { get; set; }
        public Room Room { get; set; }
    }
}
