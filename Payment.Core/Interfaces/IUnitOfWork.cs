using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBankAccountRepository BankAccounts { get; }
        IBankRepository Banks { get; }
        ITransferBeneficiaryRepository TransferBeneficiaries { get; }
        ITransactionRepository Transactions { get; }
        IVirtualAccountRepository VirtualAccounts { get; }
        IWalletRepository Wallets { get; }

        Task Save();
    }
}
