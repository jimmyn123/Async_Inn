using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AsyncInnTest
{
    public class AsyncInnTest
    {
        DbContextOptions<AsyncInnDbContext> options;
        Amenities a;
        Hotel h;
        Room r;

        public AsyncInnTest()
        {
            Initialize();
        }

        /// <summary>
        /// Private helper that initializes
        /// </summary>
        private async void Initialize()
        {
            options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("NewDB").Options;
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                a = new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker"
                };

                context.Amenities.Add(a);
                await context.SaveChangesAsync();

                h = new Hotel
                {
                    ID = 2,
                    Name = "Seattle"
                };

                context.Hotels.Add(h);
                await context.SaveChangesAsync();

                r = new Room
                {
                    ID = 3,
                    Name = "Ocean Room"
                };

                context.Rooms.Add(r);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Tests the getter
        /// </summary>
        [Fact]
        public void AmenitiesGetterTest()
        {
            Assert.True(a.Name == "Coffee Maker");
        }

        /// <summary>
        /// Tests the setter
        /// </summary>
        [Fact]
        public void AmenitiesSetterTest()
        {
            a.Name = "Parking";
            Assert.True(a.Name == "Parking");
        }

        /// <summary>
        /// Tests the create/read
        /// </summary>
        [Fact]
        public async void AmenitiesCreateReadTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = await context.Amenities.FirstOrDefaultAsync(x => x.Name == "Coffee Maker");
                Assert.True(amenity.Name == "Coffee Maker");
            }
        }

        /// <summary>
        /// Tests update
        /// </summary>
        [Fact]
        public async void AmenitiesUpdateTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = await context.Amenities.FirstOrDefaultAsync(x => x.ID == 1);

                amenity.Name = "Parking";
                context.Amenities.Update(amenity);
                await context.SaveChangesAsync();

                amenity = await context.Amenities.FirstOrDefaultAsync(x => x.ID == 1);

                Assert.True(amenity.Name == "Parking");
            }
        }

        /// <summary>
        /// Tests Delete
        /// </summary>
        [Fact]
        public async void AmenitiesDeleteTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Amenities amenity = await context.Amenities.FirstOrDefaultAsync(x => x.ID == 1);
                context.Amenities.Remove(amenity);
                await context.SaveChangesAsync();

                var allAmenities = await context.Amenities.ToListAsync();

                Assert.DoesNotContain(amenity, allAmenities);
            }
        }

        /// <summary>
        /// Tests the getter
        /// </summary>
        [Fact]
        public void HotelGetterTest()
        {
            Assert.True(h.Name == "Seattle");
        }

        /// <summary>
        /// Tests the setter
        /// </summary>
        [Fact]
        public void HotelSetterTest()
        {
            h.Name = "Bellevue";
            Assert.True(h.Name == "Bellevue");
        }

        /// <summary>
        /// Tests the create/read
        /// </summary>
        [Fact]
        public async void HotelCreateReadTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = await context.Hotels.FirstOrDefaultAsync(x => x.ID == 2);
                Assert.True(hotel.Name == "Seattle");
            }
        }

        /// <summary>
        /// Tests update
        /// </summary>
        [Fact]
        public async void HotelUpdateTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = await context.Hotels.FirstOrDefaultAsync(x => x.ID == 2);

                hotel.Name = "Bellevue";
                context.Hotels.Update(hotel);
                await context.SaveChangesAsync();

                hotel = await context.Hotels.FirstOrDefaultAsync(x => x.Name == "Bellevue");

                Assert.True(hotel.Name == "Bellevue");
            }
        }

        /// <summary>
        /// Tests Delete
        /// </summary>
        [Fact]
        public async void HotelDeleteTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Hotel hotel = await context.Hotels.FirstOrDefaultAsync(x => x.ID == 2);
                context.Hotels.Remove(hotel);
                await context.SaveChangesAsync();

                var allHotels = await context.Hotels.ToListAsync();

                Assert.DoesNotContain(hotel, allHotels);
            }
        }

        /// <summary>
        /// Tests the getter
        /// </summary>
        [Fact]
        public void RoomGetterTest()
        {
            Assert.True(h.Name == "Ocean Room");
        }

        /// <summary>
        /// Tests the setter
        /// </summary>
        [Fact]
        public void RoomsetterTest()
        {
            h.Name = "Cupid Special";
            Assert.True(h.Name == "Cupid Special");
        }

        /// <summary>
        /// Tests the create/read
        /// </summary>
        [Fact]
        public async void RoomCreateReadTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = await context.Rooms.FirstOrDefaultAsync(x => x.ID == 3);
                Assert.True(room.Name == "Ocean Room");
            }
        }

        /// <summary>
        /// Tests update
        /// </summary>
        [Fact]
        public async void RoomUpdateTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room Room = await context.Rooms.FirstOrDefaultAsync(x => x.ID == 2);

                Room.Name = "Cupid Special";
                context.Rooms.Update(Room);
                await context.SaveChangesAsync();

                Room = await context.Rooms.FirstOrDefaultAsync(x => x.Name == "Cupid Special");

                Assert.True(Room.Name == "Cupid Special");
            }
        }

        /// <summary>
        /// Tests Delete
        /// </summary>
        [Fact]
        public async void RoomDeleteTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                Room room = await context.Rooms.FirstOrDefaultAsync(x => x.ID == 2);
                context.Rooms.Remove(room);
                await context.SaveChangesAsync();

                var allRooms = await context.Rooms.ToListAsync();

                Assert.DoesNotContain(room, allRooms);
            }
        }
    }
}
