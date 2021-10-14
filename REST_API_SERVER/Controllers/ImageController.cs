using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using REST_API_SERVER.Database_Models;
using Microsoft.EntityFrameworkCore;
namespace REST_API_SERVER.Controllers
{
  [Route("Images")]
  public class ImageController : Controller
  {
    CineTEC_Context Db = new CineTEC_Context();
    [HttpGet]
    public ActionResult Get (string path)
    {
      try
      {
        byte[] image = System.IO.File.ReadAllBytes(path);
        return Ok(File(image, "image/png"));
      }
      catch (Exception e) {
        return BadRequest(e.Message);
      }
      return View();
    }
  }
}
