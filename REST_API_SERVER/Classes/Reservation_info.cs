using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_SERVER.Database_Models
{
  public class Reservation_info
  {
    public List<int> seats { get; set; }
    public int proj_id { get; set; }
    public string client_username { get; set; }
    public int adult_tickets { get; set; }
    public int kid_tickets { get; set; }
    public int elder_tickets { get; set; }
  }
}
