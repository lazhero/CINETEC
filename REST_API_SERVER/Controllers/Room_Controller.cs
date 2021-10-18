using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Admin/Sucursales/Room")]
    public class Room_Controller : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        
        [HttpGet]
        public ICollection<Room> Get(string cinema_name)
        {
            try{
                var cinema = Db.Cinemas
                               .Where(c=> c.Name == cinema_name)
                               .Include(c => c.Rooms)
                               .Single();
                return cinema.Rooms;
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpPost]
        public void Post(Room cinema_room)
        {
            try{
                Db.Rooms.Add(cinema_room);
                Db.SaveChanges();
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpPut]
        public void Put([FromBody]Room cinema_room)
        {
            try{
                var room = Db.Rooms.Find(cinema_room.CinemaName,cinema_room.Number);
                room.RestrictionPercent = cinema_room.RestrictionPercent;
                Db.SaveChanges();
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpDelete]
        public void Delete(Room cinema_room)
        {
            try{
                Db.Rooms.Remove(cinema_room);
                Db.SaveChanges();
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }
    }
}
