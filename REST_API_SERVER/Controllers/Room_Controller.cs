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
        public ActionResult Get(string cinema_name)
        {
            try{
                var cinema = Db.Cinemas
                               .Where(c=> c.Name == cinema_name)
                               .Include(c => c.Rooms)
                               .Single();
                return Ok(cinema.Rooms);
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post(Room cinema_room)
        {
            try{
                Db.Rooms.Add(cinema_room);
                Db.SaveChanges();
                return Ok();
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody]Room cinema_room)
        {
            try{
                var room = Db.Rooms.Find(cinema_room.CinemaName,cinema_room.Number);
                room.RestrictionPercent = cinema_room.RestrictionPercent;
                Db.SaveChanges();
                return Ok();
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(Room cinema_room)
        {
            try{
                Db.Rooms.Remove(cinema_room);
                Db.SaveChanges();
                return Ok(); 
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
