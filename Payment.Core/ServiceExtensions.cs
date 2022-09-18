using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Payment.Core.Interfaces;
using Payment.Core.Services;

namespace Payment.Core
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            // Register dependencies here
            services.AddScoped<IBankAccountService, BankAccountService>();
            services.AddScoped<IBankService, BankService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IVirtualAccountService, VirtualAccountService>();
            services.AddScoped<IWalletService, WalletService>();
        }
    }
}
