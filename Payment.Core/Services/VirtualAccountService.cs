using AutoMapper;
using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos;
using Payment.Core.Interfaces;
using Payment.Domain.Models;

namespace Payment.Core.Services
{
    public class VirtualAccountService : IVirtualAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VirtualAccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task CreateVirtualAccount(PaystackVirtualAccountResponseData data)
        {
            var bank = await _unitOfWork.Banks.Get(x => x.PaystackBankId == data.Bank.PaystackBankId);
            if(bank == null)
            {
                var newBank = _mapper.Map<Bank>(data.Bank);
                newBank.Id = Guid.NewGuid().ToString();
                await _unitOfWork.Banks.AddAsync(newBank);
                data.BankId = newBank.Id;
            }

            var virtualAcct = _mapper.Map<VirtualAccount>(data);
            await _unitOfWork.VirtualAccounts.AddAsync(virtualAcct);

            await _unitOfWork.Save();
        }
    }
}
