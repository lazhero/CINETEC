﻿using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER
{
    public partial class MovieClassification
    {
        public string MovieOriginalName { get; set; }
        public int ClassificationId { get; set; }

        public virtual Classification Classification { get; set; }
        public virtual Movie MovieOriginalNameNavigation { get; set; }
    }
}
