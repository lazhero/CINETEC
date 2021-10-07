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
        public Object Post([FromBody]string[] user_data)
        {
            try{
                var clients = Db.Clients.ToList();
                foreach (Client c in clients)
                {
                    if (c.Username == user_data[0] && c.Password == user_data[1])
                    {
                        return c;
                    }
                }
                var emps = Db.Employees.ToList();
                foreach (Employee emp in emps)
                {
                    if (emp.Username == user_data[0] && emp.Password == user_data[1])
                    {
                        return emp;
                    }
                }
                return null;
            }catch(Exception e){
                throw new ArgumentException(e.ToString());
            }
        }
    }
}
