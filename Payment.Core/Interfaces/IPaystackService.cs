using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos;
using Payment.Core.DTOs.VirtualAccountDtos;
using Payment.Core.DTOs.WalletDtos;

namespace Payment.Core.Interfaces
{
    public interface IPaystackService
    {
        /// <summary>
        /// Sends a POST request to the Paystack API and generates a virtual account
        /// </summary>
        /// <param name="virtualAccountRequestDto">Data transfer object containing parameters to be sent
        /// to the Paystack API</param>
        /// <returns></returns>
        public Task<ResponseDto<PaystackVirtualAccountResponseData>> CreateVirtualAccount(VirtualAccountRequestDto virtualAccountRequestDto);
        /// <summary>
        /// Send a POST request to the Paystack API to create a customer account, then creates a wallet for the customer.
        /// </summary>
        /// <param name="walletRequestDto">Data transfer object containing parameters to be sent
        /// to the Paystack API</param>
        /// <returns></returns>
        public Task<ResponseDto<object>> CreateCustomerWallet(WalletRequestDto walletRequestDto);
    }
}
