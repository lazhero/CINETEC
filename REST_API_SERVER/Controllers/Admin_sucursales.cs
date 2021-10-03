using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using REST_API_SERVER.Database_Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using NpgsqlTypes;
using Npgsql.Util;
using Npgsql.Logging;
using Npgsql.Schema;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Admin/Sucursales")]
    public class Admin_sucursales : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public List<Cinema> Get()
        {
            var cinemas = Db.Cinemas.Include(c => c.Rooms).Include(c => c.Employees).ToList();
            return cinemas;
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
        
        [HttpDelete]
        public string Delete([FromBody] Cinema new_data)
        {
            try
            {
                var cinema = Db.Cinemas.Where(suc => suc.Name == new_data.Name).Include(c => c.Employees).Include(c => c.Rooms).Single();
                foreach(Employee emp in cinema.Employees)
                {
                    Db.Remove(emp);
                }
                foreach (Room room in cinema.Rooms)
                {
                    Db.Remove(room);
                }
                Db.Remove(cinema);
                Db.SaveChanges();
                return "Se elimino con exito";
            }
            catch (Exception e)
            {
                return "404 object not found";
            }
        }
    }
}
