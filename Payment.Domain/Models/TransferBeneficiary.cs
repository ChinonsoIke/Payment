using Payment.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
    public class TransferBeneficiary : BaseEntity
    {
        public string RecipientCode { get; set; } = null!;
        public string WalletId { get; set; } = null!;
        public bool IsInternal { get; set; }
        public string BankAccountId { get; set; } = null!;

        public BankAccount? BankAccount { get; set; }
        public Wallet? Wallet { get; set; }
    }
}