using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class AmenitiesService : IAmenities
    {
        private AsyncInnDbContext _context;
        
        public AmenitiesService(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task CreateAmenity(Amenities amenity)
        {
            _context.Amenities.Add(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAmenity(int id)
        {
            Amenities amenity = await _context.Amenities.FirstOrDefaultAsync(x => x.ID == id);
            _context.Amenities.Remove(amenity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Amenities>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetAmenity(int? id)
        {
            return await _context.Amenities.FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task UpdateAmenity(Amenities amenity)
        {
            _context.Update(amenity);
            await _context.SaveChangesAsync();
        }
    }
}
