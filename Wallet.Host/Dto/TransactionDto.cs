using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Dto
{
    public class TransactionDto
    {
        public int WalletId { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int FinancialVoucherId { get; set; }
    }
}
