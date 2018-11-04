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

        public AsyncInnTest()
        {
            Initialize();
        }

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
                Amenities amenity = await context.Amenities.FirstOrDefaultAsync(x => x.ID == 1);
                Assert.True(amenity.Name == "Parking");
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
    }
}
