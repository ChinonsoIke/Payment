using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.DTOs.PaystackDtos
{
    public class PaystackVirtualAccountResponseDto
    {
        public bool Status { get; set; }
        public string Message { get; set; } = null!;
        public PaystackVirtualAccountResponseData Data { get; set; } = null!;
    }
}
