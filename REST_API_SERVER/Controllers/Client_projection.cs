using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;
using REST_API_SERVER.Classes;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Client/Projection")]
    public class Client_projection : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public ActionResult Get(string Cinema_name, string Movie_name)
        {
            try{
                var projection = Db.Projections
                                 .Include(p=>p.Seats)
                                 .Include(p => p.MovieOriginalNameNavigation)
                                 .Where(p=>p.MovieOriginalName == Movie_name && p.CinemaName == Cinema_name)
                                 .Select(p=> new Projection{
                                   Id = p.Id,
                                   RoomNumber = p.RoomNumber,
                                   InitialTime = p.InitialTime,
                                   CinemaName = p.CinemaName,
                                 })
                                 .ToList();
                List<Projection_Room> res = new();
                foreach (Projection PR in projection)
                {
                  var room = Db.Rooms.Find(PR.CinemaName, PR.RoomNumber);
                  var temp = new Projection_Room();
                  temp.CinemaName = PR.CinemaName;
                  temp.Columns = room.Columns;
                  temp.Rows = room.Rows;
                  temp.Id = PR.Id;
                  temp.InitialTime = PR.InitialTime;
                  temp.RoomNumber = PR.RoomNumber;
                  res.Add(temp);
                  decimal restric = Decimal.Divide((int)room.RestrictionPercent, 100);
                  int to_skip = (int)(((int)Math.Ceiling((double)(room.Columns * restric))) * room.Rows);
                  foreach (Seat s in PR.Seats)
                  {
                    if (to_skip <= 0)
                    {
                      break;
                    }
                    s.State = 2;
                    to_skip--;
                  }
                }
                return Ok(res);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
