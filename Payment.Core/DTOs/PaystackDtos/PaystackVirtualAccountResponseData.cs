using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.DTOs.PaystackDtos
{
    public class PaystackVirtualAccountResponseData
    {
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; } = null!;
        [JsonProperty("account_name")]
        public string AccountName { get; set; } = null!;

        public string BankId { get; set; } = null!;
        public string WalletId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        [JsonProperty("bank")]
        public PaystackBankResponseData Bank { get; set; } = null!;
    }
}
