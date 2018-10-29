using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class HotelRoom
    {
        // HotelRoom fields
        public int HotelID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomID { get; set; }
        [DataType(DataType.Currency)]
        public decimal Rate { get; set; }
        [Required]
        public bool PetFriendly { get; set; }

        // Navigation Properties
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
    }
}
