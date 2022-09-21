using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.DTOs.PaystackDtos
{
    public class PaystackCustomerResponseDto
    {
        [JsonProperty("customer_code")]
        public string CustomerCode { get; set; }
    }
}
