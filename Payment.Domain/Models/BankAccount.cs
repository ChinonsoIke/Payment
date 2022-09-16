using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
    public class BankAccount : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BankId { get; set; }
        public string WalletId { get; set; }
        public string UserId { get; set; }

        public Bank Bank { get; set; }
        public Wallet Wallet { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        //public using User { get; set; }
    }
}
