using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using REST_API_SERVER.Database_Models;

namespace REST_API_SERVER.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : Controller
    {
        private CineTEC_Context Db = new CineTEC_Context();

        [HttpPost]
        public ActionResult Post([FromBody]Client user_data)
        {
            try{
                var clients = Db.Clients.ToList();
                foreach (Client c in clients)
                {
                    if (c.Username == user_data.Username && c.Password == user_data.Password)
                    {
                        return Ok(c);
                    }
                }
                return Ok();
            }catch(Exception e){
                return BadRequest("Error en Login");
            }
        }
    }
}
