using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Payment.Core.DTOs.WalletDtos;
using Payment.Core.Interfaces;
using System.Net.Mime;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class WalletsController : ControllerBase
    {
        private readonly IPaystackService _paystackService;

        public WalletsController(IPaystackService paystackService)
        {
            _paystackService = paystackService;
        }

        /// <summary>
        /// Creates a wallet for the user with given UserId
        /// </summary>
        /// <param name="walletRequestDto">Data transfer object containing the request parameters</param>
        /// <returns>A data transfer object containing the result of the request</returns>
        [HttpPost("createwallet")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> CreateWallet(WalletRequestDto walletRequestDto)
        {
            var result = await _paystackService.CreateCustomerWallet(walletRequestDto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
