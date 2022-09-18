using Payment.Core.Interfaces;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class VirtualAccountRepository : GenericRepository<VirtualAccount>, IVirtualAccountRepository
    {
        public VirtualAccountRepository(PaymentDbContext dbContext) : base(dbContext)
        {
        }
    }
}
