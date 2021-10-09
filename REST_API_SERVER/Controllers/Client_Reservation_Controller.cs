using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;

namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Client/Seats")]
  public class Client_Reservation_Controller : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();
    [HttpGet]
    public List<Seat> Get(int projection_id)
    {
      try
      {
        List<Seat> res = Db.Seats.Where(s => s.ProjectionId == projection_id).ToList();
        return res;
      }
      catch (Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }
  
    [HttpPut]
    public void Put([FromBody] Reservation_info info)
    {
      try
      {
        foreach(int s in info.seats)
        {
          var seat = Db.Seats.Find(info.proj_id,s);
          if(seat.State == 0)
          {
            seat.State = 1;
            seat.InvoiceId = info.invoice_id;
          }
          else
          {
            throw new ArgumentException("Seat Taken");
          }
        }
        Db.SaveChanges();
      }catch(Exception e)
      {
        throw new ArgumentException(e.ToString());
      }
    }
  }
}
