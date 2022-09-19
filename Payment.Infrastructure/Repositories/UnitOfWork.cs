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
        private readonly PaymentDbContext _context;
        private BankAccountRepository _bankAccounts { get; set; } = null!;
        private BankRepository _banks { get; set; } = null!;
        private TransactionRepository _transactions { get; set; } = null!;
        private TransferBeneficiaryRepository _beneficiaries { get; set; } = null!;
        private VirtualAccountRepository _virtualAccounts { get; set; } = null!;
        private WalletRepository _wallets { get; set; } = null!;

        public UnitOfWork(PaymentDbContext context)
        {
            _context = context;
        }

        public IBankAccountRepository BankAccounts => _bankAccounts ??= new BankAccountRepository(_context);

        public IBankRepository Banks => _banks ??= new BankRepository(_context);

        public ITransactionRepository Transactions => _transactions ??= new TransactionRepository(_context);

        public IVirtualAccountRepository VirtualAccounts => _virtualAccounts ??= new VirtualAccountRepository(_context);

        public IWalletRepository Wallets => _wallets ??= new WalletRepository(_context);

        public ITransferBeneficiaryRepository TransferBeneficiaries => _beneficiaries ??= new TransferBeneficiaryRepository(_context);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
