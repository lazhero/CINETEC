using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER
{
    public partial class ProjectionClient
    {
        public int ProjectionId { get; set; }
        public int ClientIdCard { get; set; }

        public virtual Client ClientIdCardNavigation { get; set; }
        public virtual Projection Projection { get; set; }
    }
}
