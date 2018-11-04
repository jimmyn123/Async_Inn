using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class AmenitiesService : IAmenities
    {
        // db context for the service
        private AsyncInnDbContext _context;
        
        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates the amenity
        /// </summary>
        /// <param name="amenity">the amenity to create</param>
        /// <returns></returns>
        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the Amenity
        /// </summary>
        /// <param name="id">The id of the amenity to delete</param>
        /// <returns></returns>
        public async Task DeleteAmenity(int id)
        {
            Amenities amenity = await _context.Amenities.FirstOrDefaultAsync(x => x.ID == id);
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns a list of all the amenities
        /// </summary>
        /// <returns>The list of amenities</returns>
        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        /// <summary>
        /// Gets one specific amenity
        /// </summary>
        /// <param name="id">The id of the amenity to return</param>
        /// <returns>The actual amenity with the id</returns>
        public async Task<Amenities> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(x => x.ID == id);
        }
        
        /// <summary>	
        /// Update the amenity	
        /// </summary>	
        /// <param name="amenity">The amenity to update</param>	
        /// <returns></returns>	
        public async Task UpdateAmenity(Amenities amenity)
        {
            _context.Update(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
