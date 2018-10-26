using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        /// <summary>
        /// Sets the options for the context
        /// </summary>
        /// <param name="options">The options</param>
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) : base(options)
        {
        }
        
        /// <summary>
        /// Overrides and sets composite key
        /// </summary>
        /// <param name="modelBuilder">A model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // sets the keys to composite keys
            modelBuilder.Entity<HotelRoom>().HasKey(
                ce => new { ce.HotelID, ce.RoomNumber }
                );

            modelBuilder.Entity<RoomAmenities>().HasKey(
                ce => new { ce.AmenitiesID, ce.RoomID }
                );
        }

        // creates the tables
        public DbSet<Amenities> Amenities { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
