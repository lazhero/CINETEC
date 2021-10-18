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
using REST_API_SERVER.Classes;
using System.IO;
using System.Drawing;
using Newtonsoft.Json.Linq;
using System.Text;

namespace REST_API_SERVER.Controllers{
    [ApiController]
    [Route("Admin/Movies")]
    public class MoviesController : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public ActionResult Get()
        {
            try{
                var classifications = Db.Classifications.ToList();
                var movies = Db.Movies.Include(m=>m.MovieClassifications).Include(m=>m.Director).Include(m=>m.ActorMovies).ToList();
                return Ok(movies);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        public ActionResult Post([FromBody] Movie_Info info)
        {
            try{
                try
                {
                  var file_path = "D:\\Github Repositorios\\CINETEC\\REST_API_SERVER\\Images\\" + info.mov.OriginalName+".png";
                  using (var stream = System.IO.File.Create(file_path))
                  {
                    stream.Write(Convert.FromBase64String(info.Image));
                    info.mov.Image = file_path;
                  }
                  #pragma warning disable CS0168 // Variable is declared but never used
                }catch(Exception e)
                  #pragma warning restore CS0168 // Variable is declared but never used
                  {
                      
                  }
                var director = Db.Directors.Find(info.mov.DirectorFirstName, info.mov.DirectorMiddleName, info.mov.DirectorLastName, info.mov.DirectorSecondLastName);
                if(director == null)
                {
                  Director dir = new Director();
                  dir.FirstName = info.mov.DirectorFirstName;
                  dir.MiddleName = info.mov.DirectorMiddleName;
                  dir.LastName = info.mov.DirectorLastName;
                  dir.SecondLastName = info.mov.DirectorSecondLastName;
                  Db.Directors.Add(dir);
                  Db.SaveChanges();
                }
                foreach (ActorMovie act in info.mov.ActorMovies) {
                    var actor = Db.Actors.Find(act.ActorFirstName,act.ActorMiddleName,act.ActorLastName,act.ActorSecondLastName);
                    if (actor == null)
                    {
                      Actor new_actor = new Actor();
                      new_actor.FirstName = act.ActorFirstName;
                      new_actor.MiddleName = act.ActorMiddleName;
                      new_actor.LastName = act.ActorLastName;
                      new_actor.SecondLastName = act.ActorSecondLastName;
                      actor = new_actor;
                      Db.Actors.Add(new_actor);
                      Db.SaveChanges();
                    }
                    act.Actor=actor;
                    Db.Movies.Add(info.mov);
                    Db.MovieClassifications.Add(info.mov.MovieClassifications.Single());
                    act.MovieOriginalName= info.mov.OriginalName;
                    Db.ActorMovies.Add(act);
                    Db.SaveChanges();
                }
                Db.SaveChanges();
                return Ok();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public ActionResult Put([FromBody] Movie_Info info)
        {
            try
            {
                try
                {
                  var file_path = "D:\\Github Repositorios\\CINETEC\\REST_API_SERVER\\Images\\" + info.mov.OriginalName + ".png";
                  using (var stream = System.IO.File.Create(file_path))
                  {
                    stream.Write(Convert.FromBase64String(info.Image));
                    info.mov.Image = file_path;
                  }
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception e)
#pragma warning restore CS0168 // Variable is declared but never used
                {

                }
                Db.Movies.Update(info.mov);
                Db.SaveChanges();
                return Ok();
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }
        [HttpDelete]
        public ActionResult Delete(string movie_org_name)
        {
            try{
                var mov = Db.Movies.Include(M=>M.MovieClassifications).Where(m=>m.OriginalName == movie_org_name).Single();
                var act = Db.ActorMovies.Where(ac=>ac.MovieOriginalName == movie_org_name).ToList();
                Db.ActorMovies.RemoveRange(act);
                Db.MovieClassifications.RemoveRange(mov.MovieClassifications);
                Db.Movies.Remove(mov);
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
