using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Amenities
    {
        // Amenities fields
        public int ID { get; set; }
        public string Name { get; set; }

        // Navigation Properties
        public ICollection<RoomAmenities> RoomAmenities { get; set; }
    }
}
