using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Employee:Person
    {
        public DateTime? Birthdate { get; set; }
        public DateTime? FirstDateWorking { get; set; }
        public string CinemaName { get; set; }
        public int? RoleId { get; set; }

        public virtual Cinema CinemaNameNavigation { get; set; }
        public virtual Role Role { get; set; }
    }
}
