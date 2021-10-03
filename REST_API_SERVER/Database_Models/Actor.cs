﻿using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Actor
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string MovieName { get; set; }

        public virtual Movie MovieNameNavigation { get; set; }
    }
}