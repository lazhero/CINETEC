using REST_API_SERVER.Database_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_SERVER.Classes
{
  public class Projection_Room:Projection
  {
    public short? Columns { get; set; }
    public short? Rows { get; set; }
  }
}
