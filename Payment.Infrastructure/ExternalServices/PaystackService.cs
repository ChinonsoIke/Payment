using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Configuration;
using Payment.Core.DTOs;
using Payment.Core.DTOs.PaystackDtos;
using Payment.Core.DTOs.VirtualAccountDtos;
using Payment.Core.DTOs.WalletDtos;
using Payment.Core.Interfaces;
using Serilog;
using System.Net;

namespace Payment.Infrastructure.ExternalServices
{
    public class PaystackService : IPaystackService
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientService _httpClientService;
        private readonly IVirtualAccountService _virtualAccountService;
        private readonly IWalletService _walletService;
        private readonly IValidator<WalletRequestDto> _walletRequestValidator;
        private readonly IValidator<VirtualAccountRequestDto> _virtualAccountRequestValidator;
        private readonly ILogger _logger;
        private readonly string _secretKey;
        private readonly string _baseUrl;

        public PaystackService(IConfiguration config, IHttpClientService httpClientService,
            IVirtualAccountService virtualAccountService, IWalletService walletService,
            IValidator<WalletRequestDto> walletRequestValidator,
            IValidator<VirtualAccountRequestDto> virtualAccountRequestValidator,
            ILogger logger)
        {
            _config = config;
            _httpClientService = httpClientService;
            _virtualAccountService = virtualAccountService;
            _walletService = walletService;
            _walletRequestValidator = walletRequestValidator;
            _virtualAccountRequestValidator = virtualAccountRequestValidator;
            _logger = logger;

            _secretKey = _config["PaystackSettings:SecretKey"];
            _baseUrl = _config["PaystackSettings:BaseUrl"];
        }

        public async Task<ResponseDto<object>> CreateCustomerWallet(WalletRequestDto walletRequestDto)
        {
            var validation = await _walletRequestValidator.ValidateAsync(walletRequestDto);
            if (!validation.IsValid)
            {
                return ResponseDto<object>.Fail("One or more of your inputs are incorrect", 400);
            }

            string url = "/customer";

            try
            {
                var response = await _httpClientService.PostRequestAsync
                    <WalletRequestDto, PaystackGenericResponseDto<PaystackCustomerResponseDto>>
                    (_baseUrl, url, walletRequestDto, _secretKey);

                if(response.Status)
                {
                    //call wallet service to create wallet - pass in customer reference
                    var walletId = await _walletService.CreateWallet
                        (walletRequestDto, response.Data.CustomerCode, $"{walletRequestDto.FirstName} {walletRequestDto.LastName}");
                    //call createvirtual account method
                    var virtualAccountRequestDto = new VirtualAccountRequestDto()
                    {
                        WalletId = walletId,
                        PaystackCustomerCode = response.Data.CustomerCode,
                        UserId = walletRequestDto.UserId
                    };
                    var virtualAccountResponse = await CreateVirtualAccount(virtualAccountRequestDto);

                    //return 201
                    if (virtualAccountResponse.Status)
                    {
                        return ResponseDto<object>.Success
                            ("Wallet successfully created", new { WalletId = walletId, CreatedVirtualAccount = true }, 201);
                    }

                    return ResponseDto<object>.Success
                        ("Wallet successfully created", new { WalletId = walletId, CreatedVirtualAccount = false }, 201);
                }

                _logger.Error($"Could not create wallet: {response.Message}");
                return ResponseDto<object>.Fail("Could not create wallet", 417);
            }
            catch (Exception ex)
            {
                _logger.Error($"Could not create wallet: {ex.Message}");
                return ResponseDto<object>.Fail("Could not create wallet", 417);
            }
        }

        public async Task<ResponseDto<PaystackVirtualAccountResponseData>>
            CreateVirtualAccount(VirtualAccountRequestDto virtualAccountRequestDto)
        {
            var validation = await _virtualAccountRequestValidator.ValidateAsync(virtualAccountRequestDto);
            if (!validation.IsValid) 
            {
                return ResponseDto<PaystackVirtualAccountResponseData>.Fail("One or more of your inputs are incorrect", 400);
            }

            var url = $"{_baseUrl}/dedicated_account";

            try
            {
                var response = await _httpClientService.PostRequestAsync
                    <VirtualAccountRequestDto, PaystackGenericResponseDto<PaystackVirtualAccountResponseData>>
                    (_baseUrl, url, virtualAccountRequestDto, _secretKey);
                if (response.Status)
                {
                    response.Data.UserId = virtualAccountRequestDto.UserId;
                    response.Data.WalletId = virtualAccountRequestDto.WalletId;
                    await _virtualAccountService.CreateVirtualAccount(response.Data);
                    return ResponseDto<PaystackVirtualAccountResponseData>.Success(
                        "Virtual successfully generated", null, 201);
                }

                _logger.Error($"Could not create wallet: {response.Message}");
                return ResponseDto<PaystackVirtualAccountResponseData>.Fail("Could not create virtual account", 417);
            }
            catch (Exception ex)
            {
                _logger.Error($"Could not create wallet: {ex.Message}");
                return ResponseDto<PaystackVirtualAccountResponseData>.Fail("Could not create virtual account", 417);
            }

        }
    }
}
