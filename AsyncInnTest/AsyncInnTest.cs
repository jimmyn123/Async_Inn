using Async_Inn.Data;
using Async_Inn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace AsyncInnTest
{
    public class AsyncInnTest
    {
        DbContextOptions<AsyncInnDbContext> optionsA;
        DbContextOptions<AsyncInnDbContext> optionsH;
        DbContextOptions<AsyncInnDbContext> optionsR;
        DbContextOptions<AsyncInnDbContext> optionsHR;
        DbContextOptions<AsyncInnDbContext> optionsRA;
        AsyncInnDbContext contextA;
        Amenities a;
        Hotel h;
        Room r;
        HotelRoom hr;
        RoomAmenities ra;

        public AsyncInnTest()
        {
            Initialize();
        }

        /// <summary>
        /// Private helper that initializes
        /// </summary>
        private async void Initialize()
        {
            optionsA = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("Amenities").Options;
            optionsH = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("Hotels").Options;
            optionsR = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("Rooms").Options;
            optionsHR = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("HotelRooms").Options;
            optionsRA = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("RoomAmenities").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsA))
            {
                a = new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker"
                };

                context.Amenities.Add(a);
                await context.SaveChangesAsync();

            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsH))
            {
                h = new Hotel
                {
                    ID = 2,
                    Name = "Seattle"
                };

                context.Hotels.Add(h);
                await context.SaveChangesAsync();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsR))
            {
                r = new Room
                {
                    ID = 3,
                    Name = "Ocean Room"
                };

                context.Rooms.Add(r);
                await context.SaveChangesAsync();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsHR))
            {
                hr = new HotelRoom
                {
                    Hotel = new Hotel()
                    {
                        Name = "Everett"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.HotelRooms.Add(hr);
                await context.SaveChangesAsync();
            }

            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsRA))
            {
                ra = new RoomAmenities
                {
                    Amenities = new Amenities()
                    {
                        Name = "Microwave"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.HotelRooms.Add(hr);
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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsA))
            {
                await context.Database.EnsureDeletedAsync();

                a = new Amenities
                {
                    ID = 1,
                    Name = "Coffee Maker"
                };

                context.Amenities.Add(a);
                await context.SaveChangesAsync();
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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsA))
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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsA))
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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsH))
            {
                await context.Database.EnsureDeletedAsync();

                h = new Hotel
                {
                    ID = 2,
                    Name = "Seattle"
                };

                context.Hotels.Add(h);
                await context.SaveChangesAsync();

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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsH))
            {
                await context.Database.EnsureDeletedAsync();

                h = new Hotel
                {
                    ID = 2,
                    Name = "Seattle"
                };

                context.Hotels.Add(h);
                await context.SaveChangesAsync();

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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsH))
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
            Assert.True(r.Name == "Ocean Room");
        }

        /// <summary>
        /// Tests the setter
        /// </summary>
        [Fact]
        public void RoomSetterTest()
        {
            r.Name = "Cupid Special";
            Assert.True(r.Name == "Cupid Special");
        }

        /// <summary>
        /// Tests the create/read
        /// </summary>
        [Fact]
        public async void RoomCreateReadTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsR))
            {
                await context.Database.EnsureDeletedAsync();

                r = new Room
                {
                    ID = 3,
                    Name = "Ocean Room"
                };

                context.Rooms.Add(r);
                await context.SaveChangesAsync();
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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsR))
            {
                await context.Database.EnsureDeletedAsync();

                r = new Room
                {
                    ID = 3,
                    Name = "Ocean Room"
                };

                context.Rooms.Add(r);
                await context.SaveChangesAsync();

                Room Room = await context.Rooms.FirstOrDefaultAsync(x => x.ID == 3);

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
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsR))
            {
                Room room = await context.Rooms.FirstOrDefaultAsync(x => x.ID == 3);
                context.Rooms.Remove(room);
                await context.SaveChangesAsync();

                var allRooms = await context.Rooms.ToListAsync();

                Assert.DoesNotContain(room, allRooms);
            }
        }

        /// <summary>
        /// Tests the getter
        /// </summary>
        [Fact]
        public void HotelRoomGetterTest()
        {
            Assert.True(hr.Hotel.Name == "Everett");
        }

        /// <summary>
        /// Tests the setter
        /// </summary>
        [Fact]
        public void HotelRoomSetterTest()
        {
            hr.Hotel.Name = "Bellevue";
            Assert.True(hr.Hotel.Name == "Bellevue");
        }

        /// <summary>
        /// Tests the create/read
        /// </summary>
        [Fact]
        public async void HotelRoomCreateReadTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsHR))
            {
                await context.Database.EnsureDeletedAsync();

                hr = new HotelRoom
                {
                    Hotel = new Hotel()
                    {
                        Name = "Everett"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.HotelRooms.Add(hr);
                await context.SaveChangesAsync();

                HotelRoom hotelRoom = await context.HotelRooms.FirstOrDefaultAsync(x => x.Hotel.Name == "Everett");
                Assert.True(hotelRoom.Hotel.Name == "Everett");
            }
        }

        /// <summary>
        /// Tests update
        /// </summary>
        [Fact]
        public async void HotelRoomUpdateTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsHR))
            {
                await context.Database.EnsureDeletedAsync();

                hr = new HotelRoom
                {
                    Hotel = new Hotel()
                    {
                        Name = "Everett"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.HotelRooms.Add(hr);
                await context.SaveChangesAsync();

                HotelRoom hotelRoom = await context.HotelRooms.FirstOrDefaultAsync(x => x.Hotel.Name == "Everett");

                hotelRoom.Hotel.Name = "Bellevue";
                context.HotelRooms.Update(hotelRoom);
                await context.SaveChangesAsync();

                hotelRoom = await context.HotelRooms.FirstOrDefaultAsync(x => x.Hotel.Name == "Bellevue");

                Assert.True(hotelRoom.Hotel.Name == "Bellevue");
            }
        }

        /// <summary>
        /// Tests Delete
        /// </summary>
        [Fact]
        public async void HotelRoomDeleteTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsHR))
            {
                await context.Database.EnsureDeletedAsync();

                hr = new HotelRoom
                {
                    Hotel = new Hotel()
                    {
                        Name = "Everett"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.HotelRooms.Add(hr);
                await context.SaveChangesAsync();

                HotelRoom hotelRoom = await context.HotelRooms.FirstOrDefaultAsync(x => x.Hotel.Name == "Everett");
                context.HotelRooms.Remove(hotelRoom);
                await context.SaveChangesAsync();

                var allHotelRoom = await context.HotelRooms.ToListAsync();

                Assert.DoesNotContain(hotelRoom, allHotelRoom);
            }
        }
        /// <summary>
        /// Tests the getter
        /// </summary>
        [Fact]
        public void RoomAmenitiesGetterTest()
        {
            Assert.True(ra.Amenities.Name == "Microwave");
        }

        /// <summary>
        /// Tests the setter
        /// </summary>
        [Fact]
        public void RoomAmenitiesSetterTest()
        {
            ra.Amenities.Name = "Teapot";
            Assert.True(ra.Amenities.Name == "Teapot");
        }

        /// <summary>
        /// Tests the create/read
        /// </summary>
        [Fact]
        public async void RoomAmenitiesCreateReadTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsRA))
            {
                await context.Database.EnsureDeletedAsync();

                ra = new RoomAmenities
                {
                    Amenities = new Amenities()
                    {
                        Name = "Microwave"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.RoomAmenities.Add(ra);
                await context.SaveChangesAsync();

                RoomAmenities roomAmenities = await context.RoomAmenities.FirstOrDefaultAsync(x => x.Amenities.Name == "Microwave");
                Assert.True(roomAmenities.Amenities.Name == "Microwave");
            }
        }

        /// <summary>
        /// Tests update
        /// </summary>
        [Fact]
        public async void RoomAmenitiesUpdateTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsRA))
            {
                await context.Database.EnsureDeletedAsync();

                ra = new RoomAmenities
                {
                    Amenities = new Amenities()
                    {
                        Name = "Microwave"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.RoomAmenities.Add(ra);
                await context.SaveChangesAsync();

                RoomAmenities roomAmenities = await context.RoomAmenities.FirstOrDefaultAsync(x => x.Amenities.Name == "Microwave");

                roomAmenities.Amenities.Name = "Teapot";
                context.RoomAmenities.Update(roomAmenities);
                await context.SaveChangesAsync();

                roomAmenities = await context.RoomAmenities.FirstOrDefaultAsync(x => x.Amenities.Name == "Teapot");

                Assert.True(roomAmenities.Amenities.Name == "Teapot");
            }
        }

        /// <summary>
        /// Tests Delete
        /// </summary>
        [Fact]
        public async void RoomAmenitiesDeleteTest()
        {
            using (AsyncInnDbContext context = new AsyncInnDbContext(optionsRA))
            {
                await context.Database.EnsureDeletedAsync();

                ra = new RoomAmenities
                {
                    Amenities = new Amenities()
                    {
                        Name = "Microwave"
                    },
                    Room = new Room()
                    {
                        Name = "Ocean View"
                    }
                };

                context.RoomAmenities.Add(ra);
                await context.SaveChangesAsync();

                RoomAmenities roomAmenities = await context.RoomAmenities.FirstOrDefaultAsync(x => x.Amenities.Name == "Microwave");
                context.RoomAmenities.Remove(roomAmenities);
                await context.SaveChangesAsync();

                var allRoomAmenities = await context.RoomAmenities.ToListAsync();

                Assert.DoesNotContain(roomAmenities, allRoomAmenities);
            }
        }
    }
}
