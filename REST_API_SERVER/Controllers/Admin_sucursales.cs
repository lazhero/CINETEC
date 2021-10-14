using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Admin/Sucursales")]
    public class Admin_sucursales : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();
        [HttpGet]
        public ActionResult Get(){
            try{
                var cinemas = Db.Cinemas.ToList();
                return Ok(cinemas);
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Add([FromBody] Cinema new_cinema)
        {
            try{
                Db.Add(new_cinema);
                Db.SaveChanges();
                return Ok();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Modify([FromBody] Cinema new_data)
        {
            try{
                Db.Cinemas.Update(new_data);
                Db.SaveChanges();
                return Ok();
            }catch(Exception e){
                return BadRequest(e.Message);
            }
        }
        
        [HttpDelete]
        public ActionResult Delete([FromBody] Cinema new_data)
        {
            try{
                var cinema = Db.Cinemas.Where(suc => suc.Name == new_data.Name).Include(c => c.Rooms).Single();
                foreach (Room room in cinema.Rooms)
                {
                    Db.Remove(room);
                }
                Db.Remove(cinema);
                Db.SaveChanges();
                return Ok();
            }
            catch (Exception e){
                return BadRequest(e.Message);
            }
        }
    }
}
