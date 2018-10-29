using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Room
    {
        // Room fields
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public Layout Layout { get; set; }

        // Navigation Properties
        public ICollection<HotelRoom> HotelRoom { get; set; }
        public ICollection<Amenities> RoomAmenities { get; set; }
    }

    // enum for layouts
    public enum Layout
    {
        Studio,
        [Display(Name = "One Bedroom")]
        OneBedroom,
        [Display(Name = "Two Bedroom")]
        TwoBedroom
    }
}
