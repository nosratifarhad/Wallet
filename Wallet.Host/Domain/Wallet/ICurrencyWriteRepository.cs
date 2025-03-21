using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Domain.Wallet
{
    public interface ICurrencyWriteRepository
    {
        Task CreateCurrency(Currency currency);
        Task UpdateCurrency(Currency currency);
    }
}
