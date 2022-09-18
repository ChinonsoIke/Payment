using Payment.Domain.Common;
using Payment.Domain.Enums;

namespace Payment.Domain.Models
{
    public class Transaction : BaseEntity
    {
        public decimal Amount { get; set; }
        public string Reference { get; set; } = null!;
        public TransactionStatus Status { get; set; }
        public TransactionType Type { get; set; }
        public bool IsInternal { get; set; } = true;
        public string Description { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string WalletId { get; set; } = null!;

        public Wallet Wallet { get; set; } = null!;
    }
}
