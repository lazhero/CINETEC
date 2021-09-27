﻿using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER
{
    public partial class Client
    {
        public Client()
        {
            ClientInvoices = new HashSet<ClientInvoice>();
            ProjectionClients = new HashSet<ProjectionClient>();
        }

        public int IdCard { get; set; }
        public DateTime? Birthdate { get; set; }
        public int? PhoneNum { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }

        public virtual ICollection<ClientInvoice> ClientInvoices { get; set; }
        public virtual ICollection<ProjectionClient> ProjectionClients { get; set; }
    }
}
