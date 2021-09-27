using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER
{
    public partial class ProjectionRoom
    {
        public int ProjectionId { get; set; }
        public string CinemaName { get; set; }
        public short RoomId { get; set; }

        public virtual Projection Projection { get; set; }
        public virtual Room Room { get; set; }
    }
}
