using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

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
        Invoice inv = Db.Invoices.Include(i=> i.ClientInvoices).ThenInclude(i=>i.Client).Where(i=> i.Id==Invoice_id).Single();
        Client cli = inv.ClientInvoices.Where(i=>i.InvoiceId == Invoice_id).Single().Client;
        List<Seat> seats = Db.Seats.Include(s=>s.Projection).ThenInclude(p=>p.MovieOriginalNameNavigation).Where(s=>s.InvoiceId==Invoice_id).ToList();
        Cinema cine = Db.Cinemas.Find(seats[0].Projection.CinemaName);
        Movie mov = seats[0].Projection.MovieOriginalNameNavigation;

        XmlDocument doc = new XmlDocument();
        XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
        XmlElement root = doc.DocumentElement;
        doc.InsertBefore(xmlDeclaration, root);

        XmlElement body = doc.CreateElement(string.Empty, "FacturaElectronica", string.Empty);
        doc.AppendChild(body);

        XmlElement emp = doc.CreateElement("Clave");
        XmlText emp_id = doc.CreateTextNode("56446548462546545648964XD1321351354");
        emp.AppendChild(emp_id);
        body.AppendChild(emp);

        XmlElement invoice = doc.CreateElement("NumeroConsecutivo");
        XmlText invoice_num = doc.CreateTextNode(Invoice_id.ToString());
        invoice.AppendChild(invoice_num);
        body.AppendChild(invoice);

        XmlElement date = doc.CreateElement("FechaEmision");
        XmlText _date = doc.CreateTextNode(Invoice_id.ToString(DateTime.Now.ToString()));
        date.AppendChild(_date);
        body.AppendChild(date);

        XmlElement emisor = doc.CreateElement("Emisor");
        XmlElement emisor_nombre = doc.CreateElement("Nombre");
        XmlText emisor_nombre_text = doc.CreateTextNode("CineTEC Cinemas");
        emisor_nombre.AppendChild(emisor_nombre_text);
        emisor.AppendChild(emisor_nombre);

        XmlElement Id = doc.CreateElement("Identificacion");
        XmlElement tipo = doc.CreateElement("Type");
        XmlText text = doc.CreateTextNode("02");
        tipo.AppendChild(text);
        Id.AppendChild(tipo);
        XmlElement Num = doc.CreateElement("Numero");
        XmlText num_text = doc.CreateTextNode("51654561");
        Num.AppendChild(num_text);
        Id.AppendChild(Num);
        emisor.AppendChild(Id);

        XmlElement ubicacion = doc.CreateElement("Ubicacion");
        XmlText texto = doc.CreateTextNode(cine.Location);
        ubicacion.AppendChild(texto);
        emisor.AppendChild(ubicacion);
        body.AppendChild(emisor);

        XmlElement Receptor = doc.CreateElement("Receptor");
        XmlElement Nombre = doc.CreateElement("Nombre");
        XmlText nom = doc.CreateTextNode(cli.FirstName+" "+cli.MiddleName+" "+cli.LastName+" "+cli.SecondLastName);
        Nombre.AppendChild(nom);
        XmlElement Cli_id = doc.CreateElement("Identificacion");
        XmlElement Cli_tipo = doc.CreateElement("Type");
        XmlText Cli_tipo_text = doc.CreateTextNode("1");
        Cli_tipo.AppendChild(Cli_tipo_text);
        Cli_id.AppendChild(Cli_tipo);
        XmlElement Cli_numero = doc.CreateElement("Numero");
        XmlText cli_id_card = doc.CreateTextNode(cli.IdCard.ToString());
        Cli_numero.AppendChild(cli_id_card);
        Cli_id.AppendChild(Cli_numero);
        Receptor.AppendChild(Cli_id);
        XmlElement Tel = doc.CreateElement("Telefono");
        XmlElement codigo_pais = doc.CreateElement("CodigoPais");
        XmlText num_cod = doc.CreateTextNode("506");
        codigo_pais.AppendChild(num_cod);
        XmlElement num_tel = doc.CreateElement("NumTelefono");
        XmlText num_telf = doc.CreateTextNode(cli.PhoneNum.ToString());
        num_tel.AppendChild(num_telf);
        Tel.AppendChild(codigo_pais);
        Tel.AppendChild(num_tel);
        Receptor.AppendChild(Tel);

        body.AppendChild(Receptor);

        XmlElement CondicionVenta = doc.CreateElement("CondicionVenta");
        CondicionVenta.AppendChild(doc.CreateTextNode("1"));
        body.AppendChild(CondicionVenta);
        XmlElement MedioPago = doc.CreateElement("MedioPago");
        MedioPago.AppendChild(doc.CreateTextNode("1"));
        body.AppendChild(MedioPago);

        XmlElement DetalleServicio = doc.CreateElement("DetalleServicio");
        body.AppendChild(DetalleServicio);

        XmlElement LineasDetalle1 = doc.CreateElement("LineaDetalle");
        XmlElement Linea1 = doc.CreateElement("NumeroLinea");
        Linea1.AppendChild(doc.CreateTextNode("1"));
        XmlElement CodigoMaster1 = doc.CreateElement("Codigo");
        XmlElement codigo_type1 = doc.CreateElement("Tipo");
        codigo_type1.AppendChild(doc.CreateTextNode("0"));
        XmlElement Codigo1 = doc.CreateElement("Codigo");
        Codigo1.AppendChild(doc.CreateTextNode("123412D-3413"));
        CodigoMaster1.AppendChild(codigo_type1);
        CodigoMaster1.AppendChild(Codigo1);
        LineasDetalle1.AppendChild(Linea1);
        LineasDetalle1.AppendChild(CodigoMaster1);
        XmlElement Cantidad_Adult1 = doc.CreateElement("Cantidad");
        Cantidad_Adult1.AppendChild(doc.CreateTextNode(inv.NumAdultTicket.ToString()));
        LineasDetalle1.AppendChild(Cantidad_Adult1);
        XmlElement Unidad_medida_1 =doc.CreateElement("UnidadMedida");
        Unidad_medida_1.AppendChild(doc.CreateTextNode("Unid"));
        LineasDetalle1.AppendChild(Unidad_medida_1);
        XmlElement detalle1 = doc.CreateElement("Detalle");
        detalle1.AppendChild(doc.CreateTextNode("Ticketes para adultos"));
        LineasDetalle1.AppendChild(detalle1);
        XmlElement Precio_unit1 = doc.CreateElement("PrecioUnitario");
        Precio_unit1.AppendChild(doc.CreateTextNode(mov.AdultPrice.ToString()));
        LineasDetalle1.AppendChild(Precio_unit1);
        XmlElement Subtotal1 = doc.CreateElement("SubTotal");
        int monto_adultos = (int)(mov.AdultPrice * inv.NumAdultTicket);
        Subtotal1.AppendChild(doc.CreateTextNode(monto_adultos.ToString()));
        XmlElement Monto_total1 = doc.CreateElement("MontoTotal");
        Monto_total1.AppendChild(doc.CreateTextNode(monto_adultos.ToString()));
        LineasDetalle1.AppendChild(Subtotal1);
        LineasDetalle1.AppendChild(Monto_total1);

        XmlElement LineasDetalle2 = doc.CreateElement("LineaDetalle");
        XmlElement Linea2 = doc.CreateElement("NumeroLinea");
        Linea1.AppendChild(doc.CreateTextNode("2"));
        XmlElement CodigoMaster2 = doc.CreateElement("Codigo");
        XmlElement codigo_type2 = doc.CreateElement("Tipo");
        codigo_type2.AppendChild(doc.CreateTextNode("0"));
        XmlElement Codigo2 = doc.CreateElement("Codigo");
        Codigo2.AppendChild(doc.CreateTextNode("123412D-3414"));
        CodigoMaster2.AppendChild(codigo_type2);
        CodigoMaster2.AppendChild(Codigo2);
        LineasDetalle2.AppendChild(Linea2);
        LineasDetalle2.AppendChild(CodigoMaster2);
        XmlElement Cantidad_Kid = doc.CreateElement("Cantidad");
        Cantidad_Kid.AppendChild(doc.CreateTextNode(inv.NumKidTicket.ToString()));
        LineasDetalle2.AppendChild(Cantidad_Kid);
        XmlElement Unidad_medida_2 = doc.CreateElement("UnidadMedida");
        Unidad_medida_2.AppendChild(doc.CreateTextNode("Unid"));
        LineasDetalle2.AppendChild(Unidad_medida_2);
        XmlElement detalle2 = doc.CreateElement("Detalle");
        detalle2.AppendChild(doc.CreateTextNode("ticketes para los infantes"));
        LineasDetalle2.AppendChild(detalle2);
        XmlElement Precio_unit2 = doc.CreateElement("PrecioUnitario");
        Precio_unit2.AppendChild(doc.CreateTextNode(mov.KidPrice.ToString()));
        LineasDetalle2.AppendChild(Precio_unit2);
        XmlElement Subtotal2 = doc.CreateElement("SubTotal");
        int monto_infantes = (int)(mov.KidPrice * inv.NumKidTicket);
        Subtotal2.AppendChild(doc.CreateTextNode(monto_infantes.ToString()));
        XmlElement Monto_total2 = doc.CreateElement("MontoTotal");
        Monto_total2.AppendChild(doc.CreateTextNode(monto_infantes.ToString()));
        LineasDetalle2.AppendChild(Subtotal2);
        LineasDetalle2.AppendChild(Monto_total2);

        XmlElement LineasDetalle3 = doc.CreateElement("LineaDetalle");
        XmlElement Linea3 = doc.CreateElement("NumeroLinea");
        Linea3.AppendChild(doc.CreateTextNode("3"));
        XmlElement CodigoMaster3 = doc.CreateElement("Codigo");
        XmlElement codigo_type3 = doc.CreateElement("Tipo");
        codigo_type3.AppendChild(doc.CreateTextNode("0"));
        XmlElement Codigo3 = doc.CreateElement("Codigo");
        Codigo3.AppendChild(doc.CreateTextNode("123412D-3415"));
        CodigoMaster3.AppendChild(codigo_type3);
        CodigoMaster3.AppendChild(Codigo3);
        LineasDetalle3.AppendChild(Linea3);
        LineasDetalle3.AppendChild(CodigoMaster3);
        XmlElement Cantidad_elder = doc.CreateElement("Cantidad");
        Cantidad_elder.AppendChild(doc.CreateTextNode(inv.NumElderTicket.ToString()));
        LineasDetalle3.AppendChild(Cantidad_elder);
        XmlElement Unidad_medida_3 = doc.CreateElement("UnidadMedida");
        Unidad_medida_3.AppendChild(doc.CreateTextNode("Unid"));
        LineasDetalle3.AppendChild(Unidad_medida_3);
        XmlElement detalle3 = doc.CreateElement("Detalle");
        detalle3.AppendChild(doc.CreateTextNode("ticketes para los adultos mayores"));
        LineasDetalle3.AppendChild(detalle3);
        XmlElement Precio_unit3 = doc.CreateElement("PrecioUnitario");
        Precio_unit3.AppendChild(doc.CreateTextNode(mov.ElderPrice.ToString()));
        LineasDetalle3.AppendChild(Precio_unit3);
        XmlElement Subtotal3 = doc.CreateElement("SubTotal");
        int monto_mayores = (int)(mov.ElderPrice * inv.NumElderTicket);
        Subtotal3.AppendChild(doc.CreateTextNode(monto_mayores.ToString()));
        XmlElement Monto_total3 = doc.CreateElement("MontoTotal");
        Monto_total3.AppendChild(doc.CreateTextNode(monto_mayores.ToString()));
        LineasDetalle3.AppendChild(Subtotal3);
        LineasDetalle3.AppendChild(Monto_total3);
        DetalleServicio.AppendChild(LineasDetalle1);
        DetalleServicio.AppendChild(LineasDetalle2);
        DetalleServicio.AppendChild(LineasDetalle3);

        XmlElement Resumen = doc.CreateElement("ResumenFactura");
        XmlElement CodigoMoneda = doc.CreateElement("CodigoMoneda");
        CodigoMoneda.AppendChild(doc.CreateTextNode("CRC"));
        XmlElement TipoCambio = doc.CreateElement("TipoCambio");
        TipoCambio.AppendChild(doc.CreateTextNode("1"));
        XmlElement Ser_gravados = doc.CreateElement("TotalServGravados");
        int monto_total_final = monto_mayores + monto_infantes + monto_adultos;
        Ser_gravados.AppendChild(doc.CreateTextNode(monto_total_final.ToString()));
        XmlElement tot_grav = doc.CreateElement("TotalGravado");
        tot_grav.AppendChild(doc.CreateTextNode(monto_total_final.ToString()));
        XmlElement tot_val = doc.CreateElement("TotalVenta");
        tot_val.AppendChild(doc.CreateTextNode(monto_total_final.ToString()));
        XmlElement tot_imp = doc.CreateElement("TotalImpuesto");
        tot_imp.AppendChild(doc.CreateTextNode((monto_total_final*0.13).ToString()));
        XmlElement tot_comp = doc.CreateElement("TotalComprobante");
        tot_comp.AppendChild(doc.CreateTextNode((monto_total_final + monto_total_final * 0.13).ToString()));

        Resumen.AppendChild(CodigoMoneda);
        Resumen.AppendChild(TipoCambio);
        Resumen.AppendChild(Ser_gravados);
        Resumen.AppendChild(tot_grav);
        Resumen.AppendChild(tot_val);
        Resumen.AppendChild(tot_imp);
        Resumen.AppendChild(tot_comp);

        body.AppendChild(Resumen);

        doc.Save("D:\\Github Repositorios\\CINETEC\\REST_API_SERVER\\Invoices\\"+Invoice_id.ToString()+".xml");

        PdfDocument file = new PdfDocument();
        PdfPage page = file.AddPage();
        XGraphics gfx = XGraphics.FromPdfPage(page);

        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        // Create a font
        XFont font = new XFont("Times", 20, XFontStyle.Bold);
        XFont font2 = new XFont("Times", 12, XFontStyle.Regular);
        // Draw the text
        gfx.DrawString("Factura Electronica", font, XBrushes.Black,
          new XRect(0, 0, page.Width, page.Height),
          XStringFormats.TopCenter);

        gfx.DrawString(cine.Location, font, XBrushes.Black,
         new XRect(0, 20, page.Width, page.Height),
         XStringFormats.TopCenter);

        gfx.DrawString("Fecha:"+DateTime.Today.ToShortDateString(), font2, XBrushes.Black,
         new XRect(60, 70, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Numero consecutivo:"+Invoice_id.ToString(), font2, XBrushes.Black,
         new XRect(400, 70, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Cedula:51654561" + Invoice_id.ToString(), font2, XBrushes.Black,
         new XRect(60, 90, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Clave:56446548462546545648964XD1321351354", font2, XBrushes.Black,
         new XRect(60, 110, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Sucursal:"+cine.Location, font2, XBrushes.Black,
         new XRect(60, 130, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Cliente:" + cli.FirstName+" "+cli.MiddleName+" "+cli.LastName+" "+cli.SecondLastName, font2, XBrushes.Black,
         new XRect(60, 190, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("cedula:" + cli.IdCard, font2, XBrushes.Black,
         new XRect(60, 210, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("telefono:" + cli.PhoneNum.ToString(), font2, XBrushes.Black,
         new XRect(400, 190, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Productos:", font2, XBrushes.Black,
         new XRect(60, 250, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Precio:", font2, XBrushes.Black,
         new XRect(435, 250, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Ticketes para adultos: " + inv.NumAdultTicket +"  ......................................................................................"+ monto_adultos, font2, XBrushes.Black,
         new XRect(60, 280, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Ticketes para kids: " + inv.NumKidTicket + "  .........................................................................................." + monto_infantes, font2, XBrushes.Black,
         new XRect(60, 310, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Ticketes para Elders: " + inv.NumElderTicket + "  ......................................................................................." + monto_mayores, font2, XBrushes.Black,
         new XRect(60, 340, page.Width, page.Height),
         XStringFormats.TopLeft);

        gfx.DrawString("Subtotal: " + monto_total_final, font2, XBrushes.Black,
          new XRect(392, 370, page.Width, page.Height),
          XStringFormats.TopLeft);

        gfx.DrawString("Impuesto: " + monto_total_final*0.13, font2, XBrushes.Black,
          new XRect(392, 400, page.Width, page.Height),
          XStringFormats.TopLeft);

        gfx.DrawString("Total: " + (monto_total_final+ monto_total_final * 0.13), font2, XBrushes.Black,
          new XRect(392, 430, page.Width, page.Height),
          XStringFormats.TopLeft);

        string filename = "D:\\Github Repositorios\\CINETEC\\REST_API_SERVER\\Invoices\\"+inv.Id.ToString()+".pdf";
        file.Save(filename);
        var dataBytes = System.IO.File.ReadAllBytes(filename);

        
        return Ok(File(dataBytes, "application/pdf", "Comprobante "+Invoice_id+".pdf"));
      }catch(Exception e)
      {
        return BadRequest(e.Message);
      }
      
    }
  }
}
