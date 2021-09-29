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
        private TestingContext Db = new TestingContext();

        [HttpPost]
        public string Post([FromBody]string[] user_data)
        {
            var clients = Db.Clients.ToList();
            foreach(Client c in clients)
            {
                if(c.Username == user_data[0] && c.Password == user_data[1])
                {
                    return c.FirstName;
                }
            }
            return "ERROR 404: Client not in the database";
        }
    }
}
