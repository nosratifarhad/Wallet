using MassTransit;
using System.Reflection;
using Wallet.Host.Options;

namespace Wallet.Host.Extensions
{
    public static class ServiceActivationExtensions
    {
        public static void ConfigureBroker(this WebApplicationBuilder builder)
        {
            builder.Services.AddMassTransit(configure =>
            {
                var brokerConfig = builder.Configuration.GetSection(WalletOptions.SectionName)
                                                        .Get<WalletOptions>();
                if (brokerConfig is null)
                {
                    throw new ArgumentNullException(nameof(WalletOptions));
                }

                configure.AddConsumers(Assembly.GetExecutingAssembly());
                configure.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(brokerConfig.Host, hostConfigure =>
                    {
                        hostConfigure.Username(brokerConfig.Username);
                        hostConfigure.Password(brokerConfig.Password);
                    });

                    cfg.ConfigureEndpoints(context);
                });
            });
        }
    }
}
