using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Admin/Client")]
    public class Admin_Client_Controller : Controller
    {
        CineTEC_Context Db = new CineTEC_Context();

        [HttpGet]
        public ActionResult Get()
        {
            try{
                var clients = Db.Clients.ToList();
                return Ok(clients);
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Client new_client)
        {
            try{
                Db.Clients.Add(new_client);
                Db.SaveChanges();
                return Ok();
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] Client new_client)
        {
            try{
                Db.Clients.Update(new_client);
                Db.SaveChanges();
                return Ok();  
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] Client client)
        {
            try{
                var cli = Db.Clients.Find(client.IdCard,client.Username);
                Db.Remove(cli);
                Db.SaveChanges();
                return Ok();
            }catch (Exception e){
                return BadRequest(e.Message);
            }
        }

    }
}
