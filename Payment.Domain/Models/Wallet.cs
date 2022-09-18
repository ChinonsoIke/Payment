using Payment.Domain.Common;

namespace Payment.Domain.Models
{
    public class Wallet : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public string UserId { get; set; } = null!;

        public VirtualAccount VirtualAccount { get; set; } = null!;
        public BankAccount BankAccount { get; set; } = null!;
        public ICollection<Transaction> Payments { get; set; } = null!;
    }
}
