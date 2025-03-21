using MediatR;

namespace Wallet.Host.Features.Wallet.Commands.CreateWallet
{
    public record CreateCurrencyCommand(string Code, string Name, string Ratio) : IRequest<Unit>
    {                                  
    }
}
