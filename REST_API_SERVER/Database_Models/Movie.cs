using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Movie
    {
        public Movie()
        {
            Actors = new HashSet<Actor>();
            Directors = new HashSet<Director>();
            MovieClassifications = new HashSet<MovieClassification>();
            Projections = new HashSet<Projection>();
        }

        public string OriginalName { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int? TimeLength { get; set; }
        public int? KidPrice { get; set; }
        public int? AdultPrice { get; set; }
        public int? ElderPrice { get; set; }

        public virtual ICollection<Actor> Actors { get; set; }
        public virtual ICollection<Director> Directors { get; set; }
        public virtual ICollection<MovieClassification> MovieClassifications { get; set; }
        public virtual ICollection<Projection> Projections { get; set; }
    }
}
