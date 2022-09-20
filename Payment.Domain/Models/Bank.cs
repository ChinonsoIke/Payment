using Payment.Domain.Common;

namespace Payment.Domain.Models
{
    public class Bank : BaseEntity
    {
        public string? BankCode { get; set; }
        public string Name { get; set; } = null!;
        public string? CountryCode { get; set; }
        public int? PaystackBankId { get; set; }

        public ICollection<VirtualAccount>? VirtualAccounts { get; set; }
        public ICollection<BankAccount>? BankAccounts { get; set; }
    }
}
