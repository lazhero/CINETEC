using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_SERVER.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Client/Projection")]
    public class Client_projection : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public List<Projection> Get(string Cinema_name, string Movie_name)
        {
            try{
                var projection = Db.Projections
                                 .Include(p => p.MovieOriginalNameNavigation)
                                 .Where(p=>p.MovieOriginalName == Movie_name)
                                 .ToList();
                List<Projection> res = new List<Projection>();
                foreach (Projection pro in projection)
                {
                   if (pro.CinemaName == Cinema_name){
                          res.Add(pro);
                   }
                }
                return res;
            }catch(Exception e){
                throw new ArgumentException(e.ToString());
            }
        }
    }
}
