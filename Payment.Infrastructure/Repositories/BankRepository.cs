using Microsoft.EntityFrameworkCore;
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

        public async Task<Bank> Get(Expression<Func<Bank, bool>> expression)
        {
            return await _context.Banks.FirstOrDefaultAsync(expression);
        }

        public IQueryable<Bank> GetAll(Expression<Func<Bank, bool>> expression = null)
        {
            return _context.Banks;
        }
    }
}
