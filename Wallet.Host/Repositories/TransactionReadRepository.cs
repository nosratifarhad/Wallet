using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Repositories
{
    public class TransactionReadRepository : ITransactionReadRepository
    {
        public Task<Transaction> GetSumAmountTransaction(int walletId, TransactionKind kind)
        {
            throw new NotImplementedException();
        }
    }
}
