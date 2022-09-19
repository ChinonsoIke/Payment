using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.DTOs
{
    public class VirtualAccountRequestDto
    {
        public string PaystackCustomerId { get; set; } = null!;
        public string WalletId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string PreferredBank { get; set; } = "test-bank";
    }
}
