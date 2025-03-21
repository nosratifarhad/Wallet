using MassTransit;
using Wallet.Host.Domain.Wallet;
using Wallet.Host.Domain.Wallet.Entities;
using Wallet.Host.Domain.Wallet.Enums;

namespace Wallet.Host.Subscription.CreateProfile
{
    public class CreateProfileConsumer : IConsumer<CreateProfileEvent>
    {
        private readonly IWalletReadRepository _walletReadRepository;
        private readonly IWalletWriteRepository _walletWriteRepository;
        private const string DefaultWalletName = "DefaultWallet";
        public CreateProfileConsumer(
            IWalletReadRepository walletReadRepository,
            IWalletWriteRepository walletWriteRepository)
        {
            _walletReadRepository = walletReadRepository;
            _walletWriteRepository = walletWriteRepository;
        }

        public async Task Consume(ConsumeContext<CreateProfileEvent> context)
        {
            var walletDto = await _walletReadRepository.GetWallet(context.Message.ProfileId);
            if (walletDto != null)
                return;

            var userWallet = new UserWallet()
            {
                ProfileId = context.Message.ProfileId,
                Status = WalletStatus.Active,
                Title = DefaultWalletName,
                CurrencyCode = "IRR"
            };

            await _walletWriteRepository.CreateWallet(userWallet);
        }
    }
}
