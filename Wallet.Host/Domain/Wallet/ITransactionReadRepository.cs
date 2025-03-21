using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Domain.Wallet
{
    public interface ITransactionReadRepository
    {
        Task<Transaction> GetSumAmountTransaction(int walletId, TransactionKind kind);

    }
}
