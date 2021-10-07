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
using System.IO;
using System.Drawing;

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
        [HttpPut]
        public void Put([FromBody] Movie new_mov)
        {
            try
            {
                var mov = Db.Movies.Find(new_mov);
                /*
                        using (Stream bmpStream = System.IO.File.Open("image/50_sombras.jpg", System.IO.FileMode.Open))
                        {
                            Image image = Image.FromStream(bmpStream);

                            using (var ms = new MemoryStream())
                            {
                                image.Save(ms, image.RawFormat);
                                mov.Image = ms.ToArray();
                            }
                            bmpStream.Close();
                        }
                */ 
                mov.Image = new_mov.Image;
                Db.SaveChanges();
            }catch (Exception e){
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
