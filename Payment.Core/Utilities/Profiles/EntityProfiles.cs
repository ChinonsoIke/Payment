using AutoMapper;
using Payment.Core.DTOs;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Utilities.Profiles
{
    public class EntityProfiles : Profile
    {
        public EntityProfiles()
        {
            CreateMap<Bank, BankResponseDto>();
            CreateMap<BankAccount, BankAccountResponseDto>();
            CreateMap<Transaction, TransactionResponseDto>();
            CreateMap<VirtualAccount, VirtualAccountResponseDto>();
            CreateMap<Wallet, WalletResponseDto>();
        }
    }
}
