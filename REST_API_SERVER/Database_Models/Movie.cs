using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class Movie
    {
        public Movie()
        {
            ActorMovies = new HashSet<ActorMovie>();
            MovieClassifications = new HashSet<MovieClassification>();
            Projections = new HashSet<Projection>();
        }

        public string OriginalName { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? TimeLength { get; set; }
        public int? KidPrice { get; set; }
        public int? AdultPrice { get; set; }
        public int? ElderPrice { get; set; }
        public string DirectorFirstName { get; set; }
        public string DirectorMiddleName { get; set; }
        public string DirectorLastName { get; set; }
        public string DirectorSecondLastName { get; set; }

        public virtual Director Director { get; set; }
        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
        public virtual ICollection<MovieClassification> MovieClassifications { get; set; }
        public virtual ICollection<Projection> Projections { get; set; }
    }
}
