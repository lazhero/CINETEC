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
    public ActionResult Delete([FromBody] Projection proj)
    {
      try
      {
        Db.Projections.Remove(proj);
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
