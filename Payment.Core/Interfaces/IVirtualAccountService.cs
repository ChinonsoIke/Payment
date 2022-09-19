using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos;

namespace Payment.Core.Interfaces
{
    public interface IVirtualAccountService
    {
        public Task CreateVirtualAccount
            (PaystackVirtualAccountResponseData data);
    }
}
