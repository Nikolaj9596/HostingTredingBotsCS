namespace TradingPlatform.Domain
{
    public class TradingPlatform
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public bool is_active { get; set; }
        public string? referral_link { get; set; }
        public string? api_link { get; set; }
        public string? test_api_link { get; set; }
        public string? docs_link { get; set; }
        public string site_link { get; set; }
        public string? icon { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ArchivedAt { get; set; }
    }
}
