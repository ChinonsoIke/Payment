using FluentValidation;
using Payment.Core.DTOs.VirtualAccountDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Utilities.Validators
{
    public class VirtualAccountRequestDtoValidator : AbstractValidator<VirtualAccountRequestDto>
    {
        public VirtualAccountRequestDtoValidator()
        {
            RuleFor(v => v.PaystackCustomerCode).Matches(@"^CUS_[a-z0-9]+$")
                .WithMessage("Value passed does not match a transaction PIN");
            RuleFor(v => v.WalletId).IdGuidString();
            RuleFor(v => v.UserId).IdGuidString();
        }
    }
}
