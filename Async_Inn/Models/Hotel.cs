using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Hotel
    {
        // Hotel fields
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(150)]
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }

        // Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
    }
}
