using Payment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Reference { get; set; }
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }
        public bool IsInternal { get; set; } = true;
        public string Description { get; set; }
        public string UserId { get; set; }
        public string WalletId { get; set; }

        //public User User { get; set; }
        public Wallet Wallet { get; set; }
    }
}
