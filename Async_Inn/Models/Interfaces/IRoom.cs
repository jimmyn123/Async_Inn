﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Async_Inn.Models.Interfaces
{
    public interface IRoom
    {
        // required methods for the IRoom interface
        Task CreateRoom(Room room);
        Task UpdateRoom(Room room);
        Task<Room> GetRoom(int? id);
        Task<IEnumerable<Room>> GetRooms();
        Task DeleteRoom(Room room);

        Task<RoomAmenities> GetRoomAmenities(int? AmenitiesID, int? RoomID);
    }
}
