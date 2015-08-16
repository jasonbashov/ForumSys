namespace ForumSys.Data.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int PostId { get; set; }

        //TODO: Change to enum
        public int VoteValue { get; set; }
    }
}
