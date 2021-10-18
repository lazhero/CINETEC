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
            ProjectionInvoices = new HashSet<ProjectionInvoice>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int? TicketNumber { get; set; }
        public int? Total { get; set; }

        public virtual ICollection<ClientInvoice> ClientInvoices { get; set; }
        public virtual ICollection<ProjectionInvoice> ProjectionInvoices { get; set; }
    }
}
