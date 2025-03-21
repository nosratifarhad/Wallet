using MediatR;

namespace Wallet.Host.Features.Currency.Commands.CreateCurrency
{
    public record CreateCurrencyCommand(string Code, string Name, decimal Ratio) : IRequest<Unit>
    {
    }
}
