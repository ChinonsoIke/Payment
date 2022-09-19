using Payment.Core.Interfaces;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure.Repositories
{
    public class BankRepository : GenericRepository<Bank>, IBankRepository
    {
        private readonly PaymentDbContext _context;

        public BankRepository(PaymentDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public IQueryable<Bank> Get(Expression<Func<Bank, bool>> expression)
        {
            return _context.Banks.Where(expression);
        }
    }
}
