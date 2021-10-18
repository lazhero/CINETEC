using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;
namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Covid")]
  public class Covid_restriccion: Controller
  {
    CineTEC_Context Db = new CineTEC_Context();

    [HttpPut]
    public ActionResult Put([FromBody] int restriction)
    {
      try
      {
        var rooms = Db.Rooms.ToList();

        foreach(Room r in rooms)
        {
          r.RestrictionPercent = restriction;
          Db.SaveChanges();
        }
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
