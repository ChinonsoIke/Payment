using Payment.Domain.Common;

namespace Payment.Domain.Models
{
    public class Bank : BaseEntity
    {
        public string BankCode { get; set; } = null!;
        public string BankName { get; set; } = null!;
        public string CountryCode { get; set; } = null!;

        public VirtualAccount VirtualAccount { get; set; } = null!;
        public ICollection<BankAccount> BankAccounts { get; set; } = null!;
    }
}
