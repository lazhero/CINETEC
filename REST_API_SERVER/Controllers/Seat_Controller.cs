using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Admin/Seats")]
  public class Seat_Controller : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();
    [HttpGet]
    public ActionResult Get()
    {
      try
      {
        return Ok(Db.Seats.ToList());
      }
      catch(Exception e)
      {
        return BadRequest(e.Message);
      }
      
    }
  }
}
