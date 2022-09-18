using Payment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IBankAccountRepository BankAccounts => throw new NotImplementedException();

        public IBankRepository Banks => throw new NotImplementedException();

        public ITransactionRepository Transactions => throw new NotImplementedException();

        public IVirtualAccountRepository VirtualAccounts => throw new NotImplementedException();

        public IWalletRepository Wallets => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}
