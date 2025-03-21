using MediatR;
using Wallet.Host.Dto;
using Wallet.Host.Services.Contracts;

namespace Wallet.Host.Features.Wallet.Queries.GetWalletBalance
{
    public class GetWalletBalanceQueryHandler : IRequestHandler<GetWalletBalanceQuery, WalletBalanceDto>
    {
        private readonly IWalletService _walletService;

        public GetWalletBalanceQueryHandler(IWalletService walletService)
        {
            _walletService = walletService;
        }

        public async Task<WalletBalanceDto> Handle(GetWalletBalanceQuery request, CancellationToken cancellationToken)
        {
            var walletBalanceDto = await _walletService.GetWalletBalance(request.WalletId, request.ProfileId);

            return walletBalanceDto;
        }
    }
}
