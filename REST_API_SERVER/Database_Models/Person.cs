using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_SERVER.Database_Models
{
    public abstract class Person
    {
        public int IdCard { get; set; }
        public int? PhoneNum { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
