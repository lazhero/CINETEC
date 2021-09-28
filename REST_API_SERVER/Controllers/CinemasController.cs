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
    [Route("Cinemas")]
    public class CinemasController : ControllerBase
    {
        testingContext db = new testingContext();

        [HttpGet]
        public string Get()
        {
            Cinema cinema_example =  db.Cinemas.Find("Cine Turrucares");
            return cinema_example.NumberOfRooms.ToString();
        }
    }
}
