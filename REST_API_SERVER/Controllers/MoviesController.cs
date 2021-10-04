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

namespace REST_API_SERVER.Controllers{
    [ApiController]
    [Route("Admin/Movies")]
    public class MoviesController : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public List<Movie> Get()
        {
            try{
                var movies = Db.Movies.Include(m => m.Projections).ToList();
                return movies;
            }catch(Exception e)
            {
                throw new ArgumentException(e.ToString());
            }
        }
        [HttpPost]
        public void Post([FromBody] Movie mov)
        {
            try{
                Db.Movies.Add(mov);
                Db.SaveChanges();
            }catch(Exception e){
                throw new ArgumentException(e.ToString());
            }
        }
        [HttpDelete]
        public void Delete([FromBody] Movie new_mov)
        {
            try{
                Db.Movies.Remove(new_mov);
                Db.SaveChanges();
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.ToString());
            }
        }
    }
}
