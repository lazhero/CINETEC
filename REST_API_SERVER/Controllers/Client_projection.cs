using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

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
                                 .Include(p => p.MovieOriginalNameNavigation)
                                 .Where(p=>p.MovieOriginalName == Movie_name && p.CinemaName == Cinema_name)
                                 .Select(p=> new {
                                   RoomNumber = p.RoomNumber,
                                   InitialTime = p.InitialTime,
                                   CinemaName = p.CinemaName,
                                 })
                                 .ToList();
                return Ok(projection);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
