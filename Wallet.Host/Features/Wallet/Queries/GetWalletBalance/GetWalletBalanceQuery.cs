using MediatR;
using Wallet.Host.Dto;

namespace Wallet.Host.Features.Wallet.Queries.GetWalletBalance
{
    public record GetWalletBalanceQuery(int WalletId, int ProfileId) : IRequest<WalletBalanceDto>
    {
    }
}
