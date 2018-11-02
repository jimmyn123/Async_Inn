using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IAmenities
    {
        // required methods for the IAmenities interface
        Task CreateAmenity(Amenities amenity);
        Task<Amenities> GetAmenity(int? id);
        Task<IEnumerable<Amenities>> GetAmenities();
        Task DeleteAmenity(int id);
    }
}
