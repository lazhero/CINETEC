using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Admin/Sucursales")]
    public class Admin_sucursales : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public List<Cinema> Get(){
            try{
                var cinemas = Db.Cinemas.Include(c => c.Rooms).Include(c => c.Employees).ToList();
                return cinemas;
            }catch(Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpPost]
        public void Add([FromBody] Cinema new_cinema)
        {
            try{
                Db.Add(new_cinema);
                Db.SaveChanges();
            }catch(Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpPut]
        public void Modify([FromBody] Cinema new_data)
        {
            try{
                Db.Cinemas.Update(new_data);
                Db.SaveChanges();
            }catch(Exception e){
                throw new ArgumentException(e.ToString());
            }
        }
        
        [HttpDelete]
        public void Delete([FromBody] Cinema new_data)
        {
            try{
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
            }
            catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }
    }
}
