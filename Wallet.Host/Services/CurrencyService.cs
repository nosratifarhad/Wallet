using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Dto;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly IWalletReadRepository _walletReadRepository;
        private readonly IWalletWriteRepository _walletWriteRepository;

        public CurrencyService(IWalletReadRepository walletReadRepository,
            IWalletWriteRepository walletWriteRepository)
        {
            _walletReadRepository = walletReadRepository;
            _walletWriteRepository = walletWriteRepository;
        }

        public async Task CreateCurrency(CurrencyDto currencytDto)
        {
            var currency =
                await _walletReadRepository.GetCurrency(currencytDto.Code);
            if (currency is not null)
                throw new Exception("Currency Is Existing");

            currency = new Currency()
            {
                Code = currencytDto.Code,
                Name = currencytDto.Name,
                Ratio = currencytDto.Ratio
            };

            await _walletWriteRepository.CreateCurrency(currency);
        }

        public async Task UpdateCurrency(CurrencyDto currencytDto)
        {
            var currency =
                    await _walletReadRepository.GetCurrency(currencytDto.Code);
            if (currency is null)
                throw new Exception("Currency Is Existing");

            currency = new Currency()
            {
                Name = currencytDto.Name,
                Ratio = currencytDto.Ratio
            };

            await _walletWriteRepository.UpdateCurrency(currency);
        }

        public async Task<CurrencyDto> GetCurrency(string code)
        {
            var currency =
                    await _walletReadRepository.GetCurrency(code);
            if (currency is null)
                throw new Exception("Currency Is Existing");

            var currencyDto = new CurrencyDto(currency.Code, currency.Name, currency.Ratio);

            return currencyDto;
        }

        public async Task<IEnumerable<CurrencyDto>> GetCurrency()
        {
            var currencies =
                    await _walletReadRepository.GetCurrencies();
            if (!currencies.Any())
                throw new Exception("Currency Is Existing");
            var currenciesDtos = new List<CurrencyDto>();
            
            foreach (var item in currencies)
            {
                currenciesDtos.Add(new CurrencyDto(item.Code, item.Name, item.Ratio));
            }

            return currenciesDtos;
        }

    }
}
