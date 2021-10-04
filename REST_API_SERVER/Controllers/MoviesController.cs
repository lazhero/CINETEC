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
using System.Net;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Admin/Movies")]
    public class MoviesController : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public List<Movie> Get()
        {
            var movies = Db.Movies.Include(m=> m.Projections).ToList();
            return movies;
        }
    }
}
