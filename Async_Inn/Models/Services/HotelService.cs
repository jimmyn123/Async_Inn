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
        // db context for the service
        private AsyncInnDbContext _context;

        public HotelService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates the hotel
        /// </summary>
        /// <param name="hotel">the hotel to create</param>
        /// <returns></returns>
        public async Task CreateHotel(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the hotel
        /// </summary>
        /// <param name="id">The id of the hotel to delete</param>
        /// <returns></returns>
        public async Task DeleteHotel(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Remove(hotel);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns a list of all the hotels
        /// </summary>
        /// <returns>The list of hotels</returns>
        public async Task<Hotel> GetHotel(int? id)
        {
            return await _context.Hotels.FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Gets one specific hotel
        /// </summary>
        /// <param name="id">The id of the hotel to return</param>
        /// <returns>The actual hotel with the id</returns>
        public async Task<IEnumerable<Hotel>> GetHotels()
        {
            return await _context.Hotels.ToListAsync();
        }

        /// <summary>
        /// Update the hotel
        /// </summary>
        /// <param name="hotel">The hotel to update</param>
        public async Task UpdateHotel(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            await _context.SaveChangesAsync();
        }
    }
}
