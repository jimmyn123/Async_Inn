using Async_Inn.Data;
using Async_Inn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Services
{
    public class RoomService : IRoom
    {
        // db context for the service
        private AsyncInnDbContext _context;

        public RoomService(AsyncInnDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates the room
        /// </summary>
        /// <param name="room">the room to create</param>
        /// <returns></returns>
        public async Task CreateRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes the room
        /// </summary>
        /// <param name="id">The id of the room to delete</param>
        /// <returns></returns>
        public async Task DeleteRoom(Room room)
        {
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Returns a list of all the rooms
        /// </summary>
        /// <returns>The list of rooms</returns>
        public async Task<Room> GetRoom(int? id)
        {
            return await _context.Rooms.FirstOrDefaultAsync(x => x.ID == id);
        }

        /// <summary>
        /// Returns a list of all the rooms
        /// </summary>
        /// <returns>The list of rooms</returns>
        public async Task<IEnumerable<Room>> GetRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        /// <summary>
        /// Update the room
        /// </summary>
        /// <param name="room">The room to update</param>
        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();

        }
    }
}
