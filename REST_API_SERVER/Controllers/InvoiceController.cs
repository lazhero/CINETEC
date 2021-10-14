using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace REST_API_SERVER.Controllers
{
  [ApiController]
  [Route("Invoice")]
  public class InvoiceController : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();
    [HttpGet]
    public ActionResult Get(int Invoice_id)
    {
      try {
        Invoice inv = Db.Invoices.Include(i=> i.ClientInvoices).Where(i=> i.Id==Invoice_id).Single();
        Client cli = Db.Clients.Find(inv.ClientInvoices.Single().ClientId, inv.ClientInvoices.Single().ClientUsername);

        XmlDocument doc = new XmlDocument();
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = doc.DocumentElement;
        doc.InsertBefore(xmlDeclaration, root);

        XmlElement emp = doc.CreateElement("Clave");
        XmlText emp_id = doc.CreateTextNode("564465484621354");
        emp.AppendChild(emp_id);
        doc.AppendChild(emp);

        XmlElement invoice = doc.CreateElement("NumeroConsecutivo");
        XmlText invoice_num = doc.CreateTextNode(Invoice_id.ToString());
        invoice.AppendChild(invoice_num);
        doc.AppendChild(invoice);

        XmlElement date = doc.CreateElement("FechaEmision");
        XmlText _date = doc.CreateTextNode(Invoice_id.ToString(DateTime.Now.ToString()));
        date.AppendChild(_date);
        doc.AppendChild(date);

        XmlElement emisor = doc.CreateElement("Emisor");
        XmlElement emisor_nombre = doc.CreateElement("Nombre");
        XmlText emisor_nombre_text = doc.CreateTextNode("CineTEC");
        emisor_nombre.AppendChild(emisor_nombre_text);
        emisor.AppendChild(emisor_nombre);

        XmlElement Id = doc.CreateElement("Identificacion");
        XmlElement tipo = doc.CreateElement("Type");
        XmlText text = doc.CreateTextNode("02");
        text.AppendChild(tipo);
        Id.AppendChild(tipo);

        XmlElement Num = doc.CreateElement("Numero");
        XmlText num_text = doc.CreateTextNode("51654561");
        Num.AppendChild(num_text);



        doc.Save("D:\\Github Repositorios\\CINETEC\\REST_API_SERVER\\Invoices\\"+Invoice_id.ToString()+".xml");



        return Ok();
      }catch(Exception e)
      {
        return BadRequest(e.Message);
      }
      
    }
  }
}
