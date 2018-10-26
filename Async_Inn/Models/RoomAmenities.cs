using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class RoomAmenities
    {
        // RoomAmenities fields
        public int AmenitiesID { get; set; }
        public int RoomID { get; set; }

        // Navigation properties
        public Amenities Amenities { get; set; }
        public Room Room { get; set; }
    }
}
