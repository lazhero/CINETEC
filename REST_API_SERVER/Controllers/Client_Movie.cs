using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_SERVER.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Client/Movie")]
  public class Client_Movie : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();
    [HttpGet]
    public ActionResult Get(string cinema_name)
    {
      try
      {
        var movies = Db.Movies
                           .Include(m => m.Projections)
                           .ToList();
        var res = new List<Movie>();
        foreach(Movie mov in movies)
        {
          if (Is_in_cinema(mov, cinema_name))
          {
            res.Add(mov);
          }
        }
        return Ok(res);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    private bool Is_in_cinema(Movie mov, string cinema_name)
    {
       foreach(Projection proj in mov.Projections)
       {
          if(proj.CinemaName == cinema_name){
               return true;
          }
       }
       return false;
    }
  }
}
