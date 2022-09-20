using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos;
using Payment.Core.DTOs.VirtualAccountDtos;

namespace Payment.Core.Interfaces
{
    public interface IPaystackService
    {
        /// <summary>
        /// Sends a POST request to the Paystack API and generates a virtual account
        /// </summary>
        /// <param name="virtualAccountRequestDto">object containing parameters to be passed
        /// to the Paystack API</param>
        /// <returns></returns>
        public Task<ResponseDto<PaystackVirtualAccountResponseData>> CreateVirtualAccount(VirtualAccountRequestDto virtualAccountRequestDto);
    }
}
