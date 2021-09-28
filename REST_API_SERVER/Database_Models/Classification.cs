using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Classification
    {
        public Classification()
        {
            MovieClassifications = new HashSet<MovieClassification>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public short? Initial { get; set; }
        public short? Final { get; set; }

        public virtual ICollection<MovieClassification> MovieClassifications { get; set; }
    }
}
