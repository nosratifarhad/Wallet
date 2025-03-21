using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Dto
{
    public record WalletInfoDto(
        int ProfileId, 
        string Title,
        WalletStatus Status,
        CurrencyDto Currency)
    {
    }
}
