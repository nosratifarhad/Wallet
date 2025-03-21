using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Domain.Wallet
{
    public interface ITransactionWriteRepository
    {
        Task ChashIn(Transaction transaction);

        Task ChashOut(Transaction transaction);
    }
}
