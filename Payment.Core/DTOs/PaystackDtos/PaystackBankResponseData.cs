using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.DTOs.PaystackDtos
{
    public class PaystackBankResponseData
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [JsonProperty("id")]
        public int PaystackBankId { get; set; }
    }
}
