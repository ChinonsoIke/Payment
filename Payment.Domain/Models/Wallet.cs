using Payment.Domain.Common;

namespace Payment.Domain.Models
{
    public class Wallet : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public string UserId { get; set; } = null!;

        public VirtualAccount VirtualAccount { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = null!;
        public ICollection<TransferBeneficiary> Beneficiaries { get; set; } = null!;
    }
}
