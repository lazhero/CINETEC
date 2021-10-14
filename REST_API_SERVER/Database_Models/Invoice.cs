using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            ClientInvoices = new HashSet<ClientInvoice>();
            Seats = new HashSet<Seat>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? NumElderTicket { get; set; }
        public int? NumKidTicket { get; set; }
        public int? NumAdultTicket { get; set; }

        public virtual ICollection<ClientInvoice> ClientInvoices { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
}
