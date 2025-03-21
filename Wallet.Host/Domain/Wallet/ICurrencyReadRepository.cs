using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Domain.Wallet
{
    public interface ICurrencyReadRepository
    {
        Task<Currency> GetCurrency(string Code);

        Task<IEnumerable<Currency>> GetCurrencies();

    }
}
