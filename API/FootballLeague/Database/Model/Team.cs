using System.Collections.Generic;

namespace Database.Model
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamCode { get; set; }
        public virtual ICollection<PlayedMatch> PlayedMatches { get; set; }
        //public virtual PlayedMatch PlayedMatch { get; set; }
    }
}
