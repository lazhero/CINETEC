using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API_SERVER.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Admin/Employee")]
  public class Employee_Controller : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();
    [HttpGet]
    public ActionResult Get()
    {
      try
      {
        var emps = Db.Employees.Include(e=>e.Role).ToList();
        return Ok(emps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    public ActionResult Post([FromBody]Employee new_emp)
    {
      try
      {
        Db.Employees.Add(new_emp);
        Db.SaveChanges();
        return Ok();
      }
      catch (Exception e) {
        return BadRequest(e.Message);
      }
    }

    [HttpPut]
    public ActionResult Put([FromBody] Employee new_emp) {
      try
      {
        Db.Employees.Update(new_emp);
        Db.SaveChanges();
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpDelete]
    public ActionResult Delete(int id, string username)
    {
      try
      {
        var emp = Db.Employees.Find(id,username);
        Db.Employees.Remove(emp);
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
