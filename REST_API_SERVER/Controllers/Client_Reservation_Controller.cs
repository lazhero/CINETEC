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
    public ActionResult Get(int projection_id)
    {
      try
      {
        List<Seat> res = Db.Seats.Where(s => s.ProjectionId == projection_id).ToList();
        var PR = Db.Projections.Find(projection_id);
        var room = Db.Rooms.Where(r => r.CinemaName == PR.CinemaName && r.Number == PR.RoomNumber).Single();
        
        return Ok(res);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  
    [HttpPut]
    public ActionResult Put([FromBody] Reservation_info info)
    {
      try
      {
        var cli = Db.Clients.Where(c=> c.Username == info.client_username).Single();
        var invoice = new Invoice();
        //generate invoice data from info invoice.
        invoice.Id = Db.Invoices.Max(i=>i.Id)+1; 
        invoice.NumAdultTicket=info.adult_tickets;
        invoice.NumElderTicket = info.elder_tickets;
        invoice.NumKidTicket = info.kid_tickets;
        invoice.Description = "Compra de ticketes";
        List<Seat> temp = new();
        foreach (int i in info.seats)
        {
          temp.Add(Db.Seats.Where(s=>s.SeatNumber==i && s.ProjectionId==info.proj_id).Single());
        }
        invoice.Seats = temp;
        Db.Invoices.Add(invoice);

        //create client invoice relation
        var cli_inv = new ClientInvoice();
        cli_inv.ClientId = cli.IdCard;
        cli_inv.InvoiceId = invoice.Id;
        cli_inv.ClientUsername = cli.Username;
        Db.ClientInvoices.Add(cli_inv);

        foreach(Seat s in temp)
        {
          if(s.State == 0)
          {
            s.State = 1;
            s.InvoiceId = invoice.Id;
          }
          else
          {
            return BadRequest("a seat is already taken");
          }
        }
        Db.SaveChanges();
        return Ok(invoice.Id);
      }catch(Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}
