using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Repositories
{
    public class TransactionWriteRepository : ITransactionWriteRepository
    {
        public Task ChashIn(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public Task ChashOut(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
