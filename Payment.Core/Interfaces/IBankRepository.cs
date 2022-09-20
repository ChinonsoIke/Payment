using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Interfaces
{
    public interface IBankRepository : IGenericRepository<Bank>
    {
        Task<Bank> Get(Expression<Func<Bank, bool>> expression);
        IQueryable<Bank> GetAll(Expression<Func<Bank, bool>> expression=null);
    }
}
