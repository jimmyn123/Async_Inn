using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Room
    {
        // Room fields
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }

        // Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<Amenities> RoomAmenities { get; set; }
    }

    // enum for layouts
    public enum Layout
    {
        Studio,
        OneBedroom,
        TwoBedroom
    }
}
