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
                
                Db.Rooms.Update(cinema_room);
                var room = Db.Rooms.Find(cinema_room.CinemaName,cinema_room.Number);
                var projs = Db.Projections.Include(p=>p.Seats).Where(p=>p.CinemaName == cinema_room.CinemaName && p.RoomNumber==cinema_room.Number).ToList();
                foreach(Projection p in projs)
                {
                foreach (Seat s in p.Seats) {
                  if(s.State == 2)
                    {
                      s.State = 0;
                    }
                }
                  decimal restric = Decimal.Divide((int)room.RestrictionPercent, 100);
                  int to_skip = (int)(((int)Math.Ceiling((double)(room.Columns*restric)))*room.Rows);
                  foreach(Seat s in p.Seats)
                  {
                    if (to_skip <= 0)
                    {
                      break;
                    }
                    s.State = 2;
                    to_skip--;
                  }
                }
                
                Db.SaveChanges();
                return Ok();
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete(string cinema_name, int room_number)
        {
            try{
                var cine = Db.Rooms.Where(r=>r.CinemaName==cinema_name && r.Number ==room_number).Single();
                Db.Rooms.Remove(cine);
                Db.SaveChanges();
                return Ok(); 
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
