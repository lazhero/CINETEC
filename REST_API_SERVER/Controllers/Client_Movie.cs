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
  public class Client_Movie
  {
    CineTEC_Context Db = new CineTEC_Context();
    [HttpGet]
    public ICollection<Movie> Get(string cinema_name)
    {
      try
      {
        var movies = Db.Movies
                           .Include(m => m.Projections)
                           .ThenInclude(p=>p.ProjectionRooms)
                           .ToList();
        var res = new List<Movie>();
        foreach(Movie mov in movies)
        {
          if (Is_in_cinema(mov, cinema_name))
          {
            res.Add(mov);
          }
        }
        return res;
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }

    private bool Is_in_cinema(Movie mov, string cinema_name)
    {
       foreach(Projection Proj in mov.Projections)
       {
          foreach(ProjectionRoom PR in Proj.ProjectionRooms)
          {
             if(PR.CinemaName == cinema_name){
               return true;
             }
          }
       }
       return false;
    }
  }
}
