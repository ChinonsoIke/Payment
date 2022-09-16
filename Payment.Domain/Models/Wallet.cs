using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
    public class Wallet : BaseEntity
    {
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public string UserId { get; set; }

        //public User User { get; set; } 
        public VirtualAccount VirtualAccount { get; set; } 
        public BankAccount BankAccount { get; set; }
        public ICollection<Transaction> Payments { get; set; }
    }
}
