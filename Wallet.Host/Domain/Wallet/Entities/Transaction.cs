using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Domain.Wallet.Entities
{
    public class Transaction : BaseEntity
    {
        public int WalletId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public TransactionKind Kind { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public int FinancialVoucherId { get; set; }
    }
}
