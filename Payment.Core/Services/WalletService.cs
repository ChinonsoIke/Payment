using AutoMapper;
using Payment.Core.DTOs.WalletDtos;
using Payment.Core.Interfaces;
using Payment.Domain.Models;
using Serilog;

namespace Payment.Core.Services
{
    public class WalletService : IWalletService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public WalletService(IUnitOfWork unitOfWork, IMapper mapper, ILogger logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<string> CreateWallet(WalletRequestDto walletRequestDto, string customerCode, string name)
        {
            var wallet = _mapper.Map<Wallet>(walletRequestDto);
            wallet.CustomerCode = customerCode;
            wallet.Name = name;
            await _unitOfWork.Wallets.AddAsync(wallet);

            try
            {
                await _unitOfWork.Save();
                _logger.Information($"Successfully added wallet {wallet.Id} to the database.");
            }
            catch (Exception ex)
            {
                _logger.Information($"Could not add wallet to the database. : {ex.Message}");
                throw;
            }

            return wallet.Id;
        }
    }
}
