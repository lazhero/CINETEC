using System;
using System.Collections.Generic;

#nullable disable

namespace REST_API_SERVER.Database_Models
{
    public partial class ActorMovie
    {
        public string ActorFirstName { get; set; }
        public string ActorMiddleName { get; set; }
        public string ActorLastName { get; set; }
        public string ActorSecondLastName { get; set; }
        public string MovieOriginalName { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Movie MovieOriginalNameNavigation { get; set; }
    }
}
