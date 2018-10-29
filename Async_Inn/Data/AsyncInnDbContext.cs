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
                ce => new { ce.HotelID, ce.RoomID }
                );

            modelBuilder.Entity<RoomAmenities>().HasKey(
                ce => new { ce.AmenitiesID, ce.RoomID }
                );

            // seed data for hotels
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    ID = 1,
                    Name = "Async Inn - Seattle",
                    Address = "1234 Rainier Ave, Seattle, WA, 98001",
                    Phone = "2061234567"
                },
                new Hotel
                {
                    ID = 2,
                    Name = "Async Inn - Lynnwood",
                    Address = "2234 Rainier Ave, Lynnwood, WA, 98002",
                    Phone = "2062234567"
                },
                new Hotel
                {
                    ID = 3,
                    Name = "Async Inn - Bellevue",
                    Address = "3234 Rainier Ave, Bellevue, WA, 98003",
                    Phone = "2063234567"
                },
                new Hotel
                {
                    ID = 4,
                    Name = "Async Inn - Redmond",
                    Address = "4234 Rainier Ave, Redmond, WA, 98004",
                    Phone = "2064234567"
                },
                new Hotel
                {
                    ID = 5,
                    Name = "Async Inn - Kent",
                    Address = "5234 Rainier Ave, Kent, WA, 98005",
                    Phone = "2065234567"
                }
            );

            // seed data for room types
            modelBuilder.Entity<Room>().HasData(
                new Room
                {
                    ID = 1,
                    Name = "Lover's Special",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 2,
                    Name = "Tropical Vacation",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 3,
                    Name = "Feels like Home",
                    Layout = Layout.Studio
                },
                new Room
                {
                    ID = 4,
                    Name = "Aquatic Package",
                    Layout = Layout.TwoBedroom
                },
                new Room
                {
                    ID = 5,
                    Name = "Out in Space",
                    Layout = Layout.OneBedroom
                },
                new Room
                {
                    ID = 6,
                    Name = "Family Package",
                    Layout = Layout.TwoBedroom
                }
            );

            // seeding amenities
            modelBuilder.Entity<Amenities>().HasData(
                new Amenities
                {
                    ID = 1,
                    Name = "Coffee Machine"
                },
                new Amenities
                {
                    ID = 2,
                    Name = "Pool"
                },
                new Amenities
                {
                    ID = 3,
                    Name = "Gym"
                },
                new Amenities
                {
                    ID = 4,
                    Name = "Ocean View"
                },
                new Amenities
                {
                    ID = 5,
                    Name = "Spa"
                }
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
