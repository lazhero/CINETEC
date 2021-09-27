using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER
{
    public partial class Room
    {
        public Room()
        {
            ProjectionRooms = new HashSet<ProjectionRoom>();
        }

        public string CinemaName { get; set; }
        public short? Rows { get; set; }
        public short? Columns { get; set; }
        public short Number { get; set; }
        public short? Capacity { get; set; }
        public int? RestrictionPercent { get; set; }

        public virtual Cinema CinemaNameNavigation { get; set; }
        public virtual ICollection<ProjectionRoom> ProjectionRooms { get; set; }
    }
}
