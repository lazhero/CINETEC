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
    public List<Employee> Get()
    {
      try
      {
        return Db.Employees.ToList();
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }

    [HttpPost]
    public void Post([FromBody]Employee new_emp)
    {
      try
      {
        Db.Employees.Add(new_emp);
        Db.SaveChanges();
      }
      catch (Exception e) {
        throw new ArgumentException(e.ToString());
      }
    }

    [HttpPut]
    public void Put([FromBody] Employee new_emp) {
      try
      {
        Db.Employees.Update(new_emp);
        Db.SaveChanges();
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }
    [HttpDelete]
    public void Delete([FromBody] Employee new_emp)
    {
      try
      {
        Db.Employees.Remove(new_emp);
        Db.SaveChanges();
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }
  }
}
