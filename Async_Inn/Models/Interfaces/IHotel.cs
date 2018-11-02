using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IHotel
    {
        // required methods for the IHotel interface
        Task CreateHotel(Hotel hotel);
        Task UpdateHotel(Hotel hotel);
        Task<Hotel> GetHotel(int? id);
        Task<IEnumerable<Hotel>> GetHotels();
        Task DeleteHotel(int id);
    }
}
