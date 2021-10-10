using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Admin/Projections")]
  public class Admin_projections_Controller : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();

    [HttpGet]
    public List<Projection> Get()
    {
      try
      {
        var Projecs = Db.Projections.ToList();
        return Projecs;
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }

    [HttpPut]
    public void Put([FromBody] Projection proj)
    {
      try
      {
        Db.Projections.Update(proj);
        Db.SaveChanges();
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }

    [HttpPost]
    public void Post([FromBody] Projection proj)
    {
      try
      {
        Db.Projections.Add(proj);
        Db.SaveChanges();
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }
    [HttpDelete]
    public void Delete([FromBody] Projection proj)
    {
      try
      {
        Db.Projections.Remove(proj);
        Db.SaveChanges();
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }
  }
}
