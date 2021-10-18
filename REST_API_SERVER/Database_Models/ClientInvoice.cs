using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class ClientInvoice
    {
        public int ClientId { get; set; }
        public int InvoiceId { get; set; }
        public string ClientUsername { get; set; }

        public virtual Client Client { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
