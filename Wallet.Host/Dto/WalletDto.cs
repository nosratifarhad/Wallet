using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Dto
{
    public record WalletDto(int ProfileId, string Title, WalletStatus Status,string CurrencyCode)
    {
    }
}
