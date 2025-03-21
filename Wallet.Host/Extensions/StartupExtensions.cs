using MassTransit;
using Wallet.Host.Domain.Wallet;
using Wallet.Host.Repositories;
using Wallet.Host.Services;
using Wallet.Host.Services.Contracts;
using Wallet.Host.Subscription.CreateProfile;

namespace Wallet.Host.Extensions
{
    public static class StartupExtensions
    {
        public static void AddServiceRegistryConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            #region [ Service ]

            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IWalletService, WalletService>();

            #endregion [ Service ]

            #region [ Events ]

            services.AddScoped<IConsumer<CreateProfileEvent>, CreateProfileConsumer>();

            #endregion [ Events ]

            #region [ Infra - Data ]

            services.AddScoped<ICurrencyReadRepository, CurrencyReadRepository>();
            services.AddScoped<ICurrencyWriteRepository, CurrencyWriteRepository>();
            services.AddScoped<ITransactionReadRepository, TransactionReadRepository>();
            services.AddScoped<ITransactionWriteRepository, TransactionWriteRepository>();
            services.AddScoped<IWalletReadRepository, WalletReadRepository>();
            services.AddScoped<IWalletWriteRepository, WalletWriteRepository>();

            #endregion [ Infra - Data ]

        }
    }
}