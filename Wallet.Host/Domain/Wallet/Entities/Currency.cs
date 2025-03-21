namespace Wallet.Host.Domain.Wallet.Entities
{
    public class Currency : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Ratio { get; set; }
        public DateTime ModifiedDateUtc { get; set; }
        public ICollection<Currency> Currencies { get; set; }
    }
}
