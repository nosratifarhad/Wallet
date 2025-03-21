using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Domain.Wallet
{
    public interface IWalletWriteRepository
    {
        Task CreateWallet(UserWallet userWallet);
        


    }
}
