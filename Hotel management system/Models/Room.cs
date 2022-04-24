using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models
{
    public class Room
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }

        //Navigation Properties 

        public List<HotelRoom> HotelRoom { get; set; }
        public List<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}

