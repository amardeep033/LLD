using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _7_Agrregation_Association
{
    // ============================================================
    // COMPOSITION — House "owns" Rooms, strong ownership
    // Rooms are created INSIDE House — they cannot exist without it
    // If House is destroyed, Rooms are destroyed too
    // ============================================================
    public class Room
    {
        public string RoomName { get; set; }
        public Room(string name) => RoomName = name;
    }

    public class House
    {
        private readonly List<Room> _rooms;  // owns them

        public House()
        {
            // Rooms are created INSIDE — tied to this House's lifetime
            _rooms = new List<Room>
        {
            new Room("Kitchen"),
            new Room("Bedroom"),
            new Room("Bathroom")
        };
        }

        public void ShowRooms()
        {
            foreach (var r in _rooms)
                Console.WriteLine($"House has: {r.RoomName}");
        }
    }
}