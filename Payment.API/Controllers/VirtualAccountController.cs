using Microsoft.AspNetCore.Mvc;
using Payment.Core.DTOs;
using Payment.Core.Interfaces;
using System.Net.Mime;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class VirtualAccountController : ControllerBase
    {
        private readonly IPaystackService _paystackService;

        public VirtualAccountController(IPaystackService paystackService)
        {
            _paystackService = paystackService;
        }

        /// <summary>
        /// Sends a POST request to the Paystack API and generates a virtual account
        /// </summary>
        /// <param name="virtualAccountRequestDto">object containing parameters to be passed
        /// to the Paystack API</param>
        /// <returns></returns>
        [HttpPost("createvirtualaccount")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status417ExpectationFailed)]
        public async Task<IActionResult> Create(
            [FromBody] VirtualAccountRequestDto virtualAccountRequestDto)
        {
            var result = await _paystackService.CreateVirtualAccount(virtualAccountRequestDto);
            return StatusCode(result.StatusCode, result);
        }
    }
}
