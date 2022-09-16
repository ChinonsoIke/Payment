using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Domain.Models
{
    public class Bank : BaseEntity
    {
        public string BankCode { get; set; }
        public string BankName { get; set; }
        public string CountryCode { get; set; }

        public VirtualAccount VirtualAccount { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
