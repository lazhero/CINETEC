using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Employees = new HashSet<Employee>();
            Rooms = new HashSet<Room>();
        }

        public string Name { get; set; }
        public string Location { get; set; }
        public short? NumberOfRooms { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
