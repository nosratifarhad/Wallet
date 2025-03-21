using Wallet.Host.Dto;

namespace Wallet.Host.Services.Contracts
{
    public interface ICurrencyService
    {
        Task CreateCurrency(CurrencyDto currencytDto);
        Task UpdateCurrency(CurrencyDto currencytDto);
        Task<CurrencyDto> GetCurrency(string code);
        Task<IEnumerable<CurrencyDto>> GetCurrency();
    }
}
