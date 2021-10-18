using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_SERVER.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Admin/Login")]
  public class Admin_Login : Controller
  {
    private CineTEC_Context Db = new CineTEC_Context();

    [HttpPost]
    public ActionResult Post([FromBody] Employee user_data)
    {
      try
      {
        var emps = Db.Employees.ToList();
        foreach (Employee emp in emps)
        {
          if (emp.Username == user_data.Username && emp.Password == user_data.Password)
          {
            return Ok(emp);
          }
        }
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest("Error en Login");
      }
    }
  }
}
