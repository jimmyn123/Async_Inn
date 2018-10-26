using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models
{
    public class Hotel
    {
        // Hotel fields
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
