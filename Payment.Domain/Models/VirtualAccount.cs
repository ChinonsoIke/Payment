using Payment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
    public class VirtualAccount : BaseEntity
    {
        public string AccountName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountReference { get; set; }
        public VirtualAccountStatus Status { get; set; }
        public string BankId { get; set; }
        public string WalletId { get; set; }
        public string UserId { get; set; }

        public Wallet Wallet { get; set; }
        public Bank Bank { get; set; }
        //public User User { get; set; }
    }
}
