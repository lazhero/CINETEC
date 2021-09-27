using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER
{
    public partial class Employee
    {
        public int IdCard { get; set; }
        public int? PhoneNum { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime? FirstDateWorking { get; set; }
        public string CinemaName { get; set; }
        public int? RoleId { get; set; }

        public virtual Cinema CinemaNameNavigation { get; set; }
        public virtual Role Role { get; set; }
    }
}
