namespace Database.Model
{
    public class PlayedMatchList
    {
        public int ID { get; set; }
        public int MatchesPlayed { get; set; }
        public int Won { get; set; }
        public int Lost { get; set; }
        public int Draw { get; set; }
        public int Points { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
