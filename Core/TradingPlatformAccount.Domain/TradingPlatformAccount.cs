namespace TradingPlatformAccount.Domain
{

    public class TradingPlatformAccount
    {
        public Guid Id { get; set; }
        public Guid TradingPlatformId { get; set; }
        public Guid UserId { get; set; }
        public Boolean IsActive { get; set; }
        public String ApiKey { get; set; }
        public String? TestApiKey { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ArchivedAt { get; set; }
    }
}

