using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Entities;

namespace Wallet.Host.Repositories
{
    public class CurrencyReadRepository : ICurrencyReadRepository
    {
        public Task<IEnumerable<Currency>> GetCurrencies()
        {
            throw new NotImplementedException();
        }

        public Task<Currency> GetCurrency(string Code)
        {
            throw new NotImplementedException();
        }
    }
}
