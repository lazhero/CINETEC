﻿using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Seat
    {
        public int ProjectionId { get; set; }
        public short SeatNumber { get; set; }

        public virtual Projection Projection { get; set; }
    }
}
