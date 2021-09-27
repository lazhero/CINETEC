using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER
{
    public partial class Projection
    {
        public Projection()
        {
            ProjectionClients = new HashSet<ProjectionClient>();
            ProjectionInvoices = new HashSet<ProjectionInvoice>();
            ProjectionRooms = new HashSet<ProjectionRoom>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? InitialTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string MovieOriginalName { get; set; }

        public virtual Movie MovieOriginalNameNavigation { get; set; }
        public virtual ICollection<ProjectionClient> ProjectionClients { get; set; }
        public virtual ICollection<ProjectionInvoice> ProjectionInvoices { get; set; }
        public virtual ICollection<ProjectionRoom> ProjectionRooms { get; set; }
    }
}
