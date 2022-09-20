using Microsoft.Extensions.Configuration;
using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos;
using Payment.Core.DTOs.VirtualAccountDtos;
using Payment.Core.Interfaces;

namespace Payment.Infrastructure.ExternalServices
{
    public class PaystackService : IPaystackService
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientService _httpClientService;
        private readonly IVirtualAccountService _virtualAccountService;

        public PaystackService(IConfiguration config, IHttpClientService httpClientService,
            IVirtualAccountService virtualAccountService)
        {
            _config = config;
            _httpClientService = httpClientService;
            _virtualAccountService = virtualAccountService;
        }
        
        public async Task<ResponseDto<PaystackVirtualAccountResponseData>> CreateVirtualAccount(VirtualAccountRequestDto virtualAccountRequestDto)
        {
            var secretKey = _config["PaystackSettings:SecretKey"];
            var baseUrl = _config["PaystackSettings:BaseUrl"];
            // Endpoint I need
            var url = $"{baseUrl}/dedicated_account";

            var response = await _httpClientService.PostRequestAsync
                <VirtualAccountRequestDto, PaystackGenericResponseDto<PaystackVirtualAccountResponseData>>
                (baseUrl, url, virtualAccountRequestDto, secretKey);
            if (response.Status)
            {
                response.Data.UserId = virtualAccountRequestDto.UserId;
                response.Data.WalletId = virtualAccountRequestDto.WalletId;
                await _virtualAccountService.CreateVirtualAccount(response.Data);
                return ResponseDto<PaystackVirtualAccountResponseData>.Success(
                    "Virtual successfully generated",  null, 201);
            }

            return ResponseDto<PaystackVirtualAccountResponseData>.Fail("Could not create virtual account", 417);
        }
    }
}
