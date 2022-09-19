using Payment.Core.Interfaces;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class TransferBeneficiaryRepository : GenericRepository<TransferBeneficiary>, ITransferBeneficiaryRepository
    {
        public TransferBeneficiaryRepository(PaymentDbContext dbContext) : base(dbContext)
        {
        }
    }
}
