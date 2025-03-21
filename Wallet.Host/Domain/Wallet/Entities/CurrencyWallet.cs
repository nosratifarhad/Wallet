namespace Wallet.Host.Domain.Wallet.Entities
{
    public class CurrencyWallet : BaseEntity
    {
        public int WalletId { get; set; }
        public string CurrencyCode { get; set; }
    }
}
