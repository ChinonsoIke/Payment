using Payment.Domain.Common;

namespace Payment.Domain.Models
{
    public class BankAccount : BaseEntity
    {
        public string AccountNumber { get; set; } = null!;
        public string AccountName { get; set; } = null!;
        public string BankId { get; set; } = null!;

        public Bank Bank { get; set; } = null!;
        public TransferBeneficiary Beneficiary { get; set; } = null!;
    }
}
