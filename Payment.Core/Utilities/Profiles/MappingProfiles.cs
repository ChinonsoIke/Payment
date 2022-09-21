using AutoMapper;
using Payment.Core.DTOs.PaystackDtos;
using Payment.Core.DTOs.WalletDtos;
using Payment.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Utilities.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PaystackBankResponseData, Bank>();
            CreateMap<PaystackVirtualAccountResponseData, VirtualAccount>();
            CreateMap<WalletRequestDto, Wallet>();
        }
    }
}
