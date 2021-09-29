using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REST_API_SERVER.Database_Models;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Admin/sucursales")]
    public class Admin_sucursales : Controller
    {
        TestingContext Db = new TestingContext();
        [HttpGet]
        public List<Cinema> Get()
        {
            List<Cinema> cinema_example = Db.Cinemas.ToList();
            return cinema_example;
        }

        [HttpPost]
        public void Add([FromBody] Cinema new_cinema)
        {
            Db.Add(new_cinema);
            Db.SaveChanges();
        }

        [HttpPut]
        public void Modify([FromBody] Cinema new_data)
        {
            var cinema = Db.Cinemas.Find(new_data.Name);
            cinema.Location = new_data.Location;
            cinema.NumberOfRooms = new_data.NumberOfRooms;
            Db.SaveChanges();
        }
    }
}
