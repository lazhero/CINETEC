using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Room
    {
        public string CinemaName { get; set; }
        public short? Rows { get; set; }
        public short? Columns { get; set; }
        public short Number { get; set; }
        public int? RestrictionPercent { get; set; }

        public virtual Cinema CinemaNameNavigation { get; set; }
    }
}
