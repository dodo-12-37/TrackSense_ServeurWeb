namespace TrackSense.API.Entities
{
    public class UserToken
    {
        public int TokenId { get; set; }
        public string Token { get; set; }
        public DateTime LastUsed { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
