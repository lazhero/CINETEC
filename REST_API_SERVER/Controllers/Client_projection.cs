using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System.Threading.Tasks;
using REST_API_SERVER.Database_Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Npgsql;
using NpgsqlTypes;
using Npgsql.Util;
using Npgsql.Logging;
using Npgsql.Schema;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Client/Projection")]
    public class Client_projection : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        
        [HttpGet]
        public List<Projection> Get(string cine_name)
        {
            try
            {
                var projection = Db.Projections
                                 .Include(p => p.MovieOriginalNameNavigation)
                                 .Include(p => p.ProjectionRooms)
                                    .ThenInclude(p => p.CinemaName)
                                 .ToList();

                List<Projection> res = new List<Projection>();
                foreach (Projection pro in projection)
                {
                    foreach (ProjectionRoom room in pro.ProjectionRooms)
                    {
                        if (room.CinemaName == cine_name)
                        {
                            res.Append(pro);
                            break;
                        }
                    }
                }
                return res;
            }catch(Exception e)
            {
                throw new ArgumentException(e.ToString());
            }
        }
    }
}
