using FluentValidation;
using Payment.Core.DTOs.WalletDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Utilities.Validators
{
    public class WalletRequestDtoValidator : AbstractValidator<WalletRequestDto>
    {
        public WalletRequestDtoValidator()
        {
            RuleFor(w => w.FirstName).HumanName();
            RuleFor(w => w.LastName).HumanName();
            RuleFor(w => w.Email).EmailAddress();
            RuleFor(w => w.Pin).Matches(@"^[0-9]{4}$");
            RuleFor(w => w.UserId).IdGuidString();
        }
    }
}
