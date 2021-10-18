using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Projection
    {
        public Projection()
        {
            Seats = new HashSet<Seat>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public DateTime? InitialTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string MovieOriginalName { get; set; }
        public short? RoomNumber { get; set; }
        public string CinemaName { get; set; }

        public virtual Movie MovieOriginalNameNavigation { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
