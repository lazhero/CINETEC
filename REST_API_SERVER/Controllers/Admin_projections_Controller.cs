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
  [Route("Admin/Projections")]
  public class Admin_projections_Controller : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();

    [HttpGet]
    public ActionResult Get()
    {
      try
      {
        List<Projection> projecs = Db.Projections.ToList();
        List<Projection_Room> res = new();
        foreach(Projection PR in projecs)
        {
          var room = Db.Rooms.Find(PR.CinemaName,PR.RoomNumber);
          var temp = new Projection_Room();
          temp.CinemaName = PR.CinemaName;
          temp.Columns = room.Columns;
          temp.Rows = room.Rows;
          temp.Id = PR.Id;
          temp.Date = PR.Date;
          temp.EndTime = PR.EndTime;
          temp.InitialTime = PR.InitialTime;
          temp.MovieOriginalName = PR.MovieOriginalName;
          temp.RoomNumber = PR.RoomNumber;
          res.Add(temp);
        }
        return Ok(res);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut]
    public ActionResult Put([FromBody] Projection proj)
    {
      try
      {
        Db.Projections.Update(proj);
        Db.SaveChanges();
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult Post([FromBody] Projection proj)
    {
      try
      {
        int id = Db.Projections.Max(p=>p.Id)+1;
        proj.Id = id;
        var room = Db.Rooms.Where(p => p.CinemaName == proj.CinemaName && p.Number == proj.RoomNumber).Single();
        decimal restric = Decimal.Divide((int)room.RestrictionPercent, 100);
        int to_skip = (int)(((int)Math.Ceiling((double)(room.Columns * restric))) * room.Rows);
        for (int i =0; i < (int)(room.Rows * room.Columns); i++)
        {
          Seat s = new Seat();
          if (to_skip >= 0) {
            s.State = 2;
            to_skip--;
          }
          else {
            s.State = 0;
          }
          s.SeatNumber = (short)i;
          s.ProjectionId = proj.Id;
          Db.Seats.Add(s);
        }
        Db.Projections.Add(proj);

        Db.SaveChanges();
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete]
    public ActionResult Delete(int proj)
    {
      try
      {
        var Projec = Db.Projections.Include(p=>p.Seats).Where(p=>p.Id==proj).Single();
        Db.Seats.RemoveRange(Projec.Seats);
        Db.Projections.Remove(Projec);
        
        Db.SaveChanges();
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
