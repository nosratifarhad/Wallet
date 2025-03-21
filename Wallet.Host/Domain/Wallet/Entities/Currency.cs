namespace Wallet.Host.Domain.Wallet.Entities
{
    public class Currency : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Ratio { get; set; }
        public DateTime ModifiedDateUtc { get; set; }
        public ICollection<CurrencyWallet> Wallets { get; set; }
    }
}
