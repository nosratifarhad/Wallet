using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Domain.Wallet.Entities
{
    public class UserWallet : BaseEntity
    {
        public int ProfileId { get; set; }

        public string Title { get; set; }

        public WalletStatus Status { get; set; }

        public string CurrencyCode { get; set; }
    }
}
