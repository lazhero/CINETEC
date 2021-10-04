﻿using Microsoft.AspNetCore.Mvc;
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
        public List<Client> Get()
        {
            try{
                var clients = Db.Clients.ToList();
                return clients;
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpPost]
        public void Post([FromBody] Client new_client)
        {
            try{
                Db.Clients.Add(new_client);
                Db.SaveChanges();
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpPut]
        public void Put([FromBody] Client new_client)
        {
            try{
                Db.Clients.Update(new_client);
                Db.SaveChanges();
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

        [HttpDelete]
        public void Delete([FromBody] Client client)
        {
            try{
                var cli = Db.Clients.Find(client.IdCard,client.Username);
                Db.Remove(cli);
                Db.SaveChanges();
            }catch (Exception e){
                throw new ArgumentException(e.ToString());
            }
        }

    }
}
