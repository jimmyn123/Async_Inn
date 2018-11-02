using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class HotelService : IHotel
    {
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public Task CreateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Hotel> GetHotel(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        public Task UpdateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
