using MediatR;
using Wallet.Host.Dto;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Features.Currency.Commands.CreateCurrency
{
    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, Unit>
    {
        private readonly ICurrencyService _walletService;

        public CreateCurrencyCommandHandler(ICurrencyService walletService)
        {
            _walletService = walletService;
        }

        public async Task<Unit> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var createWalletDto = new CurrencyDto(request.Code, request.Name, request.Ratio);

            await _walletService.CreateCurrency(createWalletDto);

            return Unit.Value;
        }
    }
}
