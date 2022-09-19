using Payment.Domain.Common;
using Payment.Domain.Enums;

namespace Payment.Domain.Models
{
    public class VirtualAccount : BaseEntity
    {
        public string AccountName { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string AccountReference { get; set; } = null!;
        public VirtualAccountStatus Status { get; set; } = VirtualAccountStatus.Active;
        public string BankId { get; set; } = null!;
        public string WalletId { get; set; } = null!;
        public string UserId { get; set; } = null!;

        public Wallet Wallet { get; set; } = null!;
        public Bank Bank { get; set; } = null!;
    }
}
