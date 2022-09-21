using Payment.Core.DTOs.WalletDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Core.Interfaces
{
    public interface IWalletService
    {
        /// <summary>
        /// Creates a wallet object and saves it to the database
        /// </summary>
        /// <param name="walletRequestDto">Data transfer object to be mapped to a wallet object</param>
        /// <param name="customerCode"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<string> CreateWallet(WalletRequestDto walletRequestDto, string customerCode, string name);
    }
}
