using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Client:Person
    {
        public Client()
        {
            ClientInvoices = new HashSet<ClientInvoice>();
        }

        
        public DateTime? Birthdate { get; set; }


        public virtual ICollection<ClientInvoice> ClientInvoices { get; set; }
    }
}
