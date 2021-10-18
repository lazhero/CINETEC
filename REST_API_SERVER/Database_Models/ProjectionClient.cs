using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class ProjectionClient
    {
        public int ProjectionId { get; set; }
        public int ClientIdCard { get; set; }
        public string ClientUsername { get; set; }

        public virtual Client Client { get; set; }
        public virtual Projection Projection { get; set; }
    }
}
